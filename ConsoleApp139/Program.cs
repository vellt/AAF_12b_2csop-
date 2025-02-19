using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp139
{
    class Etel
    {
        public int Id { get; set; }
        public string Neve { get; set; }
        public int Energia { get; set; }
        public int Szenh { get; set; }
        public int Ara { get; set; }
        public char Kategoria { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Etel> etelek = ReadData();
            // Írassuk ki az ételeknek a kategória, 
            // neve, ára értékeit (select nélkül + anonim osztállyal is)
            etelek.ForEach(x => Console.WriteLine($"({x.Kategoria}) {x.Neve}: {x.Ara} Ft"));
            // anoním osztállyal select + anoním: így csak a select után a selectben megfogalmazott
            // propertik érhetőek el
            etelek.Select(x => new
            {
                Kategoria = x.Kategoria,
                Neve = x.Neve,
                Ara = x.Ara,
            }).ToList().ForEach(x => Console.WriteLine($"({x.Kategoria}) {x.Neve}: {x.Ara} Ft"));
            // selectben mondjuk meg a kiíratás formáját
            etelek.Select(x => $"({x.Kategoria}) {x.Neve}: {x.Ara} Ft").ToList()
                .ForEach(x => Console.WriteLine(x));

            // Írassuk ki az ételeknek a neve és a szénhidrát értékeit (selecttel)
            etelek.ForEach(x => Console.WriteLine($"{x.Neve}: {x.Szenh}"));

            etelek.Select(x => new
            {
                Neve = x.Neve,
                Szenh = x.Szenh
            }).ToList().ForEach(x => Console.WriteLine($"{x.Neve}: {x.Szenh}"));

            etelek.Select(x => $"{x.Neve}: {x.Szenh}").ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki az ételeket de csak a nevük látszódjon.
            etelek.Select(x => x.Neve).ToList().ForEach(x => Console.WriteLine(x));

            etelek.ForEach(x => Console.WriteLine(x.Neve));

            // Rendezzük az ételeket név alapján ábécé szerint növekvő sorrendben.
            etelek.OrderBy(x => x.Neve).Select(x => x.Neve)
                .ToList().ForEach(x => Console.WriteLine(x));

            etelek.OrderBy(x => x.Neve).ToList().ForEach(x => Console.WriteLine(x.Neve));

            //Rendezzük az ételeket név alapján ábécé szerint csökkenő sorrendben
            etelek.OrderByDescending(x => x.Neve)
                .ToList().ForEach(x => Console.WriteLine(x.Neve));

            // Mennyi étel van a listában?
            int db = etelek.Count();
            Console.WriteLine(db);

            // Van aranygaluska nevű étel a listában?
            bool van= etelek.Exists(x => x.Neve.ToLower() == "aranygaluska");
            Console.WriteLine(van ? "van" : "nincs");

            // Van olyan étel a listában ami tartalmaz arany szórészletet?
            bool van2 = etelek.Exists(x => x.Neve.ToLower().Contains("arany"));
            Console.WriteLine(van2 ? "van" : "nincs");

            // Írassuk ki az első ételét a listának.
            Etel elsoEtel = etelek.First();
            Console.WriteLine($"{elsoEtel.Id} {elsoEtel.Neve} {elsoEtel.Kategoria}");

            // Írassuk ki az utolsó ételét a listának.
            Etel utolsoEtel = etelek.Last();
            Console.WriteLine($"{utolsoEtel.Id} {utolsoEtel.Neve} {utolsoEtel.Kategoria}");

            // Listázzuk azon ételeket amiknek az ára 550 forint
            etelek.Where(x => x.Ara == 550).ToList()
                .ForEach(x => Console.WriteLine($"{x.Neve}: {x.Ara}Ft"));

            // Listázza az összes olyan ételt ami nem leves de az ára 550 forint
            etelek.Where(x => x.Ara == 550 && x.Kategoria != 'L')
                .ToList().ForEach(x => Console.WriteLine($"{x.Neve}: {x.Ara}, {x.Kategoria}"));

            // Legdrágább étel megtalálása
            Etel legdragabb = etelek.OrderByDescending(x => x.Ara).First();
            Console.WriteLine($"{legdragabb.Neve}: {legdragabb.Ara}Ft");

            // Legnagyobb árérték megtalálása
            int maximumAr = etelek.Max(x => x.Ara);
            Console.WriteLine(maximumAr);

            // Írassuk ki melyik kategóriában mennyi étel van
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                kategoriaNeve = x.Key,
                darabszam = x.Count()
            }).ToList().ForEach(x => Console.WriteLine($"{x.kategoriaNeve}: {x.darabszam}"));

            Console.ReadKey();
        }

        static List<Etel> ReadData()
        {
            return File.ReadAllLines("etlap.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Etel()
                {
                    Id=Convert.ToInt32(x[0]),
                    Neve=x[1],
                    Energia=Convert.ToInt32(x[2]),
                    Szenh=Convert.ToInt32(x[3]),
                    Ara=Convert.ToInt32(x[4]),
                    Kategoria=Convert.ToChar(x[5])
                }).ToList();
        }
    }
}
