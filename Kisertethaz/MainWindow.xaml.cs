using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using Storage;

namespace Kisertethaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool jatekVege = false;
        int pontszam = 0;
        public MainWindow()
        {
            InitializeComponent();
            TemaBetoltese();
            HatterzeneBetoltese();
            RekordBetoltese();
            temaModositas.Click += TemaModositas_Click;
            ajto1.MouseUp += Ajto1_MouseUp;
            ajto2.MouseUp += Ajto1_MouseUp;
            ajto3.MouseUp += Ajto1_MouseUp;
            ujJatek.Click += UjJatek_Click;
        }

        private void UjJatek_Click(object sender, RoutedEventArgs e)
        {
            SzellemekEltuntetese();
            jatekVege = false;
            pontszam = 0;
            PontszamBetoltese();
        }

        private void SzellemekEltuntetese()
        {
            szellem1.Visibility = Visibility.Hidden;
            szellem2.Visibility = Visibility.Hidden;
            szellem3.Visibility = Visibility.Hidden;
        }

        private void Ajto1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // ez az ajtó nyitás

            if (jatekVege==false)
            {
                // azonosítjuk az ajtót
                int azonosito = Convert.ToInt32((sender as Image).Name.Last().ToString()); // {1, 2, 3}
                int randomSzam = new Random().Next(1, 4); // {1, 2, 3}
                if (azonosito==randomSzam)
                {
                    // itt a szellem--->fuss!!
                    (((sender as Image).Parent as Grid).Children[0] as Image).Visibility = Visibility.Visible;
                    jatekVege = true;
                    PuttyHangLejatszasa();
                }
                else
                {
                    // nem találkoztunk szellemmel
                    PenzHangLejatszasa();
                    pontszam++;
                    PontszamBetoltese();                    
                    if (Score.Read() < pontszam)
                    {
                        Score.Write(pontszam);
                        RekordBetoltese();
                    }
                }

            }
            else
            {
                // VÉGE A JÁTÉKNAK
                // nem nyithatok ajtót
                MessageBox.Show("Kezdj egy új játékot", "Már nem nyithatsz ajtót!");
            }
        }

        private void PontszamBetoltese()
        {
            pontszamSzoveg.Text = $"Pontszámod: {pontszam}";
        }

        private void PuttyHangLejatszasa()
        {
            Uri uri = new Uri("putty.wav", UriKind.Relative);
            MediaPlayer player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }

        private void PenzHangLejatszasa()
        {
            Uri uri = new Uri("points.wav", UriKind.Relative);
            MediaPlayer player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }

        private void RekordBetoltese()
        {
            rekordSzoveg.Text = $"Rekord: {Score.Read()}";
        }

        private void HatterzeneBetoltese()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = "creepy_night.wav";
            player.PlayLooping();
        }

        private void TemaModositas_Click(object sender, RoutedEventArgs e)
        {
            switch (Theme.Read())
            {
                case Themes.Dark:
                    Theme.Write(Themes.Light);
                    break;
                case Themes.Light:
                    Theme.Write(Themes.Dark);
                    break;
            }
            TemaBetoltese();
        }

        private void TemaBetoltese()
        {
            szoveg1.Foreground = (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            szoveg2.Foreground = (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            szoveg3.Foreground = (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            cim.Foreground = (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            this.Background = (Theme.Read() == Themes.Light) ? Brushes.AliceBlue : Brushes.Black; 
        }
    }
}
