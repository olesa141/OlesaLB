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
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
             // Получаем данные из текстовых полей
            string userName = Имя.Text;
            string email = Почта.Text;
            string password = Пароль.Text;
            string confirmPassword = Пароль2.Text;

            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return; // Прерываем выполнение метода, если поля не заполнены
            }

            // Валидация полей (если все поля заполнены)
            string errorMessage;
            if (Validation.ValidateAllFields(email, password, userName, out errorMessage))
            {
                // Сравниваем пароли
                if (password == confirmPassword)
                {
                    // Создаем и показываем окно Main_empty
                    Main_empty mainEmptyWindow = new Main_empty();
                    mainEmptyWindow.Show();

                    // Опционально: закрыть текущее окно (Registration)
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик нажатия кнопки "Назад" (если нужно)
            this.Close(); //Просто закрываем окно регистрации.
        }
    }
}