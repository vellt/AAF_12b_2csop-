using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp68
{
    enum Markak {BMW,Audi,Volkswagen,Skoda,Suzuki }
    enum Uzemanyagok { Benzin, Dizel, Elektromos, Hibrid}
    class Auto
    {
        public int GyartasiEv { get; set; }
        public int Id { get; set; }
        public int Kor => DateTime.Now.Year - GyartasiEv;
        public Markak Marka { get; set; }
        public string Rendszam { get; set; }
        public bool UjRendszam => Rendszam.Length != 7;
        public Uzemanyagok Uzemanyag { get; set; }

        public override string ToString()
        {
            return $"{GyartasiEv} {Id} {Kor} {Marka} {Rendszam} {UjRendszam} {Uzemanyag}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>()
            {
                new Auto()
                {
                    Id=1,
                    GyartasiEv=2020,
                    Marka=Markak.Skoda,
                    Rendszam="PETI-123",
                    Uzemanyag=Uzemanyagok.Elektromos,
                },
                new Auto()
                {
                    Id=2,
                    GyartasiEv=2010,
                    Marka=Markak.Suzuki,
                    Rendszam="ABC-123",
                    Uzemanyag=Uzemanyagok.Dizel,
                },
                new Auto()
                {
                    Id=3,
                    GyartasiEv=2005,
                    Marka=Markak.BMW,
                    Rendszam="ABB-123",
                    Uzemanyag=Uzemanyagok.Dizel,
                },
                new Auto()
                {
                    Id=4,
                    GyartasiEv=2000,
                    Marka=Markak.Audi,
                    Rendszam="AAB-123",
                    Uzemanyag=Uzemanyagok.Benzin,
                },
            };

            // első autó
            Auto elso= autok.First();
            Console.WriteLine(elso);

            // az első ujrendszámos autó
            Auto elsoUj= autok.Where(x => x.UjRendszam == true).First();
            Console.WriteLine(elsoUj);

            // első elektromos
            Auto elsoElektromos= autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos).First();
            Console.WriteLine(elsoElektromos);

            // utolsó autó
            Auto utolso= autok.Last();
            Console.WriteLine(utolso);

            // utolsó audi
            Auto utolsoAudi = autok.Where(x => x.Marka == Markak.Audi).Last();
            Console.WriteLine(utolsoAudi);

            // hány évesek átlagosan az autók
            double atlag = autok.Average(x => x.Kor);
            Console.WriteLine(atlag);

            // mennyi idős a legidősebb autó
            Auto legidosebb = autok.OrderBy(x => x.Kor).Last();
            Console.WriteLine(legidosebb.Kor);

            // mikor gyártották a legidősebb autót
            Console.WriteLine(legidosebb.GyartasiEv);

            // írasd ki az összes új rendszámos autót
            autok.Where(x => x.UjRendszam == true).ToList().ForEach(x => Console.WriteLine(x));

            // írasd ki az összes benzines autót
            autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin).ToList()
                .ForEach(x => Console.WriteLine(x));

            // írasd ki az összes BMW-t,amely benzines
            autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin && x.Marka == Markak.BMW)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írasd ki az összes 2007-nél újabb modellt
            autok.Where(x => x.GyartasiEv > 2007).ToList().ForEach(x => Console.WriteLine(x));

            // Melyik az első autó,amely 5 évesnél idősebb?
            Auto elsoOtEvesAuto = autok.Where(x => x.Kor > 5).First();
            Console.WriteLine(elsoOtEvesAuto);

            // Hány elektromos autó van a listában?
            int db = autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos ).Count();
            Console.WriteLine(db);

            // Létezik-e a listában olyan autó, amelynek a gyártási éve 2010 előtti
            bool vanE = autok.Exists(x => x.GyartasiEv < 2010);
            Console.WriteLine(vanE ? "Van" : "Nincs");

            // írd ki a 2015 után gyártott autókat rendszám szerint rendezve
            autok.Where(x => x.GyartasiEv > 2015).OrderBy(x=>x.Rendszam)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Az utolsó benzines autó a listában
            Auto utolsobenzines = autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin).Last();
            Console.WriteLine(utolsobenzines);

            // Hány új rendszámos autó van a listában
            int d = autok.Where(x => x.UjRendszam == true).Count();
            Console.WriteLine(d);

            // Az 5 legfiatalabb autó a listából (kor szerint növekvő sorrendben)
            autok.OrderBy(x => x.Kor).Take(5).ToList().ForEach(x => Console.WriteLine(x));

            // Írd ki az összes autót, amely 2000 és 2010 között készült (gyártási év szerint rendezve)!
            autok.Where(x => x.GyartasiEv > 2000 && x.GyartasiEv < 2010).OrderBy(x=> x.GyartasiEv)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Hány olyan autó van, amely nem benzines?
            int szamol = autok.Where(x => x.Uzemanyag != Uzemanyagok.Benzin).Count();
            Console.WriteLine(szamol);

            // Van-e a listában olyan autó, amelynek rendszáma "AAAA-123"?
            bool vanER = autok.Exists(x => x.Rendszam == "AAAA-123");
            Console.WriteLine(vanER? "Van" : "Nincs");

            // Hány autó készült 2020 után?
            int hanyAuto = autok.Where(peti => peti.GyartasiEv > 2020).Count();
            Console.WriteLine(hanyAuto);

            // Az összes autó, amelynek a rendszámában van a "123" szöveg.
            autok.Where(x => x.Rendszam.Contains("123"))
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írd ki az összes autót, amelyik Audi vagy BMW márkájú!
            autok.Where(x=>x.Marka==Markak.Audi || x.Marka==Markak.BMW)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Létezik-e olyan autó, amely pontosan 3 éves?
            bool letezik= autok.Exists(x => x.Kor == 3);
            Console.WriteLine(letezik?"igen":"nem");

            // Hány autó készült 2000 előtt?
            int db3= autok.Where(x => x.GyartasiEv < 200).Count();
            Console.WriteLine(db3);

            //Hány olyan autó van, amelynek a rendszáma "B" betűvel kezdődik?
            int db4= autok.Where(x => x.Rendszam.StartsWith("B")).Count();
            Console.WriteLine(db4);

            // Melyik az első olyan autó, amelynek a gyártási éve páros szám?
            Auto elsoParos= autok.Where(x => x.GyartasiEv % 2 == 0).First();
            Console.WriteLine(elsoParos);

            // Az autók száma, amelynek a gyártási éve páratlan szám!
            int db5 = autok.Where(x => x.GyartasiEv % 2 != 0).Count();
            Console.WriteLine(db5);

           

            Console.ReadKey();
        }
    }
}
