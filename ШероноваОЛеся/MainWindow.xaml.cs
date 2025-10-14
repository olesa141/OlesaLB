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
using static System.Net.Mime.MediaTypeNames;

namespace ШероноваОЛеся
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserRepository UR = new UserRepository();
        Validation validate = new Validation();
        
        public MainWindow()
        {
            InitializeComponent();
            UR.UserRegistration("olesa", "123456", "olesa@gmail.com");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = Поччта.Text.Trim().ToLower(); // Замените txtEmail на имя вашего TextBox для email
            string password = Ппароль.Text.Trim(); // Замените txtPassword на имя вашего PasswordBox

            // Здесь должна быть логика проверки email и пароля
            // Например, сравнение с фиксированными значениями:
            if (email == "olesa@gmail.com" && password == "123456")
            {
                // Учетные данные верны
                // Создаем экземпляр следующего окна (замените NextWindow на имя вашего класса для следующей формы)
                Main_empty mainEmptyWindow = new Main_empty();

                // Отображаем следующее окно
                mainEmptyWindow.Show();

                // Закрываем текущее окно (опционально)
                this.Close();
            }
            else
            {
                // Неверные учетные данные
                MessageBox.Show("Неверный email или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Registation(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Поччта.Text == "Почта")
            {
                Поччта.Text = string.Empty;
            }
        }

        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Поччта.Text))
            {
                Поччта.Text = "Почта";
            }
        }

        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Ппароль.Text == "Пароль")
            {
                Ппароль.Text = string.Empty;
            }
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Ппароль.Text))
            {
                Ппароль.Text = "Пароль";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}