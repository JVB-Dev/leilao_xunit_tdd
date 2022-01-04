using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Tests.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [MemberData(nameof(LancesMock.ValidaValorGanhador), MemberType = typeof(LancesMock))]
        public void RetornaMaiorLanceComAoMenosUmLance(double lanceGanhadorEsperado, Dictionary<string, double> lances)
        {
            // arrange (cenário)
            IModalidadeAvaliacao modalidade = new LanceMaior();
            var leilao = new Leilao("Quadro Van Gogh", modalidade);

            leilao.IniciaPregao();

            foreach (KeyValuePair<string, double> lance in lances)
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
            // arrange (cenário)
            IModalidadeAvaliacao modalidade = new LanceMaior();
            var leilao = new Leilao("Quadro Van Gogh", modalidade);

            leilao.IniciaPregao();

            // act (método a ser testado)
            leilao.TerminaPregao();

            // assert (resultado esperado)
            int lanceGanhadorEsperado = 0;
            Assert.Equal(lanceGanhadorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void RetornaInvalidOperationExceptionSeTerminarPregaoSemIniciarLeilao()
        {
            // arrange (cenário)
            IModalidadeAvaliacao modalidade = new LanceMaior();
            var leilao = new Leilao("Quadro Van Gogh", modalidade);

            // poderia ser assert aqui, se eu remover a captura da exception
            var exception = Assert.Throws<InvalidOperationException>(
                
                // act (método a ser testado)
                () => leilao.TerminaPregao()
            );

            // assert (resultado esperado)
            string mensagemEsperada = "O leilão deve estar em andamento para ser encerrado";
            Assert.Equal(mensagemEsperada, exception.Message);
        }

        [Theory]
        [InlineData(300, 320, new double[] { 100, 200, 290, 320, 330 })]
        public void RetornaMaiorLanceMaisProximoDoValorPretendido(double valorPretendido, double lanceGanhadorEsperado, double[] lances)
        {
            // arrange (cenário)
            IModalidadeAvaliacao modalidade = new LanceIgualOuMaiorMaisProximo(valorPretendido);
            var leilao = new Leilao("Quadro Van Gogh", modalidade);

            leilao.IniciaPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                double lance = lances[i];
                leilao.RecebeLance(new Interessada($"Pessoa {i}", leilao), lance);
            }

            // act (método a ser testado)
            leilao.TerminaPregao();

            Assert.Equal(lanceGanhadorEsperado, leilao.Ganhador.Valor);
        }
    }    
}
