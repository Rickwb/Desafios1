using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Desafio1_Estacionamento.Enums;

namespace Desafio1_Estacionamento.Models
{
    public class Cliente
    {
        
        public Cliente(
                       string nome,
                       string cpf,
                       Ticket? ticketAtual,
                       Moto? moto,
                       Estacionamento estacionamento)

        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            TicketAtual = ticketAtual;
            Estacionamento = estacionamento;
            Moto = moto;
        }     
        public Cliente(
                       string nome,
                       string cpf,
                       Ticket? ticketAtual,
                       Estacionamento estacionamento,
                       Carro? carro)

        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            TicketAtual = ticketAtual;
            Estacionamento = estacionamento;
            Carro = carro;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public List<Ticket> TickekAntigos { get; private set; }
        public decimal Multas { get; set; }
        public Carro? Carro { get; init; }
        public Moto? Moto { get; init; }

        public void Finalizar()
        {
            TickekAntigos.Add(TicketAtual);
            bool liberado = Estacionamento.Finalizar(TicketAtual);
            if (liberado)
                TicketAtual = null;
            else
                throw new Exception("O ticket não pode ser liberado");
        }
    }
}
