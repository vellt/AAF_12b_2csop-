using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hegycsucsokLINQ
{
    class Hegy
    {
        public string HegycsucsNeve { get; set; }
        public string Hegyseg { get; set; }
        public int Magassag { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Hegy> hegyek = ReadDataFromFile();
            Console.WriteLine($"Adatsor: {hegyek.Count()}");

            Console.WriteLine("Adatok:");
            hegyek.Select(x=>$"{x.HegycsucsNeve}, {x.Hegyseg}, {x.Magassag} m")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 01.) Szűrd ki azokat a hegycsúcsokat, 
            // amelyek magassága meghaladja az 900 métert a Bükk-vidéken.
            Console.WriteLine("\n1. feladat");
            hegyek.Where(x => x.Hegyseg == "Bükk-vidék" && x.Magassag > 900)
                .Select(x => x.HegycsucsNeve)
                .ToList().ForEach(x => Console.WriteLine(x));

            // 02.) írd ki a hegységeket duplikáció nélkül
            Console.WriteLine("\n2. feladat");
            hegyek.Select(x => x.Hegyseg).Distinct()
                .ToList().ForEach(x => Console.WriteLine(x));

            // 03.) Számold meg, hány hegycsúcs található a Bükk-vidéken.
            Console.WriteLine("\n3. feladat");
            int db= hegyek.Where(x => x.Hegyseg == "Bükk-vidék").Count();
            Console.WriteLine($"Bükk-vidéki hegységek: {db}db");

            // 04.) Listázd ki a hegycsúcsokat magasság szerint 
            // csökkenő sorrendben.
            Console.WriteLine("\n4. feladat");
            hegyek.OrderByDescending(x => x.Magassag)
                .Select(x => $"{x.HegycsucsNeve}: {x.Magassag}m")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 05.) Keresd meg azokat a hegycsúcsokat, 
            // amelyek nevében szerepel a "kő" szótag.
            Console.WriteLine("\n5. feladat");
            hegyek.Where(x=>x.HegycsucsNeve.Contains("kő"))
                .Select(x=>x.HegycsucsNeve)
                .ToList().ForEach(x => Console.WriteLine(x));

            // 06.) Listázd ki azokat a hegycsúcsokat, 
            // amelyek magassága 800 és 900 méter között van, 
            // és a Bükk - vidéken találhatók.
            Console.WriteLine("\n6. feladat");
            hegyek.Where(x=>x.Magassag>800 && x.Magassag<900 && x.Hegyseg=="Bükk-vidék")
                .Select(x=>$"{x.HegycsucsNeve}: {x.Magassag}m")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 07.) Melyik hegységnek mennyi hegycsúcsa van
            Console.WriteLine("\n7. feladat");
            hegyek.GroupBy(x => x.Hegyseg).Select(x => $"{x.Key}: {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 08.) melyik hegységnek mennyi a legnagyobb magassága
            Console.WriteLine("\n8. feladat");
            hegyek.GroupBy(x=>x.Hegyseg).Select(x=>$"{x.Key}: {x.Max(y=>y.Magassag)}m")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 09.) Hozz létre egy listát azokról a hegycsúcsokról, 
            // amelyek neve több, mint egyszer szerepel a listában, 
            // és mutasd meg ezeket a duplikációkat.
            Console.WriteLine("\n9. feladat");
            hegyek.Where(x => x.HegycsucsNeve.Contains("(2)"))
                .Select(x => x.HegycsucsNeve.TrimEnd("(2)".ToArray()))
                .ToList().ForEach(x => Console.WriteLine(x));

            // 10.) Kérjen be a hegység nevét és listázza a találatokat 
            // továbbá a találatok számát
            Console.WriteLine("\n10. feladat");
            Console.Write("Hegység: ");
            string hegyseg = Console.ReadLine();
            List<Hegy> talalatok= hegyek.Where(x => x.Hegyseg == hegyseg).ToList();
            Console.WriteLine($"Találatok száma: {talalatok.Count()}db");
            talalatok.Select(x => $"{x.HegycsucsNeve}: {x.Magassag}m")
                .ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }

        static List<Hegy> ReadDataFromFile()
        {
            return File.ReadAllLines("hegyek.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Hegy
                {
                    HegycsucsNeve=x[0],
                    Hegyseg=x[1],
                    Magassag=Convert.ToInt32(x[2])
                }).ToList();
        }
    }
}
