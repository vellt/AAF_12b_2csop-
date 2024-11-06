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
using Storage;

namespace Kisertethaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TemaBetoltese();
            temaModositas.Click += TemaModositas_Click;
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
