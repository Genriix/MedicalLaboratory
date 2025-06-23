using MedicalLaboratory.Classes;
using System;
using System.Collections.Generic;
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

namespace MedicalLaboratory.Pages.UserPages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            var orderServices = OrderService.GetOrderServicesFromDB().Where(OS => OS.OrderId == Order.SelectedOrder.Id);
            ServicesItemsControl.ItemsSource = orderServices;

            List<Patient> patients = Patient.GetPatientsFromDB();
            List<User> users = User.GetUsersFromDB();

            User user = users.FirstOrDefault(u => u.UserId == (patients.FirstOrDefault(p => p.Id == Order.SelectedOrder.PatientId).UserId));

            OrderIdBlock.Text = Order.SelectedOrder.Id.ToString();
            PatientName.Text = user.LName + " " + user.FName + " " + user.MName;
            CreationDateBlock.Text = Order.SelectedOrder.CreationDate.ToShortDateString();
            ExecutionTimeBlock.Text = Order.SelectedOrder.ExecutionTime.ToString();
        }
    }
}
