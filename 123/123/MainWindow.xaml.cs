using System;
using System.Collections.Generic;
using System.IO;
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

namespace _123
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TourPage());
            Manager.MainFrame = MainFrame;
            //ImportTours();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void ButtonHotel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelPage());
        }

        private void MainFrame_CR(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
        }

        //private void ImportTours()
        //{
        //    var fileData = File.ReadAllLines(@"\\FSProfile1.biik.ad.biik.ru\Redirect\eliseikin\Desktop\import до\Туры1.txt");
        //    var images = Directory.GetFiles(@"\\FSProfile1.biik.ad.biik.ru\Redirect\eliseikin\Desktop\import до\Туры фото");

        //    foreach ( var line in fileData)
        //    {
        //        var data = line.Split('\t');

        //        var tempTour = new Tour_
        //        {
        //            name = data[0].Replace("\"", ""),
        //            tickestcount = int.Parse(data[2]),
        //            price = decimal.Parse(data[3]),
        //            isactual = (data[4] == "0") ? false : true
        //        };

        //        foreach (var tourType in data[5].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            var currentType = Tour_GOBOEntities1.GetContext().Types.ToList().FirstOrDefault(p => p.name == tourType);
        //            if(currentType != null)
        //                tempTour.Types.Add(currentType);
        //        }

        //        try
        //        {
        //            tempTour.imagepreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.name)));
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }

        //        Tour_GOBOEntities1.GetContext().Tour_.Add(tempTour);
        //        Tour_GOBOEntities1.GetContext().SaveChanges();
        //    }
        //}


        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
