using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Storage
{
    public enum Themes { Dark, Light }
    public class Theme
    {
        public static Themes Read()
        {
            if (File.Exists("theme.txt"))
            {
                string theme = File.ReadAllText("theme.txt");
                if (theme == "Dark") return Themes.Dark;
                else return Themes.Light;
            }
            else
            {
                return Themes.Light; // alapértelmezés
            }
        }
        public static void Write(Themes theme)
        {
            File.WriteAllText("theme.txt", theme.ToString());
        }
    }
    public class Score
    {
        public static int Read()
        {
            if (File.Exists("score.txt"))
            {
                string score = File.ReadAllText("score.txt");
                return Convert.ToInt32(score);
            }
            else
            {
                return 0; // default
            }
        }

        public static void Write(int record)
        {
            File.WriteAllText("score.txt", record.ToString());
        }
    }
}
