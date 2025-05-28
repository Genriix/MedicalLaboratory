using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages;
using MedicalLaboratory.Pages.SystemPages;
using MedicalLaboratory.Pages.UserPages;
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

namespace MedicalLaboratory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainMenu());
            Manager.MainFrame = MainFrame;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            string currentPage = GetCurrentPage();

            if (MainFrame.CanGoBack && (currentPage != "AdminPage" && currentPage != "LaboratorianPage" && currentPage != "LaboratorianResercherPage" && currentPage != "PatientPage"))
            {
                Manager.MainFrame.GoBack();
            }
            else
            {
                MainFrame.Navigate(new MainMenu());
            }
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            string currentPage = GetCurrentPage();

            if (MainFrame.CanGoBack)
            {
                BtnBack.IsEnabled = true;
            }
            else
            {
                BtnBack.IsEnabled = false;
            }

            if (currentPage == "MainMenu" || currentPage == "PatientPage")
            {
                Cart.IsEnabled = true;
                Cart.Visibility = Visibility.Visible;
            }
            else if (currentPage == "CartPage")
            {
                Cart.IsEnabled = false;
                Cart.Visibility = Visibility.Visible;
            }
            else
            {
                Cart.Visibility = Visibility.Collapsed;
            }
        }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            if (User.GetUser_id() == 0)
            {
                Manager.MainFrame.Navigate(new LoginPage());
            }
            else
            {
                Manager.NavigateUserToHisPage();
            }
        }

        private string GetCurrentPage()
        {
            return MainFrame.Content.GetType().Name;
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CartPage());
        }
    }
}
