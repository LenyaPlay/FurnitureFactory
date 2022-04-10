using System;
using System.Collections.Generic;
using System.Data;
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

namespace FurnitureFactory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            DataTable dt = SqlManager.GetSqlConnection().GetSchema("Tables");
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                TableNameComboBox.Items.Add(row[2]);
                i++;

                if (i == 6)
                    break;
            }


        }

        private bool adminFlag = false;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (password.Text != "")
            {
                if (login.Text != "")
                {
                    if ((login.Text == "admin") && (password.Text == "123"))
                    {
                        adminFlag = true;
                        MessageBox.Show("Вход выполнен от имени администратора");
                    }
                    else
                    {
                        MessageBox.Show("Данные некорректны");
                    }
                }
                else
                {
                    MessageBox.Show( "Введите логин");
                }
            }
            else
            {
                MessageBox.Show("Введите пароль");
            }
        }

        private void OpenTable(object sender, RoutedEventArgs e)
        {
            if (!adminFlag)
            {
                MessageBox.Show("Войдите как администратор");
                return;
            }
            if (TableNameComboBox.Items.Contains(TableNameComboBox.Text))
            {
                UniversalTableEditingWindow w = new UniversalTableEditingWindow();
                w.SetTable(TableNameComboBox.Text);
                w.Show();
            }
        }

        private void OpenFurniture(object sender, RoutedEventArgs e)
        {
            UniversalTableEditingWindow w = new UniversalTableEditingWindow();
            w.SetTable("furniture");
            w.Show();
        }

        private void OpenStaffs(object sender, RoutedEventArgs e)
        {
            UniversalTableEditingWindow w = new UniversalTableEditingWindow();
            w.SetTable("staff");
            w.Show();
        }
    }
}
