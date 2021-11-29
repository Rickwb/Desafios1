using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Estacionamento.Models
{
    public class Estacionamento
    {
        public Estacionamento(string nome, string cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
            _todosTickectsPagos ??= new List<Ticket>();
            _todosTickectsAbertos ??= new List<Ticket>();
            Clientes ??= new List<Cliente>();
        }
        private List<Ticket> _todosTickectsAbertos { get; set; }
        private List<Ticket> _todosTickectsPagos { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public IReadOnlyCollection<Ticket> TodosTicketsAbertos { get => _todosTickectsAbertos; }
        public IReadOnlyCollection<Ticket> TodosTicketsPagos { get => _todosTickectsPagos; }
        public List<Cliente> Clientes { get; set; }
        public int QtdVagasCarro { get; set; }
        public int QtdVagasMoto { get; set; }

        public Ticket GerarTicket(Cliente cli, int diarias)
        {
            var tk = new Ticket(cli, diarias);
            _todosTickectsAbertos.Add(tk);
            return tk;
        }
        public Ticket GerarTicket(Cliente cli, int diarias, bool lavacao)
        {
            if (cli.Carro is null)
            {
                var tk = new Ticket(cli, diarias);
                _todosTickectsAbertos.Add(tk);
                return tk;
            }
            else
            {
                var tk = new Ticket(cli, diarias, lavacao);
                _todosTickectsAbertos.Add(tk);
                return tk;
            }
        }
        public bool Finalizar(Ticket ti)
        {
            ti.CalcularTempo(DateTime.Now);
            ti.CalcularValor();
            if (ti.ValidarTicketsSaida())
            {
                _todosTickectsAbertos.Remove(ti);
                _todosTickectsPagos.Add(ti);
                return true;
            }
            return false;



        }


    }
}
