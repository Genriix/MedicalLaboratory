using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class OrderService
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public int StatusId { get; set; }
        public int LaboratorianId { get; set; }
        public DateTime DateAdmissionToAnalyzer { get; set; }
        public float ExecutionTime { get; set; }
        public string ReserchingResults { get; set; }
        public string StatusName { get; set; }

        public static List<OrderService> GetOrderServicesFromDB()
        {
            List<OrderService> orderServices = new List<OrderService>();

            string query = "Select Order_Service.*, Status.name from Order_Service join Status on Status_ID = Status.ID";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orderServices.Add(new OrderService
                    {
                        OrderId = (int)reader["Order_ID"],
                        ServiceId = (int)reader["Service_ID"],
                        DateOfAdmission = reader["date_of_admission"] != DBNull.Value ? (DateTime)reader["date_of_admission"] : DateTime.MinValue,
                        StatusId = (int)reader["Status_ID"],
                        LaboratorianId = reader["Laboratorian_ID"] != DBNull.Value ? (int)reader["Laboratorian_ID"] : 0,
                        DateAdmissionToAnalyzer = reader["date_admission_to_analyzer"] != DBNull.Value ? (DateTime)reader["execution_time"] : DateTime.MinValue,
                        ExecutionTime = reader["execution_time"] != DBNull.Value ? (float)reader["execution_time"] : 0,
                        ReserchingResults = reader["reserching_results"] != DBNull.Value ? (string)reader["reserching_results"] : "null",
                        StatusName = reader["name"].ToString(),
                    });
                }
            }
            return orderServices;

        }
    }
}
