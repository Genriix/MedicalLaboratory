using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicalLaboratory.Classes
{
    internal static class ShoppingCart
    {
        public static List<Service> selectedServices = new List<Service>();
        public static void AddService(Button button)
        {
            // Получаем объект Services, привязанный к этому элементу
            Service selectedService = (Service)button.DataContext;
            selectedServices.Add(selectedService);
        }

        public static void RemoveService(Button button)
        {
            Service selectedService = (Service)button.DataContext;
            selectedServices.Remove(selectedService);
        }

    }
}
