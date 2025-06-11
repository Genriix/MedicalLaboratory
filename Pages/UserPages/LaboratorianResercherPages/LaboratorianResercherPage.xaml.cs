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
