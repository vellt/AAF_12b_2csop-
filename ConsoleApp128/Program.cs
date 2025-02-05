using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp128
{
    class Nobeldijas
    {
        public int Ev { get; set; }
        public string Tipus { get; set; }
        public string Knev { get; set; }
        public string Vnev { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Nobeldijas> adatok = ReadDataFromFile();
            //Mennyi adatsorból áll a fájl?
            Console.WriteLine($"{adatok.Count()} db");

            //Listázd ki az adatsorokat(minden adattagot).
            adatok.Select(x => $"{x.Ev} {x.Tipus} {x.Vnev} {x.Knev}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Rendezd azon Nóbel - díjasokat keresztnév szerint növekvő sorrendbe, 
            //melyek 2014 után kaptak orvosi Nóbel-díjat.
            // A kiíratás Vezetéknév és Keresztnév formájában történjen. 
            adatok.OrderBy(x => x.Knev)
                .Where(x => x.Ev > 2014 && x.Tipus == "orvosi")
                .Select(x => $"{x.Vnev} {x.Knev}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Mennyi típus van(duplikációkat eltünteted, majd megszámolod) ?
            int db =adatok.Select(x => x.Tipus).Distinct().Count();
            Console.WriteLine(db);

            //Listázza ki évszám szerint növekvően az 1960 és 1970 között 
            // irodalmi Nobel - díjat nyert írók nevét(vezetéknév + keresztnév).
            // A vizsgált időszakba a határok is beletartoznak.
            adatok.Where(x => x.Ev >= 1960 && x.Ev <= 1970 && x.Tipus == "irodalmi")
                .OrderBy(x => x.Ev).Select(x => $"Név: {x.Vnev} {x.Knev}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Melyik típusban mennyi Nóbel-díjas van?
            adatok.GroupBy(x => x.Tipus).Select(x => $"típus: {x.Key}, {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Melyik évben mennyi Nóbel - díjas volt ?
            adatok.GroupBy(x => x.Ev).Select(x => $"{x.Key}: {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            //2015 - ben mennyi Nóbel - díjas volt?
            int db2=  adatok.Where(x => x.Ev == 2015).Count();
            Console.WriteLine($"{db2}db");

            // Kérj be egy nevet és listázd azon Nóbel - díjasokat, 
            // akinek az a vezeték vagy keresztneve, amit a felhasználó 
            // adott meg konzolból, a találatok számát is írd ki.
            Console.Write("Név: ");
            string nev = Console.ReadLine();

            List<string> talalatok = adatok.Where(x => x.Knev == nev || x.Vnev == nev)
                .Select(x => $"Név: {x.Vnev} {x.Knev}").ToList();

            Console.WriteLine($"találatok száma: {talalatok.Count()}db");
            talalatok.ForEach(x => Console.WriteLine(x));


            Console.ReadKey();
        }

        static List<Nobeldijas> ReadDataFromFile()
        {
            return File.ReadAllLines("nobeldijak.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Nobeldijas()
                {
                    Ev=Convert.ToInt32(x[0]),
                    Tipus=x[1],
                    Knev=x[2],
                    Vnev=x[3]
                }).ToList();
        }
    }
}
