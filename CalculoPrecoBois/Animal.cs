using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaPrecoBois
{
    public class Animal
    {
        public Animal(int id,string raca, double pesagem, double fatorMultiplicao)
        {
            Id = id;
            Raca = raca;
            Pesagem = pesagem;
            FatorMultiplicao = fatorMultiplicao;
        }

        public int Id { get; set; }
        public string Raca { get; set; }
        public double Pesagem { get; set; }
        public decimal Preco { get; set; }
        public double FatorMultiplicao { get; set; }
        public decimal PrecoArroba { get; set; }

    }
}
