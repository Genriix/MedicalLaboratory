using MedicalLaboratory.Classes;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для Acounts.xaml
    /// </summary>
    public partial class AcountsPage : Page
    {
        public AcountsPage()
        {
            InitializeComponent();
            LoadAccounts();
        }
        private void LoadAccounts()
        {
            var accounts = User.GetUsersFromDB();
            AccountsItemsControl.ItemsSource = accounts;
        }
    }
}
