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

namespace WpfApp63
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> uzik = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            gomb.Click += Gomb_Click;
            uzik = File.ReadAllLines("uzik.csv").ToList();
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int index = r.Next(uzik.Count());
            szoveg.Text = uzik[index];
        }
    }
}
