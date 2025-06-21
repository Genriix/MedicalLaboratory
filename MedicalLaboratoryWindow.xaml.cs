using MedicalLaboratory.Classes;
using MedicalLaboratory.Pages;
using MedicalLaboratory.Pages.SystemPages;
using MedicalLaboratory.Pages.UserPages;
using System;
using System.Windows;

namespace MedicalLaboratory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MedicalLaboratoryWindow : Window
    {
        public MedicalLaboratoryWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainMenu());
            Manager.MainFrame = MainFrame;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack && IsCurrentPageNoUser())
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

            if (MainFrame.CanGoBack && currentPage != "MainMenu")
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
                Cart.Visibility = Visibility.Collapsed;
            }
            else
            {
                Cart.Visibility = Visibility.Collapsed;
            }

            if (ShoppingCart.selectedServices.Count == 0)
            {
                Cart.Visibility = Visibility.Collapsed;
            }
            else
            {
                Cart.Content = $"Корзина ({ShoppingCart.selectedServices.Count})";
            }

            if (User.currentUser.UserId != 0)
            {
                LogIn_Button.Content = "Открыть";
                LogOut_Button.Visibility = Visibility.Visible;
            }
            else
            {
                LogIn_Button.Content = "Войти";
                LogOut_Button.Visibility = Visibility.Collapsed;
            }

            if (!IsCurrentPageNoUser())
            {
                LogIn_Button.Visibility = Visibility.Collapsed;
            }
            else
            {
                LogIn_Button.Visibility = Visibility.Visible;
            }

            if (currentPage == "LoginPage")
            {
                ShowBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowBorder.Visibility = Visibility.Visible;
            }

            CurrentPageBlock.Text = Manager.CurrentPageName;
        }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            if (User.currentUser.UserId == 0)
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

        private bool IsCurrentPageNoUser()
        {
            string currentPage = GetCurrentPage();
            return currentPage != "AdminPage" && currentPage != "LaboratorianPage" && currentPage != "LaboratorianResercherPage" && currentPage != "PatientPage";
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CartPage());
        }

        private void ShowBorder_Click(object sender, RoutedEventArgs e)
        {
            HiddenBorderPopup.IsOpen = !HiddenBorderPopup.IsOpen;
        }

        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            User.currentUser.LogOutUser();
            if (GetCurrentPage() != "MainMenu")
            {
                Manager.MainFrame.Navigate(new MainMenu());
            }
            else { Manager.MainFrame.NavigationService.Refresh(); }
        }
    }
}
