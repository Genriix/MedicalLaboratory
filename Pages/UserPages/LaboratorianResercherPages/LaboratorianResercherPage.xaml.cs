using MedicalLaboratory.Classes;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для LaboratorianResercherPage.xaml
    /// </summary>
    public partial class LaboratorianResercherPage : Page
    {
        public LaboratorianResercherPage()
        {
            InitializeComponent();
            Manager.LaboratorianResercherFrame = LaboratorianResercherFrame;
            Manager.CurrentPageName = "Лаборант-исследователь";
        }
    }
}
