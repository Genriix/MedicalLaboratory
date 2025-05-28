using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages;
using MedicalLaboratory.Pages.SystemPages;
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
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                Manager.MainFrame.GoBack();
            }
            else
            {

            }
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            string currentPage = MainFrame.Content.GetType().Name;

            if (currentPage != "MainMenu")
            {
                BtnExit.Content = "Назад";
            }
            else
            {
                BtnExit.Content = "Выйти";
            }

        }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoginPage());
        }
    }
}
