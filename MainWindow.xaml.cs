using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages;
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
            MainFrame.Navigate(new LoginPage());
            Manager.MainFrame = MainFrame;
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnExit.Visibility = Visibility.Visible;
            }

            else
            {
                BtnExit.Visibility = Visibility.Hidden;
            }

            string currentPage = MainFrame.Content.GetType().Name;

            if (currentPage != "UserPage" && currentPage != "ManagerPage")
            {
                BtnExit.Content = "Назад";
            }
            else
            {
                BtnExit.Content = "Выйти";
            }

        }
    }
}
