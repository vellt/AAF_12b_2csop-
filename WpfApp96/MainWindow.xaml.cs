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

namespace WpfApp96
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            kep.MouseEnter += Kep_MouseEnter;
            randomHely(kep); // induláskor véletlenszerűen helyezzel el a képet
        }

        private void Kep_MouseEnter(object sender, MouseEventArgs e)
        {
            // kép elhelyezése valahová
            randomHely(sender as Image);

            // plusz két random elhelyezett kép
            for (int i = 0; i < 2; i++) // 2x fut le
            {
                // létrehozunk egy képet
                Image image = new Image();
                image.Width = 200;
                image.Height = 200;
                image.Source = new BitmapImage(new Uri("egg.png", UriKind.Relative));
                image.MouseEnter += Kep_MouseEnter; // ez a kép is plusz kettőt elkészít

                tarolo.Children.Add(image); // az elkészített képet a canvasba helyezi
                randomHely(image); // véletlenszerűen elhelyezzük a hozzáadott képet
            }
        }

        private void randomHely(Image image)
        {
            int x = r.Next(Convert.ToInt32(SystemParameters.PrimaryScreenWidth - image.Width + 1));
            int y = r.Next(Convert.ToInt32(SystemParameters.PrimaryScreenHeight - image.Height + 1));
            Canvas.SetLeft(image, x);
            Canvas.SetTop(image, y);
        }
    }
}
