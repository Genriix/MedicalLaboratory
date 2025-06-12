using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class Patient
    {
        public int Id {  get; set; }
        public int UserId { get; set; }

        public static Patient currentPatient = new Patient();

        public static List<Patient> GetPatientsFromDB()
        {
            List<Patient> patients = new List<Patient>();

            string query = "Select * from Patient";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        Id = (int)reader["ID"],
                        UserId = (int)reader["User_Id"],
                    });
                }
            }
            return patients;
        }

        public void LogOutPatient()
        {
            Id = 0;
            UserId = 0;
        }
    }
}
