using Practoz5.conditerDataSetTableAdapters;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Practoz5
{
    public partial class MainWindow : Window
    {
        CheckpleaseTableAdapter Check = new CheckpleaseTableAdapter();
        OrdersTableAdapter Orders = new OrdersTableAdapter();
        EmployeeTableAdapter Sotrydnik = new EmployeeTableAdapter();
        AccountTableAdapter Account = new AccountTableAdapter();
        ProductsTableAdapter Products = new ProductsTableAdapter();
        ReviewsTableAdapter Otzov = new ReviewsTableAdapter();
        BuyerTableAdapter Pokypatel = new BuyerTableAdapter();
        StorageTableAdapter Storage = new StorageTableAdapter();
        ProviderrTableAdapter Postav = new ProviderrTableAdapter();
        CategoriesTableAdapter Categor = new CategoriesTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            LeftTable.ItemsSource = Account.GetMain();
            RightTable.ItemsSource = Account.GetMain();
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

        private void Vhode_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = Account.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == Login.Text && allLogins[i][3].ToString() == CalculateSHA256(Password.Password))
                {
                    string id = (string)allLogins[i][1];
                    switch (id)
                    {
                        case "Продавец":
                            Errror.Text = " ";
                            Login.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7C5A8"));
                            Password.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7C5A8"));

                            Kasir kasir = new Kasir();
                            kasir.Show();
                            break;
                        case "Администратор":
                            Errror.Text = " ";
                            Login.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7C5A8"));
                            Password.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7C5A8"));

                            Admin admin = new Admin();
                            admin.Show();
                            break;
                    }
                    this.Close();
                }
                if (allLogins[i][2].ToString() != Login.Text && allLogins[i][3].ToString() != Password.Password)
                {
                    int id = (int)allLogins[i][0];
                    switch (id)
                    {
                        case 1:
                            Errror.Text = "Ошибка неверный логин или пароль";
                            Login.BorderBrush = new SolidColorBrush(Colors.Red);
                            Password.BorderBrush = new SolidColorBrush(Colors.Red);
                            break;
                    }
                }
            }
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            RightTable.Columns[0].Visibility = Visibility.Collapsed;
            RightTable.Columns[1].Visibility = Visibility.Collapsed;
            RightTable.Columns[2].Visibility = Visibility.Collapsed;
            RightTable.Columns[3].Visibility = Visibility.Collapsed;
            RightTable.Columns[4].Visibility = Visibility.Collapsed;

            LeftTable.Columns[0].Visibility = Visibility.Collapsed;
            LeftTable.Columns[1].Visibility = Visibility.Collapsed;
            LeftTable.Columns[2].Visibility = Visibility.Collapsed;
            LeftTable.Columns[3].Visibility = Visibility.Collapsed;
            LeftTable.Columns[5].Visibility = Visibility.Collapsed;
            LeftTable.Columns[6].Visibility = Visibility.Collapsed;
        }
    }
}
