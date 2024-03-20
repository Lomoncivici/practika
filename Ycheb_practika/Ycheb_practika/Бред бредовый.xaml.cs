using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ycheb_practika.PRACT3DataSetTableAdapters;

namespace Ycheb_practika
{
    public partial class Бред_бредовый : Window
    {
        StorageTableAdapter storage = new StorageTableAdapter();
        PRACT3Entities2 sstorage = new PRACT3Entities2();


        private bool passedValue;
        public Бред_бредовый(bool passedValue)
        {
            InitializeComponent();

            StorageDataGrid.ItemsSource = storage.GettFullInfo();

            StorageDrg.ItemsSource = sstorage.Storage_View.ToList();


            this.passedValue = passedValue;

            switch (passedValue)
            {
                case true:
                    StorageDataGrid.Visibility = Visibility.Visible;
                    StorageComboBox.Visibility = Visibility.Visible;

                    StorageDrg.Visibility = Visibility.Hidden;
                    StorageCbx.Visibility = Visibility.Hidden;
                    break;

                case false:
                    StorageDataGrid.Visibility = Visibility.Hidden;
                    StorageComboBox.Visibility = Visibility.Hidden;

                    StorageDrg.Visibility = Visibility.Visible;
                    StorageCbx.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StorageDataGrid.Columns[0].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[1].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[3].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[4].Visibility = Visibility.Collapsed;
            StorageDataGrid.Columns[5].Visibility = Visibility.Collapsed;
        }
    }
}


