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

namespace WpfApp69
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            csuszka.ValueChanged += Csuszka_ValueChanged;
        }

        private void Csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            eletkor.Text = $"Életkor: {csuszka.Value}";
            // kiürítjük a nézeten a nyakakat
            nyakak.Children.Clear(); 
            // ciklussal felépítjük a szükséges mennyiségű nyakat
            for (int i = 0; i < csuszka.Value; i++)
            {
                Image nyak = new Image();
                nyak.Source = new BitmapImage(new Uri("nyak.png", UriKind.Relative));
                nyakak.Children.Add(nyak);
            }
        }
    }
}
