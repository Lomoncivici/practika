using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using Practoz5.conditerDataSetTableAdapters;

namespace Practoz5
{
    internal class TableModel
    {
        public string providerName { get; set; }

        public string ContactName { get; set; }

        public int Phone {  get; set; }
    }

    internal class TableModelConverter
    {
        public static T DeserializeObject<T>()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() ==true)
            {
                string json = File.ReadAllText(dialog.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }

    public partial class Import : Window
    {
        ProviderrTableAdapter provod = new ProviderrTableAdapter();
        public Import()
        {
            InitializeComponent();

            IportFile.ItemsSource = provod.GetData();
        }
    }
}
