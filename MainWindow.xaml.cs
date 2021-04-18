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
        int numPage = 1;
        string localBase = @"data.txt";

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            try
            {
                if (new FileInfo(localBase).Exists)
                {
                    parseDataFromTxt();
                    dataDisplay();
                }
                else
                {
                    string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
                    MessageBox.Show("Локального хранилища нет, данные будут загружены с" + url);
                    records = downloadTable();
                    dataDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataDisplay()
        {
            if(numPage == records.Count / recordsCountInPage + 1)
            {
                dataGrid.ItemsSource = records.GetRange((numPage - 1) * recordsCountInPage, records.Count - (numPage - 1) * recordsCountInPage);
            }
            else 
            {
                dataGrid.ItemsSource = records.GetRange((numPage - 1) * recordsCountInPage, recordsCountInPage);
            }

            label.Content = $"Список угроз безопасности({records.Count}):";
            pageInfo.Content = numPage + " / " + (records.Count / recordsCountInPage + 1);
            btnLast.Content = (records.Count / recordsCountInPage + 1);
        }

        private void parseDataFromTxt()
        {
            using (StreamReader file = new StreamReader(localBase, Encoding.Default))
            {
                string data = file.ReadToEnd();
                string[] lines = data.Split('$');

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] threatProperties = lines[i].Split('@');
                    var record = new Record();
                    record.Id = threatProperties[0];
                    record.Name = threatProperties[1];
                    record.Description = threatProperties[2];
                    record.Source = threatProperties[3];
                    record.Destination = threatProperties[4];
                    record.PrivacyViolation = threatProperties[5].Equals("1") ? true : false;
                    record.IntegrityViolation = threatProperties[6].Equals("1") ? true : false;
                    record.AccessViolation = threatProperties[7].Equals("1") ? true : false;
                    records.Add(record);
                }
            }
        }

        private List<Record> downloadTable()
        {
            List<Record> result = null;
            try
            {
                string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(url, "thrlist.xlsx");
                        result = parseDataFromXlsx();
                        MessageBox.Show("Загрузка данных завершена");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return result;
        }

        private List<Record> parseDataFromXlsx()
        {
            List<Record> result = new List<Record>();
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

                        result.Add(record);
                    }
                }
            }
            return result;
        }

        private void dataUpdate(List<Record> newRecords)
        {
            if(newRecords == null)
            {
                return;
            }
            var before = new List<Record>();
            var after = new List<Record>();
            foreach (var item in newRecords)
            {
                var oldrecord = records.Find(t => t.Id == item.Id);
                if(oldrecord == null || !oldrecord.Equals(item))
                {
                    before.Add(oldrecord);
                    after.Add(item);
                }
            }

            if (after.Count == 0)
            {
                MessageBox.Show("Изменений в данных нет");
            }
            else
            {
                LogWindow logWindow = new LogWindow((before, after));
                logWindow.Show();
            }
            records = newRecords;
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            
            dataUpdate(downloadTable());
            dataDisplay();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var record = dataGrid.SelectedItem as Record;
            if (record == null)
            {
                return;
            }

            MessageBox.Show($"Данные об угрозе:\n\nId: {record.Id};\n\nНаименование:\n{record.Name};\n\n"
                + $"Описание:\n{record.Description};\n\nИсточник:\n{record.Source};\n "
                + $"Объект воздействия угрозы:\n{record.Destination};\n\nНарушение конфиденциальности: {record.PrivacyViolation};\n\n"
                + $"Нарушение целостности: {record.IntegrityViolation};\n\nНарушение доступности: {record.AccessViolation};");

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
            numPage = 1;
            dataDisplay();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if(numPage != 1)
            {
                numPage--;
                dataDisplay();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (numPage != records.Count / recordsCountInPage + 1)
            {
                numPage++;
                dataDisplay();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            numPage = records.Count / recordsCountInPage + 1;
            dataDisplay();
        }
    }
}
