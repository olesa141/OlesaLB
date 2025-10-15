
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

using static ШероноваОЛеся.Validation;


namespace ШероноваОЛеся
{
   
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        UserRepository UR = new UserRepository();
        Validation Validate = new Validation();
        public Registration()
        {
            InitializeComponent();
        }
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            string username = Имя.Text.Trim().ToLower();
            string email = Почта.Text;
            string password = Пароль.Text.Trim();
            string confirmPassword = Пароль2.Text.Trim();

            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return; // Прерываем выполнение метода, если поля не заполнены
            }

            // Валидация полей (если все поля заполнены)
            string errorMessage;
            if (!Validation.ValidateAllFields(email, password, username, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                return; // Прерываем выполнение метода, если валидация не прошла
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return; // Прерываем выполнение метода, если пароли не совпадают
            }

            // Добавляем проверку на существование email
            if (UR.EmailExists(email))
            {
                MessageBox.Show("Пользователь с такой почтой уже зарегистрирован.");
                return; // Прерываем выполнение метода, если email уже существует.
            }

            // Попытка регистрации
            if (UR.UserRegistration(username, password, email))  // Порядок параметров был неверным
            {
                // Успешная регистрация
                Main_empty main_empty = new Main_empty();
                main_empty.Show();
                this.Close();
            }
            else
            {
                // Сообщение об ошибке уже отображено в методе UserRegistration
                // Не нужно здесь дополнительно показывать сообщение
                // регистрация не удалась, поэтому ничего не делаем.
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            // Создаем и показываем окно Main_empty
            MainWindow mainEmptyWindow = new MainWindow();
            mainEmptyWindow.Show();

            // Опционально: закрыть текущее окно (Registration)
            this.Close();
            
        }

        private void BackToLogIn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void TBUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Имя.Text == "Введите имя пользователя")
            {
                Имя.Text = string.Empty;
            }
        }

        private void TBUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Имя.Text))
            {
                Имя.Text = "Введите имя пользователя";
            }
        }

        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Почта.Text == "Введите почту")
            {
                Почта.Text = string.Empty;
            }
        }

        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Почта.Text))
            {
                Почта.Text = "Введите почту";
            }
        }

        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Пароль.Text == "Введите пароль")
            {
                Пароль.Text = string.Empty;
            }
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Пароль.Text))
            {
                Пароль.Text = "Введите пароль";
            }
        }

        private void TBRepeatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Пароль.Text == "Повторите пароль")
            {
                Пароль.Text = string.Empty;
            }
        }

        private void TBRepeatPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Пароль.Text))
            {
                Пароль.Text = "Повторите пароль";
            }
        }

        private void Имя_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ИмяЛост(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Введите имя пользователя";
                tb.Foreground = Brushes.Gray;
            }
        }
        private void ИмяГот(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите имя пользователя")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void Почта_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ПочтаЛост(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Введите почту";
                tb.Foreground = Brushes.Gray;
            }
        }
        private void ПочтаГот(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите почту")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void Пароль_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ПарольЛост(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Введите пароль";
                tb.Foreground = Brushes.Gray;
            }
        }
        private void ПарольГот(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите пароль")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void Пароль2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Пароль2Лост(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Повторите пароль";
                tb.Foreground = Brushes.Gray;
            }
        }
        private void Пароль2Гот(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Повторите пароль")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }
    }

}


    
