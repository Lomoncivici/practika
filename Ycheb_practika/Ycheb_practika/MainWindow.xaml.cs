using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ycheb_practika.PRACT3DataSetTableAdapters;
using System.Management.Instrumentation;
using static Ycheb_practika.PRACT3DataSet;
using System.Diagnostics;

namespace Ycheb_practika
{
    public partial class MainWindow : Window
    {

        StorageTableAdapter storage = new StorageTableAdapter();
        ConfigTableAdapter Config = new ConfigTableAdapter();
        TipTableAdapter Tip = new TipTableAdapter();
        BrandsTableAdapter Brands = new BrandsTableAdapter();
        CharacteristicsTableAdapter Characteristics = new CharacteristicsTableAdapter();

        private PRACT3Entities2 sstorage = new PRACT3Entities2();
        public MainWindow()
        {
            InitializeComponent();
            StorageDataGrid.ItemsSource = storage.GettFullInfo();

            ComboBox_Tip.ItemsSource = Tip.GetData();
            ComboBox_Tip.DisplayMemberPath = "Tip_Name";

            ComboBox_Brands.ItemsSource = Brands.GetData();
            ComboBox_Brands.DisplayMemberPath = "Brand_Name";

            ComboBox_Config.ItemsSource = Config.GetData();
            ComboBox_Config.DisplayMemberPath = "Config_Name";

            ComboBox_Characteristics.ItemsSource = Characteristics.GetData();
            ComboBox_Characteristics.DisplayMemberPath = "ID_Characteristics";

            ComboBox_Price.ItemsSource = storage.GetData();
            ComboBox_Price.DisplayMemberPath = "price";
            


            StorageDrg.ItemsSource = sstorage.Storage_View.ToList();

            StorageCbx_Tip.ItemsSource = sstorage.Tip.ToList();
            StorageCbx_Tip.DisplayMemberPath = "Tip_Name";

            StorageCbx_Brands.ItemsSource = sstorage.Brands.ToList();
            StorageCbx_Brands.DisplayMemberPath = "Brand_Name";

            StorageCbx_Config.ItemsSource = sstorage.Config.ToList();
            StorageCbx_Config.DisplayMemberPath = "Config_Name";

            StorageCbx_Characteristics.ItemsSource = sstorage.Characteristics.ToList();
            StorageCbx_Characteristics.DisplayMemberPath = "ID_Characteristics";

            StorageCbx_Price.ItemsSource = sstorage.Storage.ToList();
            StorageCbx_Price.DisplayMemberPath = "price";
        }

        private void Click_pred(object sender, RoutedEventArgs e)
        {
            StorageDataGrid.Visibility = Visibility.Visible;

            ComboBox_ID.Visibility = Visibility.Visible;
            ComboBox_Tip.Visibility = Visibility.Visible;
            ComboBox_Brands.Visibility = Visibility.Visible;
            ComboBox_Price.Visibility = Visibility.Visible;
            ComboBox_Config.Visibility = Visibility.Visible;
            ComboBox_Characteristics.Visibility = Visibility.Visible;

            StorageDrg.Visibility = Visibility.Hidden;

            StorageCbx_ID.Visibility = Visibility.Hidden;
            StorageCbx_Tip.Visibility = Visibility.Hidden;
            StorageCbx_Brands.Visibility = Visibility.Hidden;
            StorageCbx_Price.Visibility = Visibility.Hidden;
            StorageCbx_Config.Visibility = Visibility.Hidden;
            StorageCbx_Characteristics.Visibility = Visibility.Hidden;

            Delete.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Hidden;

            Delete1.Visibility = Visibility.Visible;
            Add1.Visibility = Visibility.Visible;
            Change1.Visibility = Visibility.Visible;
        }

        private void Click_InNewWindow(object sender, RoutedEventArgs e)
        {
            bool valueToPass = true;

            switch (StorageDataGrid.Visibility)
            {
                case Visibility.Visible:
                    valueToPass = true;
                    break;

                case Visibility.Hidden:
                    valueToPass = false;
                    break;
            }

            Бред_бредовый new_Бред_бредовый = new Бред_бредовый(valueToPass);

            new_Бред_бредовый.Show();
        }

        private void Click_cled(object sender, RoutedEventArgs e)
        {
            StorageDataGrid.Visibility = Visibility.Hidden;

            ComboBox_ID.Visibility = Visibility.Hidden;
            ComboBox_Tip.Visibility = Visibility.Hidden;
            ComboBox_Brands.Visibility = Visibility.Hidden;
            ComboBox_Price.Visibility = Visibility.Hidden;
            ComboBox_Config.Visibility = Visibility.Hidden;
            ComboBox_Characteristics.Visibility = Visibility.Hidden;

            StorageDrg.Visibility = Visibility.Visible;

            StorageCbx_ID.Visibility = Visibility.Visible;
            StorageCbx_Tip.Visibility = Visibility.Visible;
            StorageCbx_Brands.Visibility = Visibility.Visible;
            StorageCbx_Price.Visibility = Visibility.Visible;
            StorageCbx_Config.Visibility = Visibility.Visible;
            StorageCbx_Characteristics.Visibility = Visibility.Visible;

            Delete.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Visible;
            Change.Visibility = Visibility.Visible;

            Delete1.Visibility = Visibility.Hidden;
            Add1.Visibility = Visibility.Hidden;
            Change1.Visibility = Visibility.Hidden;
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if (StorageDrg.SelectedItem != null)
            {
                sstorage.Storage.Remove(StorageDrg.SelectedItem as Storage);

                sstorage.SaveChanges();
                StorageDrg.ItemsSource = sstorage.Storage.ToList();
            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {

            int znach = Convert.ToInt32(TextBox.Text);

            var Tip = StorageCbx_Tip.SelectedItem as Tip;
            var Brands = StorageCbx_Brands.SelectedItem as Brands;
            var Price = StorageCbx_Price.SelectedItem as Storage;
            var Config = StorageCbx_Config.SelectedItem as Config;
            var Characteristics = StorageCbx_Characteristics.SelectedItem as Characteristics;

            Storage c = new Storage();
            c.ID = znach;
            c.Tip_ID = Tip.ID_Tip;
            c.brand_ID = Brands.ID_Brand;
            c.price = Price.price;
            c.Config_ID = Config.ID_Config;
            c.Characteristics_ID = Characteristics.ID_Characteristics;

            sstorage.Storage.Add(c);
            sstorage.SaveChanges();
            StorageDrg.ItemsSource = sstorage.Storage.ToList();
        }

        private void Click_Change(object sender, RoutedEventArgs e)
        {

            if (StorageDrg.SelectedItem != null)
            {

                var selected = StorageDrg.SelectedItem as Storage;
                
                var Tip = StorageCbx_Tip.SelectedItem as Tip;
                var Brands = StorageCbx_Brands.SelectedItem as Brands;
                var Price = StorageCbx_Price.SelectedItem as Storage;
                var Config = StorageCbx_Config.SelectedItem as Config;
                var Characteristics = StorageCbx_Characteristics.SelectedItem as Characteristics;

                selected.Tip = Tip;
                selected.Brands = Brands;
                selected.price = Price.price;
                selected.Config = Config;
                selected.Characteristics = Characteristics;

                sstorage.SaveChanges();
                StorageDrg.ItemsSource = sstorage.Storage.ToList();;
            }
        }

        private void Click_Add1(object sender, RoutedEventArgs e)
        {
            int textBox = Convert.ToInt32(TextBox.Text);

            object Tip = (ComboBox_Tip.SelectedItem as DataRowView).Row[0];
            object Brands = (ComboBox_Brands.SelectedItem as DataRowView).Row[0];
            object Price = (ComboBox_Price.SelectedItem as DataRowView).Row[3];
            object Config = (ComboBox_Config.SelectedItem as DataRowView).Row[0];
            object Characteristics = (ComboBox_Characteristics.SelectedItem as DataRowView).Row[0];

            storage.InsertQuery(textBox, Convert.ToInt32(Tip), Convert.ToInt32(Brands), Convert.ToInt32(Price), Convert.ToInt32(Config), Convert.ToInt32(Characteristics));
            StorageDataGrid.ItemsSource = storage.GetData();
        }

        private void Click_Change1(object sender, RoutedEventArgs e)
        {
            object id = (StorageDataGrid.SelectedItem as DataRowView).Row[0];
            object Tip = (ComboBox_Tip.SelectedItem as DataRowView).Row[0];
            object Brands = (ComboBox_Brands.SelectedItem as DataRowView).Row[0];
            object Price = (ComboBox_Price.SelectedItem as DataRowView).Row[3];
            object Config = (ComboBox_Config.SelectedItem as DataRowView).Row[0];
            object Characteristics = (ComboBox_Characteristics.SelectedItem as DataRowView).Row[0];

            storage.UpdateQuery(Convert.ToInt32(Tip), Convert.ToInt32(Brands), Convert.ToInt32(Price), Convert.ToInt32(Config), Convert.ToInt32(Characteristics), Convert.ToInt32(id));
            StorageDataGrid.ItemsSource = storage.GetData();
        }

        private void Click_Delete1(object sender, RoutedEventArgs e)
        {
            object id = (StorageDataGrid.SelectedItem as DataRowView).Row[0];
            storage.DeleteQuery(Convert.ToInt32(id));
            StorageDataGrid.ItemsSource = storage.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*!Визуальный костыль!*/
            StorageDataGrid.Columns[3].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[5].Visibility = Visibility.Collapsed;
            /*!Визуальный костыль!*/

            /*StorageDataGrid.Columns[0].DisplayIndex = 0;
            StorageDataGrid.Columns[4].DisplayIndex = 1;*/
            /*StorageDataGrid.Columns[5].DisplayIndex = 3;
            StorageDataGrid.Columns[6].DisplayIndex = 5;*/

        }
    }
}
