using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practoz5
{
    public partial class Orders : Page
    {
        OrdersTableAdapter Orderss = new OrdersTableAdapter();
        EmployeeTableAdapter Empl = new EmployeeTableAdapter();
        BuyerTableAdapter Buyer = new BuyerTableAdapter();
        Orders_basketTableAdapter orders_basket = new Orders_basketTableAdapter();
        public Orders()
        {
            InitializeComponent();

            OrdersTable.ItemsSource = Orderss.GetMain();

            EmployeeCBX.ItemsSource = Empl.GetData();
            EmployeeCBX.DisplayMemberPath = "EmployeeID";

            BuyerCBX.ItemsSource = Buyer.GetData();
            BuyerCBX.DisplayMemberPath = "BuyerID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            /*OrdersTable.Columns[1].Visibility = Visibility.Collapsed;
            OrdersTable.Columns[2].Visibility = Visibility.Collapsed;
            OrdersTable.Columns[3].Visibility = Visibility.Collapsed;*/
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersTable.SelectedItem as DataRowView != null)
            {
                object id = (OrdersTable.SelectedItem as DataRowView).Row[0];

                var allID = orders_basket.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][1].ToString() == id.ToString())
                    {
                        orders_basket.UpdateQueryOrders(1, i + 1);
                    }
                }
                Orderss.DeleteQuery(Convert.ToInt32(id));
                OrdersTable.ItemsSource = Orderss.GetMain();
                OrdersTable.ItemsSource = Orderss.GetaKasir();
                OrdersTable.Columns[1].Visibility = Visibility.Collapsed;
                OrdersTable.Columns[2].Visibility = Visibility.Collapsed;
                OrdersTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(TotalAmount.Text) || BuyerCBX.SelectedItem == null || EmployeeCBX.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                EmployeeCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                BuyerCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                TotalAmount.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr))
            {
                object Buy = (BuyerCBX.SelectedItem as DataRowView).Row[0];
                object Epl = (EmployeeCBX.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                EmployeeCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                BuyerCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                TotalAmount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Orderss.InsertQuery(Convert.ToInt32(ID.Text), Convert.ToInt32(Buy), Convert.ToInt32(Epl), TotalAmount.Text);
                OrdersTable.ItemsSource = Orderss.GetMain();
                OrdersTable.ItemsSource = Orderss.GetaKasir();
                OrdersTable.Columns[1].Visibility = Visibility.Collapsed;
                OrdersTable.Columns[2].Visibility = Visibility.Collapsed;
                OrdersTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                EmployeeCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                BuyerCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                TotalAmount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(TotalAmount.Text) || BuyerCBX.SelectedItem == null || EmployeeCBX.SelectedItem == null)
                {
                    EmployeeCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    BuyerCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    TotalAmount.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    object Buy = (BuyerCBX.SelectedItem as DataRowView).Row[0];
                    object Epl = (EmployeeCBX.SelectedItem as DataRowView).Row[0];

                    EmployeeCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    BuyerCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    TotalAmount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (OrdersTable.SelectedItem as DataRowView).Row[0];

                    Orderss.UpdateQuery(Convert.ToInt32(Buy), Convert.ToInt32(Epl), TotalAmount.Text, Convert.ToInt32(id));
                    OrdersTable.ItemsSource = Orderss.GetMain();
                    OrdersTable.ItemsSource = Orderss.GetaKasir();
                    OrdersTable.Columns[1].Visibility = Visibility.Collapsed;
                    OrdersTable.Columns[2].Visibility = Visibility.Collapsed;
                    OrdersTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
