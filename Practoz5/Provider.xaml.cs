using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

namespace Practoz5
{
    public partial class Provider : Page
    {
        ProviderrTableAdapter Provid = new ProviderrTableAdapter();
        StorageTableAdapter Storage = new StorageTableAdapter();
        
        public Provider()
        {
            InitializeComponent();

            ProviderTable.ItemsSource = Provid.GetMain();
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
            ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
            ProviderTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderTable.SelectedItem as DataRowView != null)
            {
                object id = (ProviderTable.SelectedItem as DataRowView).Row[0];

                var allID = Storage.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][3].ToString() == id.ToString())
                    {
                        Storage.UpdateQueryProvider(1, i + 1);
                    }
                }
                Provid.DeleteQuery(Convert.ToInt32(id));
                ProviderTable.ItemsSource = Provid.GetMain();
                ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
                ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
                ProviderTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string a = Phone.Text;
            Phone.Text = Phone.Text.Replace("(", "").Replace(")", "").Replace("-", "");

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(ProviderName.Text) || string.IsNullOrWhiteSpace(Providerr.Text) || string.IsNullOrWhiteSpace(Phone.Text))
            {
                SetRedBorderBrush();
            }
            else if (int.TryParse(ID.Text, out int numbbr))
            {
                if (!Regex.IsMatch(Phone.Text, @"^\d{11}$"))
                {
                    SetRedBorderBrush();
                }
                else if (Regex.IsMatch(ProviderName.Text, @"\d") || Regex.IsMatch(Providerr.Text, @"\d"))
                {
                    SetRedBorderBrush();
                }
                else
                {
                    SetDefaultBorderBrush();

                    Provid.InsertQuery(Convert.ToInt32(ID.Text), ProviderName.Text, Providerr.Text, Phone.Text.Insert(4, "-").Insert(8, "-").Insert(11, "-"));
                    ProviderTable.ItemsSource = Provid.GetMain();
                    Phone.Text = a;
                    ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[4].Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                SetRedBorderBrush();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderTable.SelectedItem as DataRowView != null)
            {
                string a = Phone.Text;
                Phone.Text = Phone.Text.Replace("(", "").Replace(")", "").Replace("-", "");

                if (string.IsNullOrWhiteSpace(Providerr.Text) || string.IsNullOrWhiteSpace(ProviderName.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                {
                    SetRedBorderBrush();
                }
                else if (!Regex.IsMatch(Phone.Text, @"^\d{11}$"))
                {
                    SetRedBorderBrush();
                }
                else if (Regex.IsMatch(ProviderName.Text, @"\d") || Regex.IsMatch(Providerr.Text, @"\d"))
                {
                    SetRedBorderBrush();
                }
                else
                {
                    SetDefaultBorderBrush();

                    object id = (ProviderTable.SelectedItem as DataRowView).Row[0];

                    Provid.UpdateQuery(ProviderName.Text, Providerr.Text, Phone.Text.Insert(4, "-").Insert(8, "-").Insert(11, "-"), Convert.ToInt32(id));
                    ProviderTable.ItemsSource = Provid.GetMain();
                    Phone.Text = a;
                    ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[4].Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SetRedBorderBrush()
        {
            ID.BorderBrush = new SolidColorBrush(Colors.Red);
            ProviderName.BorderBrush = new SolidColorBrush(Colors.Red);
            Providerr.BorderBrush = new SolidColorBrush(Colors.Red);
            Phone.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void SetDefaultBorderBrush()
        {
            ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            ProviderName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            Providerr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
        }

        private void PhoneTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            if (Phone.Text.Length == 1)
            {
                Phone.Text = Phone.Text.Insert(1, "(");
            }
            else if (Phone.Text.Length == 5)
            {
                Phone.Text = Phone.Text.Insert(5, ")");
            }
            else if (Phone.Text.Length == 6)
            {
                Phone.Text = Phone.Text.Insert(6, "-");
            }
            else if (Phone.Text.Length == 10)
            {
                Phone.Text = Phone.Text.Insert(10, "-");
            }
            else if (Phone.Text.Length == 13)
            {
                Phone.Text = Phone.Text.Insert(13, "-");
            }
            Phone.SelectionStart = 20;
        }
    }
}
