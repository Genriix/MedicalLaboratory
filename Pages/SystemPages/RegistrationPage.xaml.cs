using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages.UserPages;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.SystemPages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        StringBuilder error = new StringBuilder();
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void RegistratePatientButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (IsDataCorrect())
            {
                PushUserToBD();
            }
        }
        private void PushUserToBD()
        {
            using (SqlConnection connection = new SqlConnection(Manager.patientConnectionString))
            {
                string[] full_name = FullNameBox.Text.Split(' ');

                connection.Open();
                string query = @"
                            INSERT INTO [User] (User_Type_ID, login, password, f_name, l_name, m_name, phone_number)
                            VALUES (4, @login, @password, @f_name, @l_name, @m_name, @phone_number)";

                if (full_name.Length == 2)
                {
                    query = @"
                            INSERT INTO [User] (User_Type_ID, login, password, f_name, l_name, phone_number)
                            VALUES (4, @login, @password, @f_name, @l_name, @phone_number)";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", LoginBox.Text);
                    command.Parameters.AddWithValue("@password", PasswordPasswordBox.Password);
                    command.Parameters.AddWithValue("@f_name", full_name[1]);
                    command.Parameters.AddWithValue("@l_name", full_name[0]);
                    if (full_name.Length == 3)
                    {
                        command.Parameters.AddWithValue("@m_name", full_name[2]);
                    }
                    command.Parameters.AddWithValue("@phone_number", PhoneNumberBox.Text);
                    
                    command.ExecuteNonQuery();
                }

                User.currentUser = User.GetUsersFromDB().FirstOrDefault(u => u.Login == LoginBox.Text);
                MessageBox.Show("Вы зарегистрировались как пользователь");
                Manager.MainFrame.Navigate(new PatientPage());
            }
        }

        private bool IsDataCorrect()
        {
            error.Clear();

            if (!(Regex.IsMatch(FullNameBox.Text, @"^[а-яА-Я]* [а-яА-Я]* [а-яА-Я]*$") || Regex.IsMatch(FullNameBox.Text, @"^[а-яА-Я]* [а-яА-Я]*$")))
            {
                error.AppendLine("Проверьте ФИО");
            }
            if (!Regex.IsMatch(LoginBox.Text, @"^[a-zA-Z0-9_]{8,16}$"))
            {
                error.AppendLine("Проверьте логин");
            }
            if (!Regex.IsMatch(PhoneNumberBox.Text, @"^8912\d{7}$"))
            {
                error.AppendLine("Проверьте номер телефона");
            }
            if (!Regex.IsMatch(PasswordPasswordBox.Password, @"^[a-zA-Z0-9_]{8,16}$"))
            {
                error.AppendLine("Проверьте пароль");
            }
            if (PasswordPasswordBox.Password != ConfirmPasswordPasswordBox.Password)
            {
                error.AppendLine("Пароль и пароль-подтверждение не совпадают");
            }

            if (error.Length != 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            return true;
        }
    }
}
