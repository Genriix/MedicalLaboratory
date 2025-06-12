using MedicalLaboratory.Classes;
using System.Collections.Generic;
using System.Linq;
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

            List<Order> patientOrders = Order.GetOrdersFromDB().Where(order => order.PatientId == Patient.currentPatient.Id).ToList();
            OrderItemsControl.ItemsSource = patientOrders;
        }
    }
}
