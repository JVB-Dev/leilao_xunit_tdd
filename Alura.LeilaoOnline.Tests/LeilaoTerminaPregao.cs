using Alura.LeilaoOnline.Core;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [MemberData(nameof(LancesMockLeilaoTest.Lances), MemberType = typeof(LancesMockLeilaoTest))]
        public void RetornaMaiorLanceComAoMenosUmLance(double lanceGanhadorEsperado, Dictionary<string, double> lances)
        {
            // arrange (cenário)
            var leilao = new Leilao("Quadro Van Gogh");

            leilao.IniciaPregao();

            foreach (var lance in lances)
            {
                leilao.RecebeLance(new Interessada(lance.Key, leilao), lance.Value);
            }

            // act (método a ser testado)
            leilao.TerminaPregao();

            // assert (resultado esperado)
            Assert.Equal(lanceGanhadorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void RetornaZeroParaLeilaoSemLances()
        {
            var leilao = new Leilao("Quadro Van Gogh");

            leilao.TerminaPregao();

            int lanceGanhadorEsperado = 0;

            Assert.Equal(lanceGanhadorEsperado, leilao.Ganhador.Valor);
        }
    }

    public class LancesMockLeilaoTest
    {
        public static IEnumerable<object[]> Lances =>
            new List<object[]>
            {
                new object[] { 500, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 400 }, { "Beltrano", 500 } } },
                new object[] { 500, new Dictionary<string, double> { { "Fulano", 300 }, { "Sicrano", 500 }, { "Beltrano", 400 } } },
                new object[] { 300, new Dictionary<string, double> { { "Fulano", 300 } } },
            };
    }
}
