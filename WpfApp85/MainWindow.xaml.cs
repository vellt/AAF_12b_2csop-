using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp85
{
    class Dino
    {
        public string Nev { get; set; }
        public string Kep { get; set; }
        public string Leiras { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dinoTallozo.ItemsSource = ReadData();
            dinoTallozo.DisplayMemberPath = "Nev";
            dinoTallozo.SelectedIndex = 0;
            dinoTallozo.SelectionChanged += DinoTallozo_SelectionChanged;
        }

        private void DinoTallozo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        List<Dino> ReadData()
        {
            return File.ReadAllLines("dinok.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Dino()
                {
                    Nev=x[0],
                    Kep=x[1],
                    Leiras=x[2]
                }).ToList();
        }
    }
}
