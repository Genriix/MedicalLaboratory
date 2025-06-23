using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class AnalyzerType
    {
        public int Id;
        public string Name;

        public static List<AnalyzerType> GetAnalyzerTypesFromDB()
        {
            List<AnalyzerType> analyzerType = new List<AnalyzerType>();

            string query = "SELECT * FROM Analyzer_Type";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    analyzerType.Add(new AnalyzerType
                    {
                        Id = (int)reader["ID"],
                        Name = (string)reader["name"],
                    });
                }
            }
            return analyzerType;
        }
    }
}
