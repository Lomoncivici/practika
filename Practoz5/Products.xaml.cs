using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practoz5
{
    public partial class Products : Page
    {
        ProductsTableAdapter Productss = new ProductsTableAdapter();
        CategoriesTableAdapter Categories = new CategoriesTableAdapter();
        StorageTableAdapter Storage = new StorageTableAdapter();
        ReviewsTableAdapter Reviews = new ReviewsTableAdapter();
        Orders_basketTableAdapter orders_basket = new Orders_basketTableAdapter();
        public Products()
        {
            InitializeComponent();

            ProductTable.ItemsSource = Productss.GetMain();

            StorageCBX.ItemsSource = Storage.GetData();
            StorageCBX.DisplayMemberPath = "StorageID";

            CotegorCBX.ItemsSource = Categories.GetData();
            CotegorCBX.DisplayMemberPath = "CategoryID";

            ReviewsCBX.ItemsSource = Reviews.GetData();
            ReviewsCBX.DisplayMemberPath = "ReviewID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            ProductTable.Columns[1].Visibility = Visibility.Collapsed;
            ProductTable.Columns[2].Visibility = Visibility.Collapsed;
            ProductTable.Columns[3].Visibility = Visibility.Collapsed;
            ProductTable.Columns[4].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTable.SelectedItem as DataRowView != null)
            {
                object id = (ProductTable.SelectedItem as DataRowView).Row[0];

                var allID = orders_basket.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][3].ToString() == id.ToString())
                    {
                        orders_basket.UpdateQueryProduct(1, i + 1);
                    }
                }
                Productss.DeleteQuery(Convert.ToInt32(id));
                ProductTable.ItemsSource = Productss.GetMain();
                ProductTable.Columns[1].Visibility = Visibility.Collapsed;
                ProductTable.Columns[2].Visibility = Visibility.Collapsed;
                ProductTable.Columns[3].Visibility = Visibility.Collapsed;
                ProductTable.Columns[4].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Price.Text) || StorageCBX.SelectedItem == null || CotegorCBX.SelectedItem == null || ReviewsCBX.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                StorageCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                CotegorCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                ReviewsCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Price.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr) || int.TryParse(Price.Text, out numbr))
            {
                object Stor = (StorageCBX.SelectedItem as DataRowView).Row[0];
                object Coteg = (CotegorCBX.SelectedItem as DataRowView).Row[0];
                object Rew = (ReviewsCBX.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                StorageCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                CotegorCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                ReviewsCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Price.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Productss.InsertQuery(Convert.ToInt32(ID.Text), Convert.ToInt32(Stor), Convert.ToInt32(Coteg), Convert.ToInt32(Price.Text), Convert.ToInt32(Rew));
                ProductTable.ItemsSource = Productss.GetMain();
                ProductTable.Columns[1].Visibility = Visibility.Collapsed;
                ProductTable.Columns[2].Visibility = Visibility.Collapsed;
                ProductTable.Columns[3].Visibility = Visibility.Collapsed;
                ProductTable.Columns[4].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                StorageCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                CotegorCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                ReviewsCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Price.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Price.Text) || StorageCBX.SelectedItem == null || CotegorCBX.SelectedItem == null || ReviewsCBX.SelectedItem == null)
                {
                    StorageCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    CotegorCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    ReviewsCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    Price.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (int.TryParse(Price.Text, out int numbr))
                {
                    object Stor = (StorageCBX.SelectedItem as DataRowView).Row[0];
                    object Coteg = (CotegorCBX.SelectedItem as DataRowView).Row[0];
                    object Rew = (ReviewsCBX.SelectedItem as DataRowView).Row[0];

                    ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    StorageCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    CotegorCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    ReviewsCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Price.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (ProductTable.SelectedItem as DataRowView).Row[0];

                    Productss.UpdateQuery(Convert.ToInt32(Stor), Convert.ToInt32(Coteg), Convert.ToInt32(Price.Text), Convert.ToInt32(Rew), Convert.ToInt32(id));
                    ProductTable.ItemsSource = Productss.GetMain();
                    ProductTable.Columns[1].Visibility = Visibility.Collapsed;
                    ProductTable.Columns[2].Visibility = Visibility.Collapsed;
                    ProductTable.Columns[3].Visibility = Visibility.Collapsed;
                    ProductTable.Columns[4].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
