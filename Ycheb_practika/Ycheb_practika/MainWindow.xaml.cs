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

namespace Ycheb_practika
{
    public partial class MainWindow : Window
    {
        StorageTableAdapter storage = new StorageTableAdapter();
        PRACT3Entities sstorage = new PRACT3Entities();
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
    }
}
