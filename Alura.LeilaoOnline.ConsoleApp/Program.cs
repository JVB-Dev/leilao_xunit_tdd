using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var leilao = new Leilao("Quadro Van Gogh");

            var joao = new Interessada("João", leilao);
            var maria = new Interessada("Maria", leilao);
            var jose = new Interessada("José", leilao);

            leilao.RecebeLance(joao, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(jose, 1000);

            leilao.TerminaPregao();

            Console.WriteLine($"{leilao.Ganhador.Cliente.Nome} - {leilao.Ganhador.Valor}");
        }
    }
}
