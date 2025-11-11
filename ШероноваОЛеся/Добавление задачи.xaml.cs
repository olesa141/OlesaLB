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
    /// Логика взаимодействия для Добавление_задачи.xaml
    /// </summary>
    public partial class Добавление_задачи : Window
    {
        public TaskItem NewTask { get; set; }

        public Добавление_задачи()
        {
            InitializeComponent();
            Дата.SelectedDate = DateTime.Today;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int hours = int.Parse((Часы.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "0");
            int minutes = int.Parse((Минуты.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "0");
            TimeSpan time = new TimeSpan(hours, minutes, 0);


            NewTask = new TaskItem
            {
                Title = Название.Text.Trim(),
                Category = Категория.Text.Trim(),
                Description = Описание.Text.Trim(),
                Date = Дата.SelectedDate ?? DateTime.Today,
                Time = time,
                IsCompleted = false
            };
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewTask = null;
            Close();

        }


    }
}
