using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public string AnalyzerTypeName => Service?.AnalyzerType?.Name ?? "N/A";

        public Status Status { get; set; }
        public Service Service { get; set; }

        public static List<OrderService> GetOrderServicesFromDB()
        {
            List<OrderService> orderServices = new List<OrderService>();

            List<Status> status = Status.GetStatusesFromDB();
            List<Service> service = Service.GetServicesFromDB();

            string query = @"Select * from Order_Service";

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

                        Status = status.FirstOrDefault(s => s.Id == (int)reader["Status_ID"]),
                        Service = service.FirstOrDefault(s => s.Id == (int)reader["Service_ID"]),
                    });
                }
            }
            return orderServices;
        }
    }
}
