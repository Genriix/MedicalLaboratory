using System.Collections.Generic;

namespace MedicalLaboratory.Classes
{
    internal static class ShoppingCart
    {
        public static List<Service> selectedServices = new List<Service>();
        public static void AddService(Service selectedService)
        {
            selectedServices.Add(selectedService);
        }

        public static void RemoveService(Service selectedService)
        {
            selectedServices.Remove(selectedService);
        }
    }
}
