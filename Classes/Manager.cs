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
        public static string connectionString = "Data Source=DESKTOP-5CVQU3F\\SQLEXPRESS;Initial Catalog=Laboratory;Integrated Security=True";
        public static Frame MainFrame { get; set; }
    }
}
