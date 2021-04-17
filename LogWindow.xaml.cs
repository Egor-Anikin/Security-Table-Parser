using System;
using System.Collections.Generic;
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

namespace SecurityTableParser
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {

        List<Record> before;
        List<Record> after;

        public LogWindow(Object obj)
        {
            InitializeComponent();
            var pair = ((List<Record>, List<Record>))obj;
            before = pair.Item1;
            after = pair.Item2;
            dataGrid.ItemsSource = after;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var record = dataGrid.SelectedItem as Record;
            if (record == null)
            {
                return;
            }

            var record2 = before[after.IndexOf(record)];
            if (record2 == null)
            {
                MessageBox.Show($"Данные об угрозе:\n id: {record.Id};\n name: {record.Name};\n"
                    + $"description: {record.Description};\n source: {record.Source};\n "
                    + $"destination: {record.Destination};\n privacy violation: {record.PrivacyViolation};\n"
                    + $"integrity violation: {record.IntegrityViolation};\n access violation: {record.AccessViolation};\n");
                return;
            }
         
            string str = $"Данные об угрозе:\n id: {record.Id};\n";
            str += recordEq("name", record2.Name, record.Name);
            str += recordEq("description", record2.Description, record.Description);
            str += recordEq("source", record2.Source, record.Source);
            str += recordEq("destination", record2.Destination, record.Destination);
            str += recordEq("privacy violation", record2.PrivacyViolation.ToString(), record.PrivacyViolation.ToString());
            str += recordEq("integrity violation", record2.IntegrityViolation.ToString(), record.IntegrityViolation.ToString());
            str += recordEq("access violation", record2.AccessViolation.ToString(), record.AccessViolation.ToString());
            MessageBox.Show(str);


        }

        private string recordEq(string name, string str1, string str2)
        {
            if (str1 == str2)
            {
                return $"{name}: {str1};\n";
            }
            else
            {
                return $"{name} before: {str1};\n {name} after: {str2};\n";
            }
        }
    }
}
