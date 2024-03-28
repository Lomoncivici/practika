using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Practoz5
{
    /// <summary>
    /// Логика взаимодействия для Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        CategoriesTableAdapter Categor = new CategoriesTableAdapter();
        ProductsTableAdapter Products = new ProductsTableAdapter();
        public Categories()
        {
            InitializeComponent();

            CategoriesTable.ItemsSource = Categor.GetMain();
        }
        private void WindDead(object sender, RoutedEventArgs e)
        {
            CategoriesTable.Columns[1].Visibility = Visibility.Collapsed;
            CategoriesTable.Columns[2].Visibility = Visibility.Collapsed;
            CategoriesTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesTable.SelectedItem as DataRowView != null)
            {
                object id = (CategoriesTable.SelectedItem as DataRowView).Row[0];

                var allID = Products.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][2].ToString() == id.ToString())
                    {
                        Products.UpdateQueryTrue(1, i + 1);
                    }
                }
                Categor.DeleteQuery(Convert.ToInt32(id));
                CategoriesTable.ItemsSource = Categor.GetMain();
                CategoriesTable.Columns[1].Visibility = Visibility.Collapsed;
                CategoriesTable.Columns[2].Visibility = Visibility.Collapsed;
                CategoriesTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Fill.Text))
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                Fill.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr) && !Regex.IsMatch(Position.Text, @"\d") && !Regex.IsMatch(Loginn.Text, @"\d") && !Regex.IsMatch(Fill.Text, @"\d"))
            {
                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Fill.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Categor.InsertQuery(Convert.ToInt32(ID.Text), Position.Text, Fill.Text, Loginn.Text);
                CategoriesTable.ItemsSource = Categor.GetMain();
                CategoriesTable.Columns[1].Visibility = Visibility.Collapsed;
                CategoriesTable.Columns[2].Visibility = Visibility.Collapsed;
                CategoriesTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                Position.BorderBrush = new SolidColorBrush(Colors.Red);
                Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                Fill.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Position.Text) || string.IsNullOrWhiteSpace(Loginn.Text) || string.IsNullOrWhiteSpace(Fill.Text))
                {
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                    Fill.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (!Regex.IsMatch(Position.Text, @"\d") && !Regex.IsMatch(Loginn.Text, @"\d") && !Regex.IsMatch(Fill.Text, @"\d"))
                {
                    Position.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Loginn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Fill.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                    object id = (CategoriesTable.SelectedItem as DataRowView).Row[0];

                    Categor.UpdateQuery(Position.Text, Fill.Text, Loginn.Text, Convert.ToInt32(id));
                    CategoriesTable.ItemsSource = Categor.GetMain();
                    CategoriesTable.Columns[1].Visibility = Visibility.Collapsed;
                    CategoriesTable.Columns[2].Visibility = Visibility.Collapsed;
                    CategoriesTable.Columns[3].Visibility = Visibility.Collapsed;
                }
                else
                {
                    ID.BorderBrush = new SolidColorBrush(Colors.Red);
                    Position.BorderBrush = new SolidColorBrush(Colors.Red);
                    Loginn.BorderBrush = new SolidColorBrush(Colors.Red);
                    Fill.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
