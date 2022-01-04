using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Tests.Mock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        //[InlineData(2, new double[] { 100, 200 })]
        //[InlineData(3, new double[] { 100, 200, 300 })]
        //[InlineData(4, new double[] { 100, 200, 400, 300 })]
        [MemberData(nameof(LancesMock.ValidaQtdLances), MemberType = typeof(LancesMock))]
        public void NaoPermiteNovosLancesAposLeilaoTerminaPregao(int numeroDeLancesEsperado, Dictionary<string, double> lances)
        {
            // arrange (cenário)
            IModalidadeAvaliacao modalidade = new LanceMaior();
            var leilao = new Leilao("Quadro Van Gogh", modalidade);

            leilao.IniciaPregao();

            foreach (var lance in lances)
            {
                // act (método a ser testado)
                leilao.RecebeLance(new Interessada(lance.Key, leilao), lance.Value);
            }

            leilao.TerminaPregao();

            // assert (resultado esperado)
            Assert.Equal(numeroDeLancesEsperado, leilao.Lances.Count());
        }
    }
}
