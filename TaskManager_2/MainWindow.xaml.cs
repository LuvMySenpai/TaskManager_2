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

            using (MainContext db = new MainContext())
            {
                var tasks = db.Tasks.ToList();
                toDoTasks.ItemsSource = tasks;
            }
        }

        private void testButton_Click_1(object sender, RoutedEventArgs e)
        {
            using (MainContext db = new MainContext())
            {
                DB_data.Task task = new DB_data.Task();
                db.Tasks.Add(task);
            }
        }
    }
}
