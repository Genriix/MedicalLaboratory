using MedicalLaboratory.Pages.UserPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalLaboratory.Classes
{
    internal class Manager
    {
        // Для тестирования
        //public static string connectionString = "Data Source=DESKTOP-5CVQU3F\\SQLEXPRESS;Initial Catalog=Laboratory;Integrated Security=True";
        // Для публикации
        public static string guestConnectionString = "Data Source=tcp:26.199.117.108,33678;Initial Catalog=Laboratory;User ID=LaboratoryGuest;Password=Q]a2/6BqG@:H@g]N;Persist Security Info=True;";
        public static string adminConnectionString = "Data Source=tcp:26.199.117.108,33678;Initial Catalog=Laboratory;User ID=LaboratoryAdmin;Password=rj8QEU)Qf%sYu~7+;Persist Security Info=True;";
        public static Frame MainFrame { get; set; }
        public static Frame AdminFrame { get; set; }
        public static Frame LaboratorianFrame { get; set; }
        public static Frame LaboratorianResercherFrame { get; set; }
        public static string CurrentPageName { get; set; }
        public static void NavigateUserToHisPage()
        {
            switch (User.currentUser.UserRoleId)
            {
                case 1: MainFrame.Navigate(new AdminPage()); break;
                case 2: MainFrame.Navigate(new LaboratorianPage()); break;
                case 3: MainFrame.Navigate(new LaboratorianResercherPage()); break;
                case 4:
                    {
                        Patient.currentPatient = Patient.GetPatientsFromDB().FirstOrDefault(p => p.UserId == User.currentUser.UserId);
                        MainFrame.Navigate(new PatientPage()); 
                        break;
                    }
            }
        }
    }
}
