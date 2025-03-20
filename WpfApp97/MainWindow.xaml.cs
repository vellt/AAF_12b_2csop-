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

namespace WpfApp97
{
    class Karakter
    {
        public string Name { get; set; }
        public string House { get; set; }
        public int YearOfBirth { get; set; }
        public string Image { get; set; }
        public int Strong { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb.ItemsSource = ReadData();
            cb.DisplayMemberPath = "Name";
            cb.SelectionChanged += Cb_SelectionChanged;
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Karakter kivalasztottKarakter=(sender as ComboBox).SelectedItem as Karakter;
            nev.Text = kivalasztottKarakter.Name;
            haz.Text = $"Ház: {kivalasztottKarakter.House}";
            ev.Text = $"Születési év: {kivalasztottKarakter.YearOfBirth}";
            erosseg.Children.Clear();
            for (int i = 0; i < kivalasztottKarakter.Strong; i++)
            {
                Image img = new Image();
                img.Width = 40;
                img.Margin = new Thickness(5);
                img.Source = new BitmapImage(new Uri("images/strong.png", UriKind.Relative));
                // hozzáadjuk
                erosseg.Children.Add(img);
            }
        }

        List<Karakter> ReadData()
        {
            return File.ReadAllLines("harry_potter_characters_hu.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Karakter()
                {
                    Name=x[0],
                    House=x[1],
                    YearOfBirth=Convert.ToInt32(x[2]),
                    Image=x[3],
                    Strong=Convert.ToInt32(x[4])
                }).ToList();

        }
    }
}
