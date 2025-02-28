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
using System.Media;

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
        SoundPlayer player = new SoundPlayer();
        bool megyAZene = true; // állapotváltozó
        public MainWindow()
        {
            InitializeComponent();
            dinoTallozo.ItemsSource = ReadData();
            dinoTallozo.DisplayMemberPath = "Nev";
           
            dinoTallozo.SelectionChanged += DinoTallozo_SelectionChanged;
            dinoTallozo.SelectedIndex = 0;
            elozo.Click += Elozo_Click;
            kovetkezo.Click += Kovetkezo_Click;
            kocka.Click += Kocka_Click;

            player.SoundLocation = "africa.wav";
            player.PlayLooping();

            zene.MouseUp += Zene_MouseUp;
        }

        private void Zene_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image ikon= zene.Children[0] as Image;
            if (megyAZene)
            {
                player.Stop();
                megyAZene = false;
                ikon.Source = new BitmapImage(new Uri("images/unmute.png", UriKind.Relative));
            }
            else
            {
                player.PlayLooping();
                megyAZene = true;
                ikon.Source = new BitmapImage(new Uri("images/mute.png", UriKind.Relative));
            }
        }

        private void Kocka_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int index = r.Next(7); //[0,6]
            dinoTallozo.SelectedIndex = index;
        }

        private void DinoTallozo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dino kivalasztottDino = dinoTallozo.SelectedItem as Dino;
            dino1.Source = new BitmapImage(new Uri($"images/{kivalasztottDino.Kep}", UriKind.Relative));
            dino2.Text = kivalasztottDino.Leiras;
            indikator.Text = $"{dinoTallozo.SelectedIndex + 1}/7";
        }

        private void Kovetkezo_Click(object sender, RoutedEventArgs e)
        {
            dinoTallozo.SelectedIndex++;
        }

        private void Elozo_Click(object sender, RoutedEventArgs e)
        {
            if (dinoTallozo.SelectedIndex>0)
            {
                dinoTallozo.SelectedIndex--;
            }
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
