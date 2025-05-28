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
        }

        private void LoadServices()
        {
            var services = Services.GetServicesFromDB();
            ServicesItemsControl.ItemsSource = services;
        }

        private void SelectServiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, которая вызвала событие
            Button button = (Button)sender;
            Services.AddService(button);
        }
    }
}
