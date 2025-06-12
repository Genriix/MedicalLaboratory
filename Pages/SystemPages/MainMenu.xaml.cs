using MedicalLaboratory.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.SystemPages
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            LoadServices();
            Manager.CurrentPageName = "Главная страница";
        }

        private void LoadServices()
        {
            var services = Service.GetServicesFromDB();
            ServicesItemsControl.ItemsSource = services;
        }

        private void SelectServiceButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Service selectedService = (Service)button.DataContext;
            ShoppingCart.AddService(selectedService);
            Manager.MainFrame.NavigationService.Refresh();
        }
    }
}
