using MedicalLaboratory.Classes;
using System.Windows;
using System.Windows.Controls;
using MedicalLaboratory.Pages.UserPages.AdminPages;

namespace MedicalLaboratory.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            Manager.AdminFrame = AdminFrame;
            Manager.CurrentPageName = "Администратор";
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AdminOrdersPage());
        }

        private void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new AcountsPage());
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.AdminFrame.Navigate(new ServicesPage());
        }
    }
}
