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

namespace ШероноваОЛеся
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = Поччта.Text; // Замените txtEmail на имя вашего TextBox для email
            string password = Ппароль.Text; // Замените txtPassword на имя вашего PasswordBox

            // Здесь должна быть логика проверки email и пароля
            // Например, сравнение с фиксированными значениями:
            if (email == "olesa@gmail.com" && password == "123")
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
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ваш код для обработки события TextChanged
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр окна регистрации
            Registration registrationWindow = new Registration();

            // Показываем окно регистрации
            registrationWindow.Show();

            // Опционально: закрыть текущее окно (MainWindow) после открытия окна регистрации
            this.Close();
        }

        public static implicit operator MainWindow(Registration v)
        {
            throw new NotImplementedException();
        }
    }
}
