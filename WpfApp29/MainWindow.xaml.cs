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

namespace WpfApp29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomSzam = new Random().Next(1, 11); //[1,10]
        public MainWindow()
        {
            InitializeComponent();
            csuszka.ValueChanged += Csuszka_ValueChanged;
            gomb.Click += Gomb_Click;
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            int tipp = Convert.ToInt32(csuszkaErtek.Text);
            if (tipp==randomSzam)
            {
                MessageBox.Show("Eltaláltad!");
            }
            else if(tipp<randomSzam)
            {
                MessageBox.Show("Én ettől nagyobbra gondoltam");
            }
            else
            {
                MessageBox.Show("Én ettől kisebbre gondoltam");
            }
        }

        private void Csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            csuszkaErtek.Text = csuszka.Value.ToString();
        }
    }
}
