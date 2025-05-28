using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class Order
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public DateTime creation_date { get; set; }
        public List<Services> services = new List<Services>();

        public static List<Order> GetOrdersFromDB()
        {
            List<Order> orders = new List<Order>();

            string query = "Select ID, Patient_ID, creation_date from [Order]";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        id = (int)reader["ID"],
                        patient_id = (int)reader["Patient_ID"],
                        creation_date = (DateTime)reader["creation_date"],
                    });
                }
            }
            return orders;
        }
        private static List<Services> GetOrder_ServicesFromDB()
        {
            List<Services> services = new List<Services>();

            // Дописать вложенный запрос

            string query = "Select Service_ID from Order_Service WHERE Order_ID = @ID";

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
    }
}
