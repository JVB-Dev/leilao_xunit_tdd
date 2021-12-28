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
        public Interessada _ultimoInteressado { get; set; }
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoEmDivulgacao;
        }

        private bool EhLanceValido(Interessada cliente)
        {
            return (cliente.Id != this._ultimoInteressado.Id)
                && (Estado == EstadoLeilao.LeilaoEmAdamento);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (EhLanceValido(cliente))
                _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAdamento;
        }

        public void TerminaPregao()
        {
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(_ => _.Valor)
                .LastOrDefault();

            Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}
