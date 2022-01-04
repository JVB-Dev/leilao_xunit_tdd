using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core
{
    public class LanceIgualOuMaiorMaisProximo : IModalidadeAvaliacao
    {
        private readonly double _valorPretendido;

        public LanceIgualOuMaiorMaisProximo(double valorPretendido)
        {
            _valorPretendido = valorPretendido;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                    .DefaultIfEmpty(new Lance(null, _valorPretendido))
                    .Where(_ => _.Valor >= _valorPretendido)
                    .OrderBy(_ => _.Valor)
                    .First();
        }
    }
}
