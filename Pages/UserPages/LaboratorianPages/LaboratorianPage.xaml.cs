using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages.UserPages.AdminPages;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для LaboratorianPage.xaml
    /// </summary>
    public partial class LaboratorianPage : Page
    {
        public LaboratorianPage()
        {
            InitializeComponent();
            Manager.LaboratorianFrame = LaboratorianFrame;
            Manager.CurrentPageName = "Лаборант";
        }
        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.LaboratorianFrame.Navigate(new AdminOrdersPage());
        }
    }
}
