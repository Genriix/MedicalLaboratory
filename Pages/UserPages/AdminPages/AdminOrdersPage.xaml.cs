using MedicalLaboratory.Classes;
using System.Collections.Generic;
using System.Linq;
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
            List<Order> orders = Order.GetOrdersFromDB();

            OrderItemsControl.ItemsSource = orders;
        }

        private void OpenOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Order.SelectedOrder = (Order)button.DataContext;
            Manager.MainFrame.Navigate(new OrderPage());
        }
    }
}
