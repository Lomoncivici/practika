using Practoz5.conditerDataSetTableAdapters;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme;

namespace Practoz5
{
    public partial class Employee : Page
    {
        EmployeeTableAdapter Employ = new EmployeeTableAdapter();
        AccountTableAdapter Accountt = new AccountTableAdapter();
        OrdersTableAdapter Orders = new OrdersTableAdapter();
        public Employee()
        {
            InitializeComponent();

            EmployeeTable.ItemsSource = Employ.GetMain();
            AccountID.ItemsSource = Accountt.GetData();
            AccountID.DisplayMemberPath = "AccountID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            EmployeeTable.Columns[1].Visibility = Visibility.Collapsed;
            EmployeeTable.Columns[2].Visibility = Visibility.Collapsed;
            EmployeeTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeTable.SelectedItem as DataRowView != null)
            {
                object id = (EmployeeTable.SelectedItem as DataRowView).Row[0];

                var allID = Orders.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][2].ToString() == id.ToString())
                    {
                        Orders.UpdateQueryEmployee(1, i + 1);
                    }
                }
                Employ.DeleteQuery(Convert.ToInt32(id));
                EmployeeTable.ItemsSource = Employ.GetMain();
                EmployeeTable.Columns[1].Visibility = Visibility.Collapsed;
                EmployeeTable.Columns[2].Visibility = Visibility.Collapsed;
                EmployeeTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(LastName.Text) || string.IsNullOrWhiteSpace(FirstName.Text) || AccountID.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                LastName.BorderBrush = new SolidColorBrush(Colors.Red);
                FirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                AccountID.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr))
            {
                if (!Regex.IsMatch(LastName.Text, @"\d") || !Regex.IsMatch(FirstName.Text, @"\d"))
                {
                    object AcountID = (AccountID.SelectedItem as DataRowView).Row[0];

                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    LastName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    FirstName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    AccountID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    Employ.InsertQuery(Convert.ToInt32(ID.Text), FirstName.Text, LastName.Text, Convert.ToInt32(AcountID));
                    EmployeeTable.ItemsSource = Employ.GetMain();
                    EmployeeTable.Columns[1].Visibility = Visibility.Collapsed;
                    EmployeeTable.Columns[2].Visibility = Visibility.Collapsed;
                    EmployeeTable.Columns[3].Visibility = Visibility.Collapsed;
                }
                else
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    LastName.BorderBrush = new SolidColorBrush(Colors.Red);
                    FirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                    AccountID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                }
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                LastName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                FirstName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                AccountID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(LastName.Text) || string.IsNullOrWhiteSpace(FirstName.Text) || AccountID.SelectedItem == null)
                {
                    LastName.BorderBrush = new SolidColorBrush(Colors.Red);
                    FirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                    AccountID.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (!Regex.IsMatch(LastName.Text, @"\d") || !Regex.IsMatch(FirstName.Text, @"\d"))
                {
                    object AcountID = (AccountID.SelectedItem as DataRowView).Row[0];

                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    LastName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    FirstName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    AccountID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (EmployeeTable.SelectedItem as DataRowView).Row[0];

                    Employ.UpdateQueryTruy(FirstName.Text, LastName.Text, Convert.ToInt32(AcountID), Convert.ToInt32(id));
                    EmployeeTable.ItemsSource = Employ.GetMain();
                    EmployeeTable.Columns[1].Visibility = Visibility.Collapsed;
                    EmployeeTable.Columns[2].Visibility = Visibility.Collapsed;
                    EmployeeTable.Columns[3].Visibility = Visibility.Collapsed;
                }
                else
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    LastName.BorderBrush = new SolidColorBrush(Colors.Red);
                    FirstName.BorderBrush = new SolidColorBrush(Colors.Red);
                    AccountID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                }
            }
        }
    }
}
