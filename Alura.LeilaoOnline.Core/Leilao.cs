using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoEmDivulgacao,
        LeilaoEmAdamento,
        LeilaoFinalizado,
    }

    public class Leilao
    {
        private Lance _ultimoLance;
        private IList<Lance> _lances;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; set; }
        public IModalidadeAvaliacao Modalidade;

        public Leilao(string peca, IModalidadeAvaliacao modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoEmDivulgacao;
            Modalidade = modalidade;
        }

        private bool EhLanceValido(Interessada cliente, double valor)
        {
            return Estado is EstadoLeilao.LeilaoEmAdamento
                && (_ultimoLance is null || (cliente.Nome != _ultimoLance.Cliente.Nome && valor > _ultimoLance.Valor));
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (EhLanceValido(cliente, valor))
            {
                var lance = new Lance(cliente, valor);
                _lances.Add(lance);
                _ultimoLance = lance;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAdamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAdamento)
                throw new InvalidOperationException("O leilão deve estar em andamento para ser encerrado");

            Ganhador = Modalidade.Avalia(this);

            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
