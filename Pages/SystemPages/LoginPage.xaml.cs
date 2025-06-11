using MedicalLaboratory.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLaboratory.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static StringBuilder errors = new StringBuilder();
        private readonly CAPTCHA captcha = new CAPTCHA();

        public LoginPage()
        {
            InitializeComponent();
            CapOut.IsEnabled = false; // Делаем текстбокс не активным
            captcha.CaptchaIsGenerate = false; // Мы не проходили капчу
            Manager.CurrentPageName = null;
        }

        private void GenerateRandomSequence(object sender, RoutedEventArgs e)
        {
            CapOut.Text = captcha.GenerateRandomSequence();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.currentUser.FoundUser(Login.Text, Password.Password.ToString());
            //CaptchaTest();
            if (IsErrorsEmpty())
            {
                Manager.NavigateUserToHisPage();
                Login.Text = "";
                Password.Password = "";
                CapOut.Text = "";
                CapIn.Text = "";
                captcha.CaptchaIsGenerate = false;
            }
            else
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа");
                CapOut.Text = "";
                CapIn.Text = "";
            }
            errors.Clear();
        }

        private bool IsErrorsEmpty()
        {
            return errors.Length == 0;
        }

        private void CaptchaTest()
        {
            captcha.CapOut = CapOut.Text;
            captcha.CapIn = CapIn.Text;
            if (captcha.CaptchaIsGenerate == false) // Капча не была сгенерирована
            {
                errors.AppendLine("Пройдите тест CAPTCHA");
            }
            else if (captcha.CheckSequence() != true) // Или капча была пройдена не верно
            {
                errors.AppendLine("Повторите тест CAPTCHA");
            }
        }
    }
}
