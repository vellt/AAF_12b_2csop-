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

namespace WpfApp76
{
    class Varos
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Varos> varosok = new List<Varos>()
            {
                new Varos() { Name="Berlin",  Value= "Berlin" },
                new Varos() { Name="Tokió",  Value= "Tokyo" },
                new Varos() { Name="Rio",  Value= "Rio" },
                new Varos() { Name="Nairobi",  Value= "Nairobi" },
                new Varos() { Name="Lisszabon",  Value= "Lisbon" },
                new Varos() { Name="Moszkva",  Value= "Moscow" },
                new Varos() { Name="Denver",  Value= "Denver" },
                new Varos() { Name="Stockholm",  Value= "Stockholm" },
                new Varos() { Name="Helsinki",  Value= "Helsinki" },
                new Varos() { Name="Professzor",  Value= "Professor" },
            };

            varosokTallozo.ItemsSource = varosok;
            varosokTallozo.DisplayMemberPath = "Name";
            varosokTallozo.SelectionChanged += VarosokTallozo_SelectionChanged;
        }

        private void VarosokTallozo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string magyar = (varosokTallozo.SelectedItem as Varos).Name;
            string angol = (varosokTallozo.SelectedItem as Varos).Value;
            varosNev.Text = magyar;
            Image image = new Image();
            image.Height = 200;
            image.Source = new BitmapImage(new Uri($"images/{angol}.jpg", UriKind.Relative));
            kep.Children.Clear();
            kep.Children.Add(image);
        }
    }
}
