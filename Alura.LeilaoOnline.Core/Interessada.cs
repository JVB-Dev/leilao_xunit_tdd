using System;

namespace Alura.LeilaoOnline.Core
{
    public class Interessada
    {
        public Guid Id { get; set; }
        public string Nome { get; }
        public Leilao Leilao { get; }

        public Interessada(string nome, Leilao leilao)
        {
            Id = new Guid();
            Nome = nome;
            Leilao = leilao;
        }
    }
}
