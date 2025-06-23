using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class UserType
    {
        public int Id;
        public string Name;

        public static List<UserType> GetUserTypesFromDB()
        {
            List<UserType> userTypes = new List<UserType>();

            string query = "SELECT * FROM User_Type";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userTypes.Add(new UserType
                    {
                        Id = (int)reader["ID"],
                        Name = (string)reader["name"],
                    });
                }
            }
            return userTypes;
        }
    }
}
