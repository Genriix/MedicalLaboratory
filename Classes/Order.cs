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
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime CreationDate { get; set; }

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
                        Id = (int)reader["ID"],
                        PatientId = (int)reader["Patient_ID"],
                        CreationDate = (DateTime)reader["creation_date"],
                    });
                }
            }
            return orders;
        }
    }
}
