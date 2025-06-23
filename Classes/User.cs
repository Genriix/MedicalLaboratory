using MedicalLaboratory.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MedicalLaboratory.Classes
{
    internal class User
    {
        ///  Поля класса User
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        public static User currentUser = new User();

        /// Метод проверки наличия пользователя в базе данных

        public static bool IsUserInBD(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(Manager.guestConnectionString))
            {
                int founded_id = 0;

                connection.Open();

                // Запрос к базе данных
                string query = "SELECT ID, User_Type_ID FROM [User] WHERE Login = @Login";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            founded_id = reader.GetInt32(0); // Получаем значение столбца id
                        }
                        else
                        {
                            LoginPage.errors.AppendLine("Пользователь не найден");

                        }
                    }
                }

                query = "SELECT Password FROM [User] WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", founded_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (password == reader.GetString(0))
                            {
                                return true;
                            }
                            else
                            {
                                LoginPage.errors.AppendLine("Пароль не правильный");
                            }
                        }
                    }
                }
                return false;
            }
        }

        /// Выгрузка пользователей из базы данных
        public static List<User> GetUsersFromDB()
        {
            List<User> users = new List<User>();
            List<UserType> usersType = UserType.GetUserTypesFromDB();

            string query = "Select * from [User]";

            using (SqlConnection connection = new SqlConnection(Manager.adminConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = (int)reader["ID"],
                        UserRoleId = (int)reader["User_Type_ID"],
                        Login = (string)reader["login"],
                        Password = (string)reader["password"],
                        FName = (string)reader["f_name"],
                        LName = (string)reader["l_name"],
                        MName = reader["m_name"] != DBNull.Value ? (string)reader["m_name"] : "",
                        PhoneNumber = (string)reader["phone_number"],
                        UserType = usersType.FirstOrDefault(ut => ut.Id == (int)reader["User_Type_ID"]),
                    });
                }
            }
            return users;
        }
        public void LogOutUser()
        {
            UserId = 0;
            UserRoleId = 0;
            Patient.currentPatient?.LogOutPatient();
        }
    }
}
