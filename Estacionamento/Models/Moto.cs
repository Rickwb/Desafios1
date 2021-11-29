using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Estacionamento.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa, string modelo, string marca, Cliente cliente, global::Estacionamento estacionmaneto) : base(placa, modelo, marca, cliente, estacionmaneto)
        {
        }
    }
}
