﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MedicalLaboratory.Classes
{
    internal class Service
    {
        public int Id { get; set; }
        public int AnalyzerTypeId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public float ResultMin { get; set; }
        public float ResultMax { get; set; }

        public AnalyzerType AnalyzerType { get; set; }

        public static List<Service> GetServicesFromDB()
        {
            List<Service> services = new List<Service>();

            List<AnalyzerType> analyzerTypes = AnalyzerType.GetAnalyzerTypesFromDB();

            string query = "Select Service.*, Analyzer_Type.name as analyzer_name from Service join Analyzer_Type on Service.Analyzer_Type_ID = Analyzer_Type.ID";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    services.Add(new Service
                    {
                        Id = (int)reader["ID"],
                        AnalyzerTypeId = (int)reader["Analyzer_Type_ID"],
                        Name = reader["name"].ToString(),
                        Cost = (decimal)reader["cost"],
                        ResultMin = reader["result_min"] != DBNull.Value ? (float)reader["result_min"] : 0,
                        ResultMax = reader["result_max"] != DBNull.Value ? (float)reader["result_max"] : 0,
                        AnalyzerType = analyzerTypes.FirstOrDefault(at => at.Id == (int)reader["Analyzer_Type_ID"]),
                    });
                }
            }
            return services;
        }
    }
}
