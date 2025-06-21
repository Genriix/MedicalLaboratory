using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MedicalLaboratory.Classes
{
    internal class Patient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BurthDate { get; set; }
        public string Passport { get; set; }
        public string Email { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceType { get; set; }
        public string InsuranceCompany { get; set; }

        public static Patient currentPatient;

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
                        BurthDate = (DateTime)reader["burth_date"],
                        Passport = (string)reader["passport"],
                        Email = (string)reader["email"],
                        InsuranceNumber = reader["insurance_number"] != DBNull.Value ? (string)reader["insurance_number"] : "Н/Д",
                        InsuranceType = reader["insurance_type"] != DBNull.Value ? (string)reader["insurance_type"] : "Н/Д",
                        InsuranceCompany = reader["insurance_company"] != DBNull.Value ? (string)reader["insurance_company"] : "Н/Д",
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
