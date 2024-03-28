using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Practoz5
{
    public partial class Check : Page
    {
        CheckpleaseTableAdapter Checkk = new CheckpleaseTableAdapter();
        Orders_basketTableAdapter Orders_ = new Orders_basketTableAdapter();
        public Check()
        {
            InitializeComponent();

            CheckpleaseTable.ItemsSource = Checkk.GetMain();
            CategorBox.ItemsSource = Orders_.GetData();
            CategorBox.DisplayMemberPath = "ID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            CheckpleaseTable.Columns[1].Visibility = Visibility.Collapsed;
            CheckpleaseTable.Columns[2].Visibility = Visibility.Collapsed;
            CheckpleaseTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CheckpleaseTable.SelectedItem as DataRowView != null)
            {
                object id = (CheckpleaseTable.SelectedItem as DataRowView).Row[0];

                Checkk.DeleteQuery(Convert.ToInt32(id));
                CheckpleaseTable.ItemsSource = Checkk.GetMain();
                CheckpleaseTable.Columns[1].Visibility = Visibility.Collapsed;
                CheckpleaseTable.Columns[2].Visibility = Visibility.Collapsed;
                CheckpleaseTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Position.Text) || CategorBox.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                CategorBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr) && !Regex.IsMatch(Position.Text, @"\d"))
            {
                object Checr = (CategorBox.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                CategorBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Checkk.InsertQuery(Convert.ToInt32(ID.Text), Convert.ToInt32(Checr), DateTime.Now.ToString(), Position.Text);
                CheckpleaseTable.ItemsSource = Checkk.GetMain();
                CheckpleaseTable.Columns[1].Visibility = Visibility.Collapsed;
                CheckpleaseTable.Columns[2].Visibility = Visibility.Collapsed;
                CheckpleaseTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                CategorBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (CheckpleaseTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Position.Text) || CategorBox.SelectedItem == null)
                {
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    CategorBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (!Regex.IsMatch(Position.Text, @"\d"))
                {
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    CategorBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (CheckpleaseTable.SelectedItem as DataRowView).Row[0];
                    object Checr = (CategorBox.SelectedItem as DataRowView).Row[0];

                    Checkk.UpdateQuery(Convert.ToInt32(Checr), Position.Text, Convert.ToInt32(id));
                    CheckpleaseTable.ItemsSource = Checkk.GetMain();
                    CheckpleaseTable.Columns[1].Visibility = Visibility.Collapsed;
                    CheckpleaseTable.Columns[2].Visibility = Visibility.Collapsed;
                    CheckpleaseTable.Columns[3].Visibility = Visibility.Collapsed;
                }
                else
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    CategorBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                }
            }
        }

        private void Check_Upload(object sender, RoutedEventArgs e)
        {
            if (CheckpleaseTable.SelectedItem as DataRowView != null)
            {

            }
        }
    }
}
