using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento1.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa, string modelo, string marca, Cliente cliente) : base(placa, modelo, marca, cliente)
        {
        }
    }
}
