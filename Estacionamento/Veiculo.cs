using Desafio1_Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Estacionamento
{
    public abstract class Veiculo
    {
        protected Veiculo(string placa, string modelo, string marca, Cliente cliente)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Cliente = cliente;
        }

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public Cliente Cliente { get; set; }
    }
}
