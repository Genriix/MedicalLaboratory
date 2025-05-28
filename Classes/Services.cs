using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MedicalLaboratory.Classes
{
    internal class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public static List<Services> GetServicesFromDB()
        {
            List<Services> services = new List<Services>();

            string query = "Select ID, name, cost from Service";

            using (SqlConnection connection = new SqlConnection(Manager.guestConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    services.Add(new Services
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Cost = (decimal)reader["Cost"],
                    });
                }
            }
            return services;
        }

        public static void AddService(Button button)
        {
            // Получаем объект Services, привязанный к этому элементу
            Services selectedService = (Services)button.DataContext;

            ShoppingCart.selectedServices.Add(selectedService);
        }

        public static void RemoveService(Button button)
        {
            Services selectedService = (Services)button.DataContext;

            ShoppingCart.selectedServices.Remove(selectedService);
        }
    }
}
