using MedicalLaboratory.Classes;
using System.Windows;
using System.Windows.Controls;

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
            LoadCost();
            Manager.CurrentPageName = "Корзина";
        }
        private void LoadServices()
        {
            var services = ShoppingCart.selectedServices;
            CartItemsControl.ItemsSource = services;
        }

        private void RemoveService_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ShoppingCart.RemoveService(button);
            CartItemsControl.Items.Refresh();
            LoadCost();
        }
        private void LoadCost()
        {
            decimal finalCost = 0;
            for (int i = 0; i < ShoppingCart.selectedServices.Count; i++) 
            {
                Service service = ShoppingCart.selectedServices[i];
                finalCost += service.Cost;
            }
            FinalCost.Text = $"{(float)finalCost}₽";
        }
    }
}
