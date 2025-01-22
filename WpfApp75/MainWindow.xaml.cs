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

namespace WpfApp75
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Csokkent.Click += Csokkent_Click;
            Novel.Click += Novel_Click;
        }

        private void Novel_Click(object sender, RoutedEventArgs e)
        {
          
            
            if (Csillagok.Children.Count < 5)
            {
                Image csillag = new Image();
                csillag.Width = 30;
                csillag.Source = new BitmapImage(new Uri("star.png", UriKind.Relative));
                Csillagok.Children.Add(csillag);
            }
        }

        private void Csokkent_Click(object sender, RoutedEventArgs e)
        {

            
            if (Csillagok.Children.Count > 1)
            {
                Csillagok.Children.RemoveAt(0);
            }
        }
    }
}
