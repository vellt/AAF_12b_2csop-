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

namespace WpfApp14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            novel.Click += Novel_Click;
            csokken.Click += Csokken_Click;
        }

        private void Csokken_Click(object sender, RoutedEventArgs e)
        {
            int sz = Convert.ToInt32(szam.Text);
            szam.Text = (--sz).ToString();
        }

        private void Novel_Click(object sender, RoutedEventArgs e)
        {
            int sz = Convert.ToInt32(szam.Text);
            szam.Text = (++sz).ToString();
        }
    }
}
