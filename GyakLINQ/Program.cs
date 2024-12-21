using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakLINQ
{
    enum Mufajok { Rock, Pop, Elektronikus }
    class Album
    {
        public int Id { get; set; }
        public int Kor => DateTime.Now.Year - MegjelenesEve;
        public int MegjelenesEve { get; set; }
        public Mufajok Mufaj { get; set; }
        public string Nev { get; set; }

        public override string ToString()
        {
            return $"{Id} {Kor} {MegjelenesEve} {Mufaj} {Nev}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Album> albumok = new List<Album>()
            {
                new Album()
                {
                    Id=1,
                    Nev="Egy almafa",
                    Mufaj=Mufajok.Rock,
                    MegjelenesEve=2022,
                },
                new Album()
                {
                    Id=2,
                    Nev="Sandstorm",
                    MegjelenesEve=2008,
                    Mufaj=Mufajok.Elektronikus,
                }
            };

            // Mennyi 20 évnél öregebb album van a zeneboltban?
            int db= albumok.Where(x => x.Kor > 20).Count();
            Console.WriteLine(db);

            // Van olyan Elektronikus műfajú album a zeneboltban, amelynek a nevében
            // szerepel “Nevermind” szó ?
            bool van= albumok.Exists(x => x.Mufaj == Mufajok.Elektronikus && x.Nev.Contains("Nevermind"));
            Console.WriteLine(van ? "van" : "nincs");

            // Listázd a boltban lévő albumokat kiadás éve szerint növekvő sorrendben.
            albumok.OrderBy(x => x.MegjelenesEve).ToList().ForEach(x => Console.WriteLine(x));

            // Mennyi pop album van a boltban?
            int db2= albumok.Count(x => x.Mufaj == Mufajok.Pop);
            Console.WriteLine(db2);

            // Átlagosan hány évesek az albumok?
            double atlag= albumok.Average(x => x.Kor);
            Console.WriteLine(atlag);

            // Listázd ki az első 3 legrégebbi albumot.
            albumok.OrderByDescending(x=>x.Kor).Take(3).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
