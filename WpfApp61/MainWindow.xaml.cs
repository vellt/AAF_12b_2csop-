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

namespace WpfApp61
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sorszam = 1;
        public MainWindow()
        {
            InitializeComponent();
            elore.Click += Elore_Click;
            vissza.Click += Vissza_Click;
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            if (sorszam>1)
            {
                sorszam--;
            }
            else
            {
                sorszam = 5;
            }
            kep.Source = new BitmapImage(new Uri($"0{sorszam}.jpg", UriKind.Relative));
        }

        private void Elore_Click(object sender, RoutedEventArgs e)
        {
            if (sorszam<5)
            {
                sorszam++;
            }
            else
            {
                // kezdjük előlről
                sorszam = 1;
            }
            kep.Source = new BitmapImage(new Uri($"0{sorszam}.jpg", UriKind.Relative));
        }
    }
}
