using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(2, new double[] { 100, 200 })]
        [InlineData(3, new double[] { 100, 200, 300 })]
        [InlineData(4, new double[] { 100, 200, 400, 300 })]
        public void NaoPermiteNovosLancesAposLeilaoTerminaPregao(int numeroDeLancesEsperado, double[] lances)
        {
            // arrange (cenário)
            var leilao = new Leilao("Quadro Van Gogh");

            var pessoa1 = new Interessada("Pessoa 1", leilao);

            leilao.IniciaPregao();

            foreach (var lance in lances)
            {
                leilao.RecebeLance(pessoa1, lance);
            }

            leilao.TerminaPregao();

            // act (método a ser testado)
            leilao.RecebeLance(pessoa1, 250);

            // assert (resultado esperado)
            Assert.Equal(numeroDeLancesEsperado, leilao.Lances.Count());
        }
    }
}
