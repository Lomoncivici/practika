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

namespace Ycheb_practika
{
    public partial class MainWindow : Window
    {

        StorageTableAdapter storage = new StorageTableAdapter();
        PRACT3Entities1 sstorage = new PRACT3Entities1();
        public MainWindow()
        {
            InitializeComponent();
            StorageDataGrid.ItemsSource = storage.GetData();
            StorageComboBox.ItemsSource = storage.GetData();
            StorageComboBox.DisplayMemberPath = "price";

            StorageDrg.ItemsSource = sstorage.Storage.ToList();
            StorageCbx.ItemsSource = sstorage.Storage.ToList();
            StorageCbx.DisplayMemberPath = "price";
        }

        private void StorageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (StorageComboBox.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(cell.ToString());
        }

        private void StorageDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = StorageCbx.ItemsSource as Storage;
        }

        private void Click_pred(object sender, RoutedEventArgs e)
        {
            StorageDataGrid.Visibility = Visibility.Visible;
            StorageComboBox.Visibility = Visibility.Visible;

            StorageDrg.Visibility = Visibility.Hidden;
            StorageCbx.Visibility = Visibility.Hidden;
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
            StorageComboBox.Visibility = Visibility.Hidden;

            StorageDrg.Visibility = Visibility.Visible;
            StorageCbx.Visibility = Visibility.Visible;
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            /*if (StorageDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)StorageDataGrid.SelectedItem;
                int id = (int)row.Row["ID"];

                storage.DeleteQuery(id,id);

                StorageDataGrid.ItemsSource = storage.GetData();
            }*/

            if (StorageDrg.SelectedItem != null)
            {
                sstorage.Storage.Remove(StorageDrg.SelectedItem as Storage);

                sstorage.SaveChanges();
                StorageDrg.ItemsSource = sstorage.Storage.ToList();
            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            /*int znach = int.Parse(TextBox.Text);

            storage.InsertQuery(znach);
            StorageDataGrid.ItemsSource = storage.GetData();*/

            int znach = int.Parse(TextBox.Text);

            Storage c = new Storage();
            c.price = znach;

            sstorage.Storage.Add(c);
            sstorage.SaveChanges();
            StorageDrg.ItemsSource = sstorage.Storage.ToList();
        }

        private void Click_Change(object sender, RoutedEventArgs e)
        {
           /* if (StorageDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)StorageDataGrid.SelectedItem;
                int id = (int)row.Row["ID"]; 

                
                int newValue = int.Parse(TextBox.Text); 

                storage.UpdateQuery(newValue, id, id);

                StorageDataGrid.ItemsSource = storage.GetData();
            }*/

            if (StorageDrg.SelectedItem != null)
            {
                /*int znach = int.Parse(TextBox.Text);*/
                var selected = StorageDrg.SelectedItem as Storage;
                int znach = int.Parse(TextBox.Text);
                selected.price = znach;

                sstorage.SaveChanges();
                StorageDrg.ItemsSource = sstorage.Storage.ToList();;
            }
        }
    }
}
