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
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        public HotelPage()
        {
            InitializeComponent();
            DGridHotel.ItemsSource = Tour_GOBOEntities1.GetContext().hotels.ToList();
        }

        private void DGridHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as hotel));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotel.SelectedItems.Cast<hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующиe {(hotelsForRemoving.Count())} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Tour_GOBOEntities1.GetContext().hotels.RemoveRange(hotelsForRemoving);
                    Tour_GOBOEntities1.GetContext().SaveChanges();

                    DGridHotel.ItemsSource = Tour_GOBOEntities1.GetContext().hotels.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
 
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Tour_GOBOEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotel.ItemsSource = Tour_GOBOEntities1.GetContext().hotels.ToList();
            }
        }
    }
}
