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
using System.Windows.Shapes;

namespace ШероноваОЛеся
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        // Обработчик потери фокуса для поля Email
        // Ссылка: 1
        private void EmailValidation(object sender, RoutedEventArgs e) // Используем RoutedEventArgs, если это потеря фокуса
        {
            TextBox txt = (TextBox)sender; // Приводим отправителя к TextBox
            if (!Validation.ValidateEmail(txt.Text)) // Используем метод из класса Validation
            {
                Validation.ShowError(txt, "Неверный формат email"); // Отображаем ошибку
            }
            else
            {
                // Очищаем поле с ошибкой, если ввод корректен
                txt.Text = ""; // Или можно оставить введенный текст, если он корректен
            }
        }

        // Обработчик потери фокуса для поля Пароль
        // Ссылка: 1
        private void PasswordValidation(object sender, RoutedEventArgs e) // Используем RoutedEventArgs
        {
            TextBox txt = (TextBox)sender;
            if (!Validation.ValidatePassword(txt.Text))
            {
                Validation.ShowError(txt, "Пароль должен быть не менее 6 символов");
            }
            else
            {
                txt.Text = ""; // Очистка при корректном вводе
            }
        }

        // Обработчик потери фокуса для поля Имя (Новый метод)
        // Ссылка: 1 (примерная, аналогично другим)
        private void NameValidation(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!Validation.ValidateName(txt.Text))
            {
                Validation.ShowError(txt, "Имя должно содержать не менее 3 знаков");
            }
            else
            {
                txt.Text = ""; // Очистка при корректном вводе
            }
        }

        // Обработчик события для кнопки "Зарегистрироваться" (пример)
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь будет логика регистрации:
            // 1. Собрать все данные из TextBox'ов (email, password, name)
            // 2. Повторно проверить их на валидность (если нужно)
            // 3. Если все валидно, выполнить регистрацию (например, отправить на сервер, сохранить в базу и т.д.)
            // 4. Если есть ошибки, показать их с помощью Validation.ShowError()

            string email =Почта.Text;
            string password = Пароль.Text;
            string name = Имя.Text;

            // Пример полной проверки при нажатии кнопки
            bool isEmailValid = Validation.ValidateEmail(email);
            bool isPasswordValid = Validation.ValidatePassword(password);
            bool isNameValid = Validation.ValidateName(name);

            if (!isEmailValid)
            {
                Validation.ShowError(Почта, "Неверный формат email");
            }
            if (!isPasswordValid)
            {
                Validation.ShowError(Пароль, "Пароль должен быть не менее 6 символов");
            }
            if (!isNameValid)
            {
                Validation.ShowError(Имя, "Имя должно содержать не менее 3 знаков");
            }

            if (isEmailValid && isPasswordValid && isNameValid)
            {
                MessageBox.Show("Регистрация прошла успешно!");
                // Здесь может быть переход на другое окно или закрытие текущего
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Логика для кнопки "Назад"
            // Например, закрытие текущего окна или переход на предыдущее
            this.Close();
        }
    }
}
