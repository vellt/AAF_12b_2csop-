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
using System.IO;
using System.Windows.Shapes;

namespace WpfApp67
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> szovegek = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            button.Click += Button_Click;
            szovegek = File.ReadAllLines("meme_szovegek.csv").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int index = r.Next(szovegek.Count);
            szoveg.Text = szovegek[index];

            int index2 = r.Next(1, 70);
            kep.Source = new BitmapImage(new Uri($"kepek/{index2}.jpg",UriKind.Relative));
        }
    }
}
