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
        // ... (другие методы) ...

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            // Проверка по паттерну "*@*.*"
            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex <= 0 || dotIndex <= atIndex + 1 || dotIndex == email.Length - 1)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }

        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3;
        }

        // Метод для валидации всех полей сразу
        public static bool ValidateAllFields(string email, string password, string name, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsValidEmail(email))
            {
                errorMessage = "Некорректный формат email (должен содержать '@' и '.').";
                return false;
            }
            if (!IsValidPassword(password))
            {
                errorMessage = "Пароль должен содержать не менее 6 символов.";
                return false;
            }
            if (!IsValidName(name))
            {
                errorMessage = "Имя должно содержать не менее 3 символов.";
                return false;
            }

            return true; // Все поля валидны
        }
    }
}