using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
using TaskManager_2.DB_data;

namespace TaskManager_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Refresh();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;
            EditTask editTask = new EditTask(id);
            if (editTask.ShowDialog() == true)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            toDoTasks.ItemsSource = null;
            wrkInPrgsTasks.ItemsSource = null;
            doneTasks.ItemsSource = null;

            List<DB_data.Task> toDoList = new List<DB_data.Task>();
            List<DB_data.Task> WIPList = new List<DB_data.Task>();
            List<DB_data.Task> doneList = new List<DB_data.Task>();

            using (MainContext db = new MainContext())
            {
                var tasks = db.Tasks.ToList();

                for (int ind = 0; ind < tasks.Count; ind++)
                {
                    if (tasks[ind].FulfillmentType == 0)
                    {
                        toDoList.Add(tasks[ind]);
                    }
                    else if(tasks[ind].FulfillmentType == 1)
                    {
                        WIPList.Add(tasks[ind]);
                    }
                    else if(tasks[ind].FulfillmentType == 2)
                    {
                        doneList.Add(tasks[ind]);
                    }
                }
            }

            toDoTasks.ItemsSource = toDoList;
            wrkInPrgsTasks.ItemsSource= WIPList;
            doneTasks.ItemsSource = doneList;
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            var tag = int.TryParse(((Button)sender).Tag.ToString(), out int id);

            EditTask editTask = new EditTask(id);
            if (editTask.ShowDialog() == true)
            {
                Refresh();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var tag = int.TryParse(((Button)sender).Tag.ToString(), out int id);

            using(MainContext db = new MainContext())
            {
                DB_data.Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
                if (task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }

                Refresh();
            }
        }

        private void ToWIP_Click(object sender, RoutedEventArgs e)
        {
            var tag = int.TryParse(((Button)sender).Tag.ToString(), out int id);

            using(MainContext db = new MainContext())
            {
                DB_data.Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
                if (task != null)
                {
                    task.FulfillmentType = 1;
                    db.SaveChanges();
                }

                Refresh();
            }
        }
    }
}
