using MedicalLaboratory.Classes;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            var services = Service.GetServicesFromDB();
            ServicesItemsControl.ItemsSource = services;
        }

    }
}
