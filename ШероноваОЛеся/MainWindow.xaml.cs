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
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = Поччта.Text.Trim().ToLower(); // Замените txtEmail на имя вашего TextBox для email
            string password = Ппароль.Text.Trim(); // Замените txtPassword на имя вашего PasswordBox

            if (!Validation.IsValidEmail(email))
            {
                MessageBox.Show("Некорректный email.", "Ошибка");
                return;
            }

            if (!Validation.IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка");
                return;
            }
            try
            {
                var user = UR.UserAuthenticate(email, password);
                Main_empty main_Empty = new Main_empty();
                main_Empty.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
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
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Введите почту"; 
                tb.Foreground = Brushes.Gray; 
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите почту") 
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black; 
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void Ппароль_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = "Введите пароль";
                tb.Foreground = Brushes.Gray;
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Введите пароль")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }
    }
}