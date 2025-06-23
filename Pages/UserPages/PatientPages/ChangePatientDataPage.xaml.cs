using MedicalLaboratory.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalLaboratory.Pages.UserPages.PatientPages
{
    /// <summary>
    /// Логика взаимодействия для ChangePatientDataPage.xaml
    /// </summary>
    public partial class ChangePatientDataPage : Page
    {
        public ChangePatientDataPage()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadUserData()
        {
            if (Patient.currentPatient != null)
            {
                BurthDateBox.Text = Patient.currentPatient.BurthDate.ToShortDateString();
                PassportBox.Text = Patient.currentPatient.Passport;
                EmailBox.Text = Patient.currentPatient.Email;
                InsuranceNumberBox.Text = Patient.currentPatient.InsuranceNumber;
                InsuranceTypeBox.Text = Patient.currentPatient.InsuranceType;
                InsuranceCompanyBox.Text = Patient.currentPatient.InsuranceCompany;
            }
            PhoneNumberBox.Text = User.currentUser.PhoneNumber;
        }

        private void SaveUserDataChanges()
        {
            using (SqlConnection connection = new SqlConnection(Manager.patientConnectionString))
            {
                string query = "";
            }
        }
    }
}
