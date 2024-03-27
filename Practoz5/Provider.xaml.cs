using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Providerr.Text) || string.IsNullOrWhiteSpace(ProviderName.Text) || string.IsNullOrWhiteSpace(Phone.Text))
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Providerr.BorderBrush = new SolidColorBrush(Colors.Red);
                Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                ProviderName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(Phone.Text, out int numbr) && int.TryParse(ID.Text, out int numbbr))
            {
                if(Phone.Text.Length == 11)
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Providerr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    ProviderName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    Provid.InsertQuery(Convert.ToInt32(ID.Text), Providerr.Text, ProviderName.Text, Phone.Text.Insert(1, "-").Insert(5, "-").Insert(9, "-"));
                    ProviderTable.ItemsSource = Provid.GetMain();
                    ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[3].Visibility = Visibility.Collapsed;
                }
                else 
                {
                    Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Providerr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    ProviderName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                }
            }
            else
            {
                Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                ProviderName.BorderBrush = new SolidColorBrush(Colors.Red);
                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Providerr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Providerr.Text) || string.IsNullOrWhiteSpace(ProviderName.Text) || string.IsNullOrWhiteSpace(Phone.Text))
                {
                    Providerr.BorderBrush = new SolidColorBrush(Colors.Red);
                    Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                    ProviderName.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (int.TryParse(Phone.Text, out int numbr) || Phone.Text.Length == 11)
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Providerr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    ProviderName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (ProviderTable.SelectedItem as DataRowView).Row[0];

                    Provid.UpdateQuery(Providerr.Text, ProviderName.Text, Phone.Text.Insert(1, "-").Insert(5, "-").Insert(9, "-"), Convert.ToInt32(id));
                    ProviderTable.ItemsSource = Provid.GetMain();
                    ProviderTable.Columns[1].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[2].Visibility = Visibility.Collapsed;
                    ProviderTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
