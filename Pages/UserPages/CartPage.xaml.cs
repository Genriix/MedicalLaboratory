using MedicalLaboratory.Classes;
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

namespace MedicalLaboratory.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            var services = ShoppingCart.selectedServices;

            CartItemsControl.ItemsSource = services;
        }

        private void RemoveService_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Services.RemoveService(button);
            CartItemsControl.Items.Refresh();
        }
    }
}
