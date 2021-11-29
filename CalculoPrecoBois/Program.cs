using System;

namespace CalculaPrecoBois
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculos = new Calculos();
            calculos.LerArquivo(@"C:\Users\PremierSoft\Documents\ExerciciosAppAcademy\Desafio1\Desafio_CsvBois\Animais.txt");
            calculos.LerArquivoRaca(@"C:\Users\PremierSoft\Documents\ExerciciosAppAcademy\Desafio1\Desafio_CsvBois\Raca.txt");
            calculos.GerarRelatorio(calculos.AnimaisDecresentePreco());
        }
    }
}
