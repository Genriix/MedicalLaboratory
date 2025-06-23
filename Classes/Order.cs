using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MedicalLaboratory.Classes
{
    internal class Order
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime CreationDate { get; set; }
        public float ExecutionTime { get; set; }

        public List<OrderService> OrderServices { get; set; }


        public static Order SelectedOrder = new Order();

        public static List<Order> GetOrdersFromDB()
        {
            List<OrderService> orderServices = OrderService.GetOrderServicesFromDB();

            List<Order> orders = new List<Order>(); // Все Order из БД

            string query = "Select * from [Order]";

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
                        ExecutionTime = reader["execution_time"] != DBNull.Value ? (float)reader["execution_time"] : 0,
                        OrderServices = orderServices.Where(os => os.OrderId == (int)reader["ID"]).ToList(),
                    });
                }
            }
            return orders;
        }
    }
}
