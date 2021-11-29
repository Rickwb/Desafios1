using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaPrecoBois
{
    public class Calculos
    {
        public Calculos()
        {
            Animais ??= new List<Animal>();
            Racas ??= new List<Raca>();
        }
        public Calculos(List<Animal> animais, List<Raca> racas)
        {
            Animais = animais;
            Racas = racas;
        }

        public List<Animal> Animais { get; set; }
        public List<Raca> Racas { get; set; }

        public void MontarArquivos()
        {
            foreach (var item in Animais)
            {
                Raca e = Racas.First(x => x.Nome == item.Raca);
                item.Preco = (decimal)(item.Pesagem * item.FatorMultiplicao * (double)e.PrecoArroba);
                item.PrecoArroba = e.PrecoArroba;
            }
        }
        public Animal MaiorPreco(List<Animal> animais)
        {
            decimal maiorValor = animais.Max(x => x.Preco);
            return animais.First(x => x.Preco == maiorValor);
        }
        public List<Animal> AnimaisDecresentePreco()
        {
            return Animais.OrderByDescending(x => x.Preco).ToList();
        }

        public bool GerarRelatorio(List<Animal> listaPrecoDecre)
        {
            try
            {
                using (var streamWriter = new StreamWriter(@"C:\Users\PremierSoft\Documents\ExerciciosAppAcademy\Desafio1\Desafio_CsvBois\Relatorio.txt")) 
                {
                    streamWriter.WriteLine("Data do Relatorio: " + DateTime.Today.ToString());
                    streamWriter.WriteLine(String.Format("ID,Raça,Peso,Preço,Preço da Arroba"));
                    foreach (var animal in listaPrecoDecre)
                    {
                        streamWriter.WriteLine(String.Format("{0},{1},{2},{3},{4}", animal.Id.ToString(), animal.Raca, animal.Pesagem.ToString(), animal.Preco.ToString(), animal.PrecoArroba.ToString()));
                    }
                    streamWriter.WriteLine("Animal mais caro:");
                    var ani = MaiorPreco(Animais);
                    streamWriter.WriteLine(String.Format("{0},{1},{2},{3},{4}", ani.Id, ani.Raca, ani.Pesagem, ani.Preco, ani.PrecoArroba));
                }
                return true;

            }
            catch (FileNotFoundException ex)
            {
                return false;
            }

        }

        public List<Animal> LerArquivo(string path)
        {
            var animals = new List<Animal>();
            var st = new StreamReader(File.OpenRead(path));

            while (!st.EndOfStream)
            {
                var line = st.ReadLine();
                var valores = line.Split(',');
                var animal = new Animal(int.Parse(valores[0]), valores[1], double.Parse(valores[2]), double.Parse(valores[3]));
                Animais.Add(animal);
            }
            return animals;
        }

        public List<Raca> LerArquivoRaca(string path)
        {
            var racas = new List<Raca>();
            var st = new StreamReader(File.OpenRead(path));
            while (!st.EndOfStream)
            {
                var line = st.ReadLine();
                var valores = line.Split(',');
                var raca = new Raca(valores[0], decimal.Parse(valores[1]));
                Racas.Add(raca);
            }
            return racas;

        }
    }
}
