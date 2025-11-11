using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ШероноваОЛеся
{
    public static class User
    {
        public static string Name { get; set; } = "Пользователь";
        public static string Login { get; set; }
        public static string Email { get; set; }
    }
    public class UserRepository
    {
        private static List<UserModel> registeredUser = new List<UserModel>();

        public bool UserRegistration(string login, string password, string email)
        {
            if (registeredUser.Exists(l => l.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return false;
            }

            var newUser = new UserModel(login, password, email);
            registeredUser.Add(newUser);
            return true;
        }

        public UserModel UserAuthenticate(string email, string password)
        {
            var user = registeredUser.Find(l => l.Email == email && l.Password == password);
            if (user == null)
            {
                throw new Exception("Неверная почта или пароль!");
            }
            return user;
        }

        // Добавляем новый метод для проверки существования email
        public bool EmailExists(string email)
        {
            return registeredUser.Exists(l => l.Email == email);
        }
    }
}