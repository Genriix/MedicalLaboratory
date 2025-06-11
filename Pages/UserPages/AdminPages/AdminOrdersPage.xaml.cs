using MedicalLaboratory.Classes;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class AdminOrdersPage : Page
    {
        public AdminOrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }
        private void LoadOrders()
        {
            var orders = Order.GetOrdersFromDB();
            OrderItemsControl.ItemsSource = orders;
        }
    }
}
