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

namespace _123
{
    /// <summary>
    /// Логика взаимодействия для TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        public TourPage()
        {
            InitializeComponent();
            var currentTours = Tour_GOBOEntities1.GetContext().Tour_.ToList();
            LViewTours.ItemsSource = currentTours;

            var allTypes = Tour_GOBOEntities1.GetContext().Types.ToList();
            allTypes.Insert(0, new Type
            {
                name = "Все типы"
            });
            ComboType
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
