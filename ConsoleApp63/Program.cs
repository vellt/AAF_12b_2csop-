using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63
{
    enum KedvencHelyek { RegiKastely, Temeto, ElhagyatottHaz, Erdo, Alagut}
    enum SzellemFajtak { Kisertet, Kopogoszellem, Arnyek, Demonszellem, Koborlelek}
    class Szellem
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public SzellemFajtak Fajta { get; set; }
        public KedvencHelyek KedvencHely { get; set; }
        public DateTime HalalIdopont { get; set; }
        public bool Veszelyes => Fajta == SzellemFajtak.Demonszellem;
        public bool Artalmatlan => Fajta == SzellemFajtak.Koborlelek || Fajta == SzellemFajtak.Kisertet;
        public bool Felelmetes => Fajta == SzellemFajtak.Kopogoszellem || Fajta == SzellemFajtak.Arnyek;

        public override string ToString()
        {
            return $"{Id} {Nev} {Fajta} {HalalIdopont.ToShortDateString()} {Veszelyes} {Artalmatlan} {Felelmetes}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Szellem> szellemek = new List<Szellem>()
            {
                new Szellem
                {
                    Id = 1,
                    Fajta = SzellemFajtak.Demonszellem,
                    HalalIdopont = new DateTime(2018, 10, 18),
                    KedvencHely = KedvencHelyek.Alagut,
                    Nev = "Jezus Szive",
                },
                new Szellem
                {
                    Id = 2,
                    Fajta = SzellemFajtak.Arnyek,
                    HalalIdopont = new DateTime(1018, 10, 18),
                    KedvencHely = KedvencHelyek.Alagut,
                    Nev = "Denes",
                },
                new Szellem
                {
                    Id = 3,
                    Fajta = SzellemFajtak.Kisertet,
                    HalalIdopont = new DateTime(1700, 10, 18),
                    KedvencHely = KedvencHelyek.Erdo,
                    Nev = "Casper",
                },
                new Szellem
                {
                    Id = 4,
                    Fajta = SzellemFajtak.Koborlelek,
                    HalalIdopont = new DateTime(1600, 10, 18),
                    KedvencHely = KedvencHelyek.Temeto,
                    Nev = "Gatya Atya",
                },
            };

            // az összes szellem listázva(foreach)
            szellemek.ForEach(x => Console.WriteLine(x));

            // elhalálozás szerint rendezd növekvő sorrendbe(orderBy)
            szellemek.OrderBy(x => x.HalalIdopont).ToList()
                .ForEach(x => Console.WriteLine(x));

            // Az összes olyan szellem aki temetőben kísért(where)
            szellemek.Where(x=>x.KedvencHely==KedvencHelyek.Temeto).ToList()
                .ForEach(x => Console.WriteLine(x));

            // van olyan szellem aki régi kastélyban kísért, de ártalmatlan? (Exists)
            bool van = szellemek.Exists(x => x.Artalmatlan == true && x.KedvencHely==KedvencHelyek.RegiKastely);
            Console.WriteLine(van ? "van" : "nincs");

            // az összes szellem darabszáma(count)
            int db = szellemek.Count();
            Console.WriteLine(db);

            // Az összes veszélyes és félelmetes szellem(where)
            szellemek.Where(x=>x.Veszelyes==true || x.Felelmetes==true).ToList()
                 .ForEach(x => Console.WriteLine(x));

            // A legrégebben meghalt szellem(orderBy--> first)
            Szellem sz= szellemek.OrderBy(x => x.HalalIdopont).First();
            Console.WriteLine(sz);

            // Az első szellem ártalmatlan szellem?
            bool artalmatlan= szellemek.First().Artalmatlan;
            Console.WriteLine(artalmatlan ? "igen" : "nem");

            // Állapítsd meg, melyik szellem típus a legritkább a listában
            //(ami a legkevesebb előfordulással rendelkezik), és írd ki a nevét.
            List<int> dbk = new List<int>()
            {
                szellemek.Where(x => x.Veszelyes == true).Count(),
                szellemek.Where(x => x.Artalmatlan == true).Count(),
                szellemek.Where(x => x.Felelmetes == true).Count()
            };
            Console.WriteLine(dbk.OrderBy(x=>x).First());

            // Listázd ki az összes félelmetes szellem nevét és halál időpontját.
            szellemek.Where(x => x.Felelmetes == true).ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} {x.HalalIdopont.ToShortDateString()}"));

            // Listázd ki annak az ártalmatlan szellemnek a nevét és halál időpontját, aki a legrégebben halt meg.
            Szellem oreg=  szellemek.Where(x => x.Artalmatlan == true).First();
            Console.WriteLine($"{oreg.Nev} {oreg.HalalIdopont.ToShortDateString()}");

            // Állapítsd meg, ki az a veszélyes szellem, aki a legutóbb halt meg, és írd ki a nevét.
            Szellem veszSz= szellemek.Where(x => x.Veszelyes == true).OrderBy(x => x.HalalIdopont).Last();
            Console.WriteLine(veszSz.Nev);

            // Számold ki a temetőben kísértő szellemek átlagos halálozási évét.
            double atlag= szellemek.Where(x => x.KedvencHely == KedvencHelyek.Temeto).Average(x => x.HalalIdopont.Year);
            Console.WriteLine(atlag);

            // Számold meg, hány szellem kísért az elhagyatott házban, és írd ki a nevüket.
            szellemek.Where(x => x.KedvencHely == KedvencHelyek.ElhagyatottHaz).ToList()
                .ForEach(x => Console.WriteLine(x.Nev));

            // Listázd ki a legutóbbi 3 halálesetet(legújabb 3 szellem) a nevükkel és halál időpontjukkal.
            szellemek.OrderByDescending(x => x.HalalIdopont).Take(3).ToList()
                .ForEach(x => Console.WriteLine($"{x.Nev} {x.HalalIdopont.ToShortDateString()}"));

            //Számold ki az összes szellem átlagos halálozási évét.
            double atlag2= szellemek.Average(x => x.HalalIdopont.Year);
            Console.WriteLine(atlag2);

            Console.ReadKey();
        }
    }
}
