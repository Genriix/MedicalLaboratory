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
        public static Frame MainFrame { get; set; }
    }
}
