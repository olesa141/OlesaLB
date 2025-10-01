using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ШероноваОЛеся
{
    internal class Validation
    {
        // Валидация email
        // Ссылка: 2
        public static bool ValidateEmail(string email)
        {
            // Паттерн для проверки email (ваш более корректный вариант)
            // Соответствует формату: что-то@что-то.что-то
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Добавлен ^ и $ для начала и конца строки
            return Regex.IsMatch(email, pattern);
        }

        // Валидация пароля
        // Ссылка: 2
        public static bool ValidatePassword(string password)
        {
            // Пароль должен быть не пустым и иметь длину не менее 6 символов
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }

        // Валидация имени
        // Ссылка: 1
        public static bool ValidateName(string name)
        {
            // Имя должно быть не пустым и содержать не менее 3 знаков
            return !string.IsNullOrEmpty(name) && name.Length >= 3;
        }

        // Метод для отображения сообщения об ошибке
        // Ссылка: 5
        public static void ShowError(TextBox textBox, string errorMessage)
        {
            // Важно: проверка на null, чтобы избежать ошибок, если textBox еще не инициализирован
            if (textBox != null)
            {
                textBox.Text = errorMessage;
            }
        }
    }
}
