using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using ExcelDataReader;
using System.Data;

namespace SecurityTableParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Record> records = new List<Record>();
        int recordsCountInPage = 20;
        string localBase = @"data.txt";

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            try
            {
                download();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataDisplay()
        {
            using (var stream = File.Open("thrlist.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    DataTableCollection tableCollection = dataSet.Tables;
                    DataTable dataTable = tableCollection[0];

                    for (int i = 1; i < dataTable.Rows.Count; i++)
                    {
                        var record = new Record();
                        Object[] itemArray = dataTable.Rows[i].ItemArray;
                        record.Id = "УБИ." + itemArray[0].ToString();
                        record.Name = itemArray[1].ToString();
                        record.Description = itemArray[2].ToString();
                        record.Source = itemArray[3].ToString();
                        record.Destination = itemArray[4].ToString();
                        record.PrivacyViolation = itemArray[5].ToString().Equals("1") ? true : false;
                        record.IntegrityViolation = itemArray[6].ToString().Equals("1") ? true : false;
                        record.AccessViolation = itemArray[7].ToString().Equals("1") ? true : false;

                        records.Add(record);
                    }
                }
            }

            dataGrid.ItemsSource = records.GetRange(0, recordsCountInPage);
            pageInfo.Content = "1 - " + recordsCountInPage + " / " + records.Count;
        }

        private void download()
        {
            try
            {
                string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";

                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(url, "thrlist.xlsx");
                        MessageBox.Show("Загрузка данных завершена");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }

                dataDisplay();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void save()
        {

        }



        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            download();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (records == null || records.Count == 0)
                {
                    MessageBox.Show("Нет данных");
                }
                else
                {
                    using (var file = File.Create(localBase)) { }

                    using (StreamWriter sw = new StreamWriter(localBase, false, System.Text.Encoding.Default))
                    {
                        for (int i = 0; i < records.Count - 1; i++)
                        {
                            sw.Write(records[i].ToString() + "$");
                        }
                        sw.Write(records[records.Count - 1].ToString());
                    }
                    MessageBox.Show("Данные сохранены в локальном хранилище");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
