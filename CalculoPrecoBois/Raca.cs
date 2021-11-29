using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaPrecoBois
{
    public class Raca
    {
        public Raca(string nome, decimal precoArroba)
        {
            Nome = nome;
            PrecoArroba = precoArroba;
        }
        public string Nome { get; set; }
        public decimal PrecoArroba { get; set; }

     
    }
}
