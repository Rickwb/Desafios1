using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Estacionamento.Models
{
    public class Ticket
    {
        public Ticket(Cliente cliente, int diaria)
        {
            Id = Guid.NewGuid();
            Cliente = cliente;
            Diaria = diaria;
            HorarioChegada = DateTime.Now;
        }

        public Ticket(Cliente cliente, int diaria, bool lavacao)
        {
            Id = Guid.NewGuid();
            Cliente = cliente;
            HorarioChegada = DateTime.Now;
            Diaria = diaria;
            if (cliente.Veiculo is Moto)
                Lavacao = false;
            else
                Lavacao = lavacao;
        }

        public Guid Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public TimeSpan? TempoTotal { get; set; }
        public DateTime HorarioChegada { get; private set; }
        public DateTime? HorarioSaida { get; set; }
        public decimal TotalPagar { get; set; }
        public bool Pago { get; private set; }
        public int Diaria { get; private set; }
        public bool Lavacao { get; private set; }

        public void CalcularTempo(DateTime horarioSaida)
        {
            if (horarioSaida > HorarioChegada)
                HorarioSaida = horarioSaida;

            TempoTotal = (TimeSpan)(HorarioChegada - HorarioSaida);

        }
        public bool ValidarTicketsSaida()
        {
            if (HorarioSaida.HasValue)
                throw new Exception("O horario de saida não foi indicado");
            if (HorarioSaida > HorarioChegada)
                throw new Exception("O horario de saida não pode ser maior que o horario de chegada");
            if (Cliente.TickekAntigos.Contains(Cliente.TicketAtual))
            {
                Pago = true;
                return true;
            }
            return false;
        }


        public decimal CalcularValor()
        {
            if (TempoTotal.HasValue)
            {
                if (Cliente.Veiculo is Carro)
                {

                    if (Diaria > 0)
                    {
                        TotalPagar = Diaria < TempoTotal.Value.Days ? TempoTotal.Value.Days * 25 + TempoTotal.Value.Hours * 5 : TempoTotal.Value.Days * 25;
                    }
                    else
                    {
                        TotalPagar = TempoTotal.Value < TimeSpan.FromMinutes(15) ? TotalPagar = 2M : TotalPagar = 5m + (TempoTotal.Value.Hours - 1) * 5m; ;
                    }
                }
                else
                { 
                        if (Diaria > 0)
                    {
                        if (Lavacao)
                            TotalPagar = Diaria < TempoTotal.Value.Days ? TempoTotal.Value.Days * 65 + TempoTotal.Value.Hours * 10m : TempoTotal.Value.Days * 50;
                        else
                            TotalPagar = Diaria < TempoTotal.Value.Days ? TempoTotal.Value.Days * 50 + TempoTotal.Value.Hours * 10m : TempoTotal.Value.Days * 50;
                    }
                    else
                    {
                        TotalPagar = TempoTotal.Value < TimeSpan.FromMinutes(15) ? TotalPagar = 2M : TotalPagar = 10m + (TempoTotal.Value.Hours - 1) * 10m; ;
                    }
                }
            }
            return TotalPagar;

        }
        }
}
}