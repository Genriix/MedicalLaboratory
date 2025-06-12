using MedicalLaboratory.Classes;
using System;
using System.Data.SqlClient;
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
            Service selectedService = (Service)button.DataContext;
            ShoppingCart.RemoveService(selectedService);
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

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            PushOrderToDB();
        }

        private void PushOrderToDB()
        {
            using (SqlConnection connection = new SqlConnection(Manager.patientConnectionString))
            {
                if (Patient.currentPatient.Id != 0)
                {
                    int patientId = Patient.currentPatient.Id;
                    DateTime creationDate = DateTime.Now;
                    int orderId;

                    connection.Open();

                    string query = @"
                        INSERT INTO [Order] (Patient_ID, creation_date)
                        OUTPUT INSERTED.ID
                        VALUES (@patientId, @creationDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        command.Parameters.AddWithValue("@creationDate", creationDate);

                        orderId = (int)command.ExecuteScalar();
                    }

                    query = @"
                        INSERT INTO Order_Service (Order_ID, Service_ID, Status_ID)
                        VALUES (@orderId, @serviceId, 1)";

                    for (int i = 0; i < ShoppingCart.selectedServices.Count; i++)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@orderId", orderId);
                            command.Parameters.AddWithValue("@serviceId", ShoppingCart.selectedServices[i].Id);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо зарегистрироваться или авторизироваться!");
                }
            }
        }
    }
}
