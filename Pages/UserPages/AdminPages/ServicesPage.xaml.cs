using MedicalLaboratory.Classes;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MedicalLaboratory.Pages.UserPages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : System.Windows.Controls.Page
    {
        private List<Service> Services = new List<Service>();
        public ServicesPage()
        {
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            Services = Service.GetServicesFromDB();
            ServicesItemsControl.ItemsSource = Services;
        }

        private void ReportToExcelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateReport();
        }
        private void CreateReport()
        {
            // Проверка наличия данных
            if (Services == null || Services.Count == 0)
            {
                throw new ArgumentException("Список услуг не может быть пустым");
            }

            // Создаем экземпляр Excel
            Application excelApp = new Application();

            try
            {
                // Создаем новую книгу
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                // Устанавливаем заголовки
                worksheet.Cells[1, 1] = "ID";
                worksheet.Cells[1, 2] = "Название";
                worksheet.Cells[1, 3] = "Анализатор";
                worksheet.Cells[1, 4] = "Стоимость";
                worksheet.Cells[1, 5] = "Результат мин.";
                worksheet.Cells[1, 6] = "Результат макс.";

                // Заполняем данные
                for (int i = 0; i < Services.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = Services[i].Id;
                    worksheet.Cells[i + 2, 2] = Services[i].Name;
                    worksheet.Cells[i + 2, 3] = Services[i].AnalyzerType.Name;
                    worksheet.Cells[i + 2, 4] = Services[i].Cost;
                    worksheet.Cells[i + 2, 5] = Services[i].ResultMin;
                    worksheet.Cells[i + 2, 6] = Services[i].ResultMax;
                }

                // Форматируем заголовки
                Range headerRange = worksheet.Range["A1:F1"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = XlRgbColor.rgbLightGray;

                // Автоподбор ширины столбцов
                worksheet.Columns.AutoFit();

                // Формируем имя файла и путь
                string fileName = $"{DateTime.Now:yyyy.MM.dd_HH.mm.ss}_{User.currentUser.Login}.xlsx";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folderPath = Path.Combine(documentsPath, "MedicalLaboratory");
                Directory.CreateDirectory(folderPath);
                string fullPath = Path.Combine(folderPath, fileName);

                // Сохраняем файл
                workbook.SaveAs(fullPath);
                Console.WriteLine($"Отчет успешно сохранен: {fullPath}");

                // Закрываем workbook перед открытием
                workbook.Close(false);

                // Открываем файл с помощью ассоциированной программы
                Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании отчета: {ex.Message}");
                throw;
            }
            finally
            {
                // Закрываем Excel
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
