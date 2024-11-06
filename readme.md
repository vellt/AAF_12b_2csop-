```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{
    enum Italok { Viz, Kola, Narancs, Limonade }
    class Palack
    {
        public int Id { get; set; }
        public double KiszerelesLiter { get; set; }
        public bool KupakRogzitveVan => PalackozasIdeje.Year >= 2023;
        public DateTime PalackozasIdeje { get; set; }
        public Italok Tartalom { get; set; }
        public bool Visszavalthato => PalackozasIdeje.Year >= 2024;

        public override string ToString()
        {
            return $"{Id} {KiszerelesLiter} {KupakRogzitveVan} {PalackozasIdeje.ToShortDateString()} {Tartalom} {Visszavalthato} ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Palack> palackok = new List<Palack>()
            {
                new Palack()
                {
                    Id=1,
                    KiszerelesLiter=1.0,
                    PalackozasIdeje=new DateTime(2020,10,02),
                    Tartalom=Italok.Kola
                },
                new Palack()
                {
                    Id=2,
                    KiszerelesLiter=0.75,
                    PalackozasIdeje=new DateTime(2024,10,02),
                    Tartalom=Italok.Limonade
                },
                new Palack()
                {
                    Id=3,
                    KiszerelesLiter=1.75,
                    PalackozasIdeje=new DateTime(2024,10,02),
                    Tartalom=Italok.Viz
                },
                new Palack()
                {
                    Id=4,
                    KiszerelesLiter=0.25,
                    PalackozasIdeje=new DateTime(2023,10,02),
                    Tartalom=Italok.Narancs
                },
            };
            // első palackom
            Console.WriteLine($"Az első palackom: { palackok.First()}");
            // utolsó palackom
            Console.WriteLine($"utolsó palackom: {palackok.Last()}");
            // hány literesek átlagosan a palackjaim
            Console.WriteLine($"Átlagos kiszerelés: {palackok.Average(x => x.KiszerelesLiter)}");
            // mennyi a legnagyobb palackom kiszerelése
            Console.WriteLine($"Legnagyobb kiszereles: {palackok.Max(x => x.KiszerelesLiter)}");
            // mennyi a legkisebb palackom kiszerelése
            Console.WriteLine($"Legkisebb kiszereles: {palackok.Min(x => x.KiszerelesLiter)}");
            // Írasd ki az összes visszaváltható palackot
            Console.WriteLine($"Visszavalthato: {palackok.Where(x=> x.Visszavalthato==true)}");
            Console.ReadKey();
        }
    }
}

```