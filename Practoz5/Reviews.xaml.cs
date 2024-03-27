using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practoz5
{
    public partial class Reviews : Page
    {
        ReviewsTableAdapter Review = new ReviewsTableAdapter();
        BuyerTableAdapter Buyer = new BuyerTableAdapter();
        ProductsTableAdapter Products = new ProductsTableAdapter();
        public Reviews()
        {
            InitializeComponent();

            ReviewsTable.ItemsSource = Review.GetMain();

            BueyrCBX.ItemsSource = Buyer.GetData();
            BueyrCBX.DisplayMemberPath = "BuyerID";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            ReviewsTable.Columns[1].Visibility = Visibility.Collapsed;
            ReviewsTable.Columns[2].Visibility = Visibility.Collapsed;
            ReviewsTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsTable.SelectedItem as DataRowView != null)
            {
                object id = (ReviewsTable.SelectedItem as DataRowView).Row[0];

                var allID = Products.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][4].ToString() == id.ToString())
                    {
                        Products.UpdateQueryReviews(1, i + 1);
                    }
                }
                Review.DeleteQuery(Convert.ToInt32(id));
                ReviewsTable.ItemsSource = Review.GetMain();
                ReviewsTable.Columns[1].Visibility = Visibility.Collapsed;
                ReviewsTable.Columns[2].Visibility = Visibility.Collapsed;
                ReviewsTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Coment.Text) || string.IsNullOrWhiteSpace(Rating.Text) || BueyrCBX.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                BueyrCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Rating.BorderBrush = new SolidColorBrush(Colors.Red);
                Coment.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr))
            {
                object Buy = (BueyrCBX.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                BueyrCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Rating.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Coment.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Review.InsertQuery(Convert.ToInt32(ID.Text), Convert.ToInt32(Buy), Convert.ToInt32(Rating.Text), Coment.Text);
                ReviewsTable.ItemsSource = Review.GetMain();
                ReviewsTable.Columns[1].Visibility = Visibility.Collapsed;
                ReviewsTable.Columns[2].Visibility = Visibility.Collapsed;
                ReviewsTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                BueyrCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Rating.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Coment.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Rating.Text) || string.IsNullOrWhiteSpace(Coment.Text) || BueyrCBX.SelectedItem == null)
                {
                    BueyrCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    Rating.BorderBrush = new SolidColorBrush(Colors.Red);
                    Coment.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    object buy = (BueyrCBX.SelectedItem as DataRowView).Row[0];

                    BueyrCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Rating.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Coment.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (ReviewsTable.SelectedItem as DataRowView).Row[0];

                    Review.UpdateQuery(Convert.ToInt32(buy), Convert.ToInt32(Rating.Text), Coment.Text, Convert.ToInt32(id));
                    ReviewsTable.ItemsSource = Review.GetMain();
                    ReviewsTable.Columns[1].Visibility = Visibility.Collapsed;
                    ReviewsTable.Columns[2].Visibility = Visibility.Collapsed;
                    ReviewsTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
