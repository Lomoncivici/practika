using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Text;

namespace Practoz5
{
    public partial class Buyer : Page
    {
        BuyerTableAdapter Buy = new BuyerTableAdapter();
        ReviewsTableAdapter Reviews = new ReviewsTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Buyer()
        {
            InitializeComponent();

            BuyerTable.ItemsSource = Buy.GetMain();
        }
        private void WindDead(object sender, RoutedEventArgs e)
        {
            BuyerTable.Columns[1].Visibility = Visibility.Collapsed;
            BuyerTable.Columns[2].Visibility = Visibility.Collapsed;
            BuyerTable.Columns[4].Visibility = Visibility.Collapsed;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (BuyerTable.SelectedItem as DataRowView != null)
            {
                object id = (BuyerTable.SelectedItem as DataRowView).Row[0];

                var RevID = Reviews.GetData().Rows;
                var OrdID = orders.GetData().Rows;

                for (int i = 0; i < RevID.Count; i++)
                {
                    if (RevID[i][1].ToString() == id.ToString())
                    {
                        Reviews.UpdateQueryTrue(1, i + 1);
                    }
                }
                for (int i = 0; i < OrdID.Count; i++)
                {
                    if (OrdID[i][1].ToString() == id.ToString())
                    {
                        orders.UpdateQueryTrue(1, i + 1);
                    }
                }
                Buy.DeleteQuery(Convert.ToInt32(id));
                BuyerTable.ItemsSource = Buy.GetMain();
                BuyerTable.Columns[1].Visibility = Visibility.Collapsed;
                BuyerTable.Columns[2].Visibility = Visibility.Collapsed;
                BuyerTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrWhiteSpace(Email.Text))
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                Email.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbbr) && int.TryParse(Phone.Text, out int numbr))
            {
                if (Email.Text.Contains("@") && Phone.Text.Length == 11)
                {
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Email.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    Buy.InsertQuery(Convert.ToInt32(ID.Text), Position.Text, Loginn.Text, Email.Text, Phone.Text.Insert(1, "-").Insert(5, "-").Insert(9, "-"));
                    BuyerTable.ItemsSource = Buy.GetMain();
                    BuyerTable.Columns[1].Visibility = Visibility.Collapsed;
                    BuyerTable.Columns[2].Visibility = Visibility.Collapsed;
                    BuyerTable.Columns[4].Visibility = Visibility.Collapsed;
                }
                else
                {
                    Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                    Email.BorderBrush = new SolidColorBrush(Colors.Red);
                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                }
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                Email.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (BuyerTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Phone.Text) || string.IsNullOrWhiteSpace(Email.Text))
                {
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                    Phone.BorderBrush = new SolidColorBrush(Colors.Red);
                    Email.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (int.TryParse(Phone.Text, out int numbr) || !Email.Text.Contains("@") || Phone.Text.Length == 11)
                {
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Phone.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Email.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (BuyerTable.SelectedItem as DataRowView).Row[0];

                    Buy.UpdateQuery(Position.Text, Loginn.Text, Email.Text, Phone.Text.Insert(1, "-").Insert(5, "-").Insert(9, "-"), Convert.ToInt32(id));
                    BuyerTable.ItemsSource = Buy.GetMain();
                    BuyerTable.Columns[1].Visibility = Visibility.Collapsed;
                    BuyerTable.Columns[2].Visibility = Visibility.Collapsed;
                    BuyerTable.Columns[4].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
