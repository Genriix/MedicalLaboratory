using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages.UserPages.PatientPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        public PatientPage()
        {
            InitializeComponent();
            Manager.CurrentPageName = "Личный кабинет";

            if (Patient.currentPatient != null)
            {
                List<Order> patientOrders = Order.GetOrdersFromDB().Where(order => order.PatientId == Patient.currentPatient.Id).ToList();
                OrderItemsControl.ItemsSource = patientOrders;
            }

            LoadUserData();
        }
        
        private void LoadUserData()
        {
            Login.Text = User.currentUser.Login;
            PhoneNumber.Text = User.currentUser.PhoneNumber;
            FullName.Text = User.currentUser.LName + " " + User.currentUser.FName + " " + User.currentUser.MName;

            if (Patient.currentPatient != null)
            {
                Email.Text = Patient.currentPatient.Email;
                BurthDate.Text = Patient.currentPatient.BurthDate.ToShortDateString();
                Passport.Text = Patient.currentPatient.Passport;
            }
            else
            {
                Email.Visibility = Visibility.Collapsed;
                BurthDate.Visibility = Visibility.Collapsed;
                Passport.Visibility = Visibility.Collapsed;
            }
        }

        private void ChangeData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ChangePatientDataPage());
        }
    }
}
