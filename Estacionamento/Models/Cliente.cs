using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Estacionamento.Models
{
    public class Cliente
    {
        
        public Cliente(
                       string nome,
                       string cpf,
                       Ticket? ticketAtual,
                       global::Estacionamento estacionamento,
                       Veiculo veiculo)

        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cpf = cpf;
            TicketAtual = ticketAtual;
            Estacionamento = estacionamento;
            Veiculo = veiculo;
        }     
     

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public global::Estacionamento Estacionamento { get; set; }
        public List<Ticket> TickekAntigos { get; private set; }
        public decimal Multas { get; set; }
        
        public Veiculo Veiculo { get; set; }
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
