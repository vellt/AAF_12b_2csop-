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

namespace WpfApp68
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            szamoljukKi.Click += SzamoljukKi_Click;
        }

        private void SzamoljukKi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a1 = Convert.ToInt32(elsoelem.Text.Trim());
                int q = Convert.ToInt32(hanyados.Text.Trim());
                int n = Convert.ToInt32(sorozathossza.Text.Trim());

                List<double> list = new List<double>();

                for (int i = 0; i < n; i++)
                {
                    double ertek = a1 * Math.Pow(q, i);
                    list.Add(ertek);
                }
                MessageBox.Show(string.Join(" ",list));
            }
            catch (Exception)
            {

                MessageBox.Show("Csak szám bevitel engedélyezett!");
            }
        }
    }
}
