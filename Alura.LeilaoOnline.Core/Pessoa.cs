using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Core
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; }
        public List<Leilao> Leiloes { get; }
        public List<Lance> Lances { get; set; }

        public Pessoa(string nome)
        {
            Id = new Guid();
            Nome = nome;
            Lances = new List<Lance>();
            Leiloes = new List<Leilao>();
        }

        public Pessoa(string nome, Leilao leilao) : this(nome)
        {
            Leiloes.Add(leilao);
        }
    }
}
