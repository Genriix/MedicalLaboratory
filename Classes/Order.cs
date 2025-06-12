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
        public List<Service> Services = new List<Service>();
        public string ServicesName { get; set; }

        public static List<Order> GetOrdersFromDB()
        {
            List<Order> orders = new List<Order>(); // Все Order из БД

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

            List<Service> service = Service.GetServicesFromDB();

            for (int i = 0; orders.Count > i; i++)
            {
                orders[i].OrderServices = OrderService.GetOrderServicesFromDB(orders[i].Id);

                if (orders[i].OrderServices != null && orders[i].OrderServices.Count > 0)
                {
                    orders[i].Services.Clear();

                    foreach (var orderService in orders[i].OrderServices)
                    {
                        Service foundService = service.FirstOrDefault(s => s.Id == orderService.ServiceId);
                        if (foundService != null)
                        {
                            orders[i].Services.Add(foundService);
                        }
                    }
                    orders[i].ServicesName = string.Join(", ", orders[i].Services.Select(s => s.Name));
                }

                //    for (int j = 0; orders[i].OrderServices.Count > j; j++)
                //{
                //    orders[i].Services.Add(service.FirstOrDefault(s => s.Id == orders[i].OrderServices[j].ServiceId));
                //    orders[i].ServicesName = orders[i].Services[j].Name;
                //}
            }

            return orders;
        }
    }
}
