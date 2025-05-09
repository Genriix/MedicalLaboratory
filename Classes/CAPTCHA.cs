using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratory.Classes
{
    internal class CAPTCHA
    {
        public string CapIn { get; set; }
        public string CapOut { get; set; }

        public bool CaptchaIsGenerate { get; set; } // Создаём приватное поле с типом данных true/false
        private string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789"; // Создаём константу с буковами и цыферами
            StringBuilder sb = new StringBuilder(); // Инициализируем экземпляр класса СтрингБилдер
            Random random = new Random(); // Инициализируем экземпляр класса Рандом

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]); // Добавляем в экземпляр класса стирнгБилдер заданное количество случайных цыфарок и буковок
            }
            CaptchaIsGenerate = true;
            return sb.ToString(); // Возвращаем строковую случайную последовательность символов
        }
        public string GenerateRandomSequence()
        {
            string randomSequence = GenerateRandomString(4); // Инициализируем экемпляр функции генерации случайной последовательности символов
            return randomSequence; // Записываем экземпляр функции в текстбокс
        }

        public bool CheckSequence()
        {
            /// Сравниваем один тестбокс с другим
            if (CapOut == CapIn) { return true; } // Если да, то возвращаем тру
            else { return false; } // Если нет, то нет
        }
    }
}
