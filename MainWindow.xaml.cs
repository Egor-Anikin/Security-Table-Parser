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

namespace SecurityTableParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string localBaseFileFullPath = @"data.txt";
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            try
            {
                if (new FileInfo(localBaseFileFullPath).Exists)
                {
                    dataDisplay();
                    //threatsList = GetDataFromLocalStorage();
                    //dataGrid.ItemsSource = threatsList.Take(numberOfRecPerPage);
                    //int count = threatsList.Take(numberOfRecPerPage).Count();
                    //lblpageInformation.Content = count + " of " + threatsList.Count;
                }
                else
                {
                    download();
                    //save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataDisplay()
        {

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
