using MaterialDesignThemes.Wpf;
using Practoz5.conditerDataSetTableAdapters;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practoz5
{
    public partial class Account : Page
    {
        AccountTableAdapter Accountt = new AccountTableAdapter();
        EmployeeTableAdapter Empll = new EmployeeTableAdapter();
        public Account()
        {
            InitializeComponent();

            AccountTable.ItemsSource = Accountt.GetMain();
        }
        private void WindDead(object sender, RoutedEventArgs e)
        {
            AccountTable.Columns[1].Visibility = Visibility.Collapsed;
            AccountTable.Columns[2].Visibility = Visibility.Collapsed;
            AccountTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        public static string CalculateSHA256(string input)
        {
            // Преобразование входной строки в массив байтов
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Создание объекта SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Вычисление хеша для входных данных
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Преобразование массива байтов в строку шестнадцатеричного представления
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); // Форматирование байта в двузначное шестнадцатеричное число
                }
                return builder.ToString();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AccountTable.SelectedItem as DataRowView != null)
            {
                object id = (AccountTable.SelectedItem as DataRowView).Row[0];

                var allID = Empll.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][3].ToString() == id.ToString())
                    {
                        Empll.UpdateQuery(1, i + 1);
                    }
                }
                Accountt.DeleteQuery(Convert.ToInt32(id));
                AccountTable.ItemsSource = Accountt.GetMain();
                AccountTable.Columns[1].Visibility = Visibility.Collapsed;
                AccountTable.Columns[2].Visibility = Visibility.Collapsed;
                AccountTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Password.Password))
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                Password.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr))
            {
                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Password.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Accountt.InsertQuery(Convert.ToInt32(ID.Text), Position.Text, Loginn.Text, CalculateSHA256(Password.Password));
                AccountTable.ItemsSource = Accountt.GetMain();
                AccountTable.Columns[1].Visibility = Visibility.Collapsed;
                AccountTable.Columns[2].Visibility = Visibility.Collapsed;
                AccountTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Password.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (AccountTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Password.Password))
                {
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                    Password.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Password.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (AccountTable.SelectedItem as DataRowView).Row[0];

                    Accountt.UpdateQuery(Position.Text, Loginn.Text, CalculateSHA256(Password.Password), Convert.ToInt32(id));
                    AccountTable.ItemsSource = Accountt.GetMain();
                    AccountTable.Columns[1].Visibility = Visibility.Collapsed;
                    AccountTable.Columns[2].Visibility = Visibility.Collapsed;
                    AccountTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
