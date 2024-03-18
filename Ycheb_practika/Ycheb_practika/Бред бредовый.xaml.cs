using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    /// <summary>
    /// Логика взаимодействия для Бред_бредовый.xaml
    /// </summary>
    public partial class Бред_бредовый : Window
    {
        StorageTableAdapter storage = new StorageTableAdapter();
        PRACT3Entities1 sstorage = new PRACT3Entities1();

        private bool passedValue;
        public Бред_бредовый(bool passedValue)
        {
            InitializeComponent();

            StorageDataGrid.ItemsSource = storage.GetData();
            StorageComboBox.ItemsSource = storage.GetData();
            StorageComboBox.DisplayMemberPath = "price";

            StorageDrg.ItemsSource = sstorage.Storage.ToList();
            StorageCbx.ItemsSource = sstorage.Storage.ToList();
            StorageCbx.DisplayMemberPath = "price";

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
    }
}


