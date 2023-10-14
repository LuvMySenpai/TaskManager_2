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
using TaskManager_2.DB_data;

namespace TaskManager_2
{
    /// <summary>
    /// Логика взаимодействия для EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        int _id = -1;
        public EditTask(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void DisplayData()
        {
            using(MainContext db = new MainContext())
            {
                DB_data.Task editedTask = db.Tasks.FirstOrDefault(x => x.Id == _id);
                taskName.Text = editedTask.Name;
                taskDescription.Text = editedTask.Description;
                taskPriority.Text = editedTask.Priority;
                dateChoose.SelectedDate = editedTask.DeadlineDate;
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if(_id == -1)
            {
                MessageBoxResult result = MessageBox.Show("Добавить задание?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using(MainContext db = new MainContext())
                    {
                        DB_data.Task newTask = new DB_data.Task(taskName.Text, taskDescription.Text, DateTime.Now, (DateTime)dateChoose.SelectedDate, taskPriority.Text, 0);
                        db.Tasks.Add(newTask);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Задача добавлена", "Уведомление");
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Изменить задание?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using(MainContext db = new MainContext())
                    {
                        DB_data.Task newTask = new DB_data.Task(taskName.Text, taskDescription.Text, DateTime.Now, (DateTime)dateChoose.SelectedDate, taskPriority.Text, 0);
                        DB_data.Task editedTask = db.Tasks.FirstOrDefault(x => x.Id == _id);
                        if(editedTask != null)
                        {
                            editedTask.Name = taskName.Text;
                            editedTask.Description = taskDescription.Text;
                            editedTask.DeadlineDate = (DateTime)dateChoose.SelectedDate;
                            editedTask.Priority = taskPriority.Text;
                            db.SaveChanges();
                        }
                    }

                    this.DialogResult = true;
                    this.Close();
                    MessageBox.Show("Задача изменена", "Уведомление");
                }
            }
        }
    }
}
