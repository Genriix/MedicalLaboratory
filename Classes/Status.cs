using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Status> GetStatusesFromDB()
        {
            List<Status> statuses = new List<Status>();

            string query = "SELECT * FROM Status";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    statuses.Add(new Status
                    {
                        Id = (int)reader["ID"],
                        Name = (string)reader["name"],
                    });
                }
            }
            return statuses;
        }
    }
}
