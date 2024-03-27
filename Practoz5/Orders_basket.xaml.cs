using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practoz5
{
    public partial class Orders_basket : Page
    {
        Orders_basketTableAdapter Orders_bask = new Orders_basketTableAdapter();
        OrdersTableAdapter Order = new OrdersTableAdapter();
        ProductsTableAdapter Product = new ProductsTableAdapter();
        CheckpleaseTableAdapter Checkplease = new CheckpleaseTableAdapter();
        StorageTableAdapter Storage = new StorageTableAdapter();
        public Orders_basket()
        {
            InitializeComponent();

            Orders_basketTable.ItemsSource = Orders_bask.GetKasir();

            ProductCBX.ItemsSource = Storage.GetData();
            ProductCBX.DisplayMemberPath = "ProductName";

            OrderCBX.ItemsSource = Order.GetData();
            OrderCBX.DisplayMemberPath = "OrderID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            Orders_basketTable.Columns[1].Visibility = Visibility.Collapsed;
            Orders_basketTable.Columns[2].Visibility = Visibility.Collapsed;
            Orders_basketTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_basketTable.SelectedItem as DataRowView != null)
            {
                object id = (Orders_basketTable.SelectedItem as DataRowView).Row[0];

                var allID = Checkplease.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][1].ToString() == id.ToString())
                    {
                        Checkplease.UpdateQueryOrder_basket(1, i + 1);
                    }
                }
                Orders_bask.DeleteQuery(Convert.ToInt32(id));
                Orders_basketTable.ItemsSource = Orders_bask.GetMain();
                Orders_basketTable.ItemsSource = Orders_bask.GetKasir();
                Orders_basketTable.Columns[1].Visibility = Visibility.Collapsed;
                Orders_basketTable.Columns[2].Visibility = Visibility.Collapsed;
                Orders_basketTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Quntity.Text) || ProductCBX.SelectedItem == null || OrderCBX.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                ProductCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                OrderCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Quntity.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr))
            {
                object Prod = (ProductCBX.SelectedItem as DataRowView).Row[0];
                object Ord = (OrderCBX.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                ProductCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                OrderCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Quntity.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Orders_bask.InsertQuery(Convert.ToInt32(ID.Text), Convert.ToInt32(Ord), Convert.ToInt32(Quntity.Text), Convert.ToInt32(Prod));
                Orders_basketTable.ItemsSource = Orders_bask.GetMain();
                Orders_basketTable.ItemsSource = Orders_bask.GetKasir();
                Orders_basketTable.Columns[1].Visibility = Visibility.Collapsed;
                Orders_basketTable.Columns[2].Visibility = Visibility.Collapsed;
                Orders_basketTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                ProductCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                OrderCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Quntity.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_basketTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Quntity.Text) || ProductCBX.SelectedItem == null || OrderCBX.SelectedItem == null)
                {
                    ProductCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    OrderCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    Quntity.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    object Prod = (ProductCBX.SelectedItem as DataRowView).Row[0];
                    object Ord = (OrderCBX.SelectedItem as DataRowView).Row[0];

                    ProductCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    OrderCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Quntity.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (Orders_basketTable.SelectedItem as DataRowView).Row[0];

                    Orders_bask.UpdateQuery(Convert.ToInt32(Ord), Convert.ToInt32(Quntity.Text), Convert.ToInt32(Prod), Convert.ToInt32(id));
                    Orders_basketTable.ItemsSource = Orders_bask.GetMain();
                    Orders_basketTable.ItemsSource = Orders_bask.GetKasir();
                    Orders_basketTable.Columns[1].Visibility = Visibility.Collapsed;
                    Orders_basketTable.Columns[2].Visibility = Visibility.Collapsed;
                    Orders_basketTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
