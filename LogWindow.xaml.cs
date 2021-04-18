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
            label.Content = $"Изменённые угрозы({after.Count}):";
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
                MessageBox.Show($"Данные об угрозе:\n\nId: {record.Id};\n\nНаименование:\n{record.Name};\n\n"
                + $"Описание:\n{record.Description};\n\nИсточник:\n{record.Source};\n "
                + $"Объект воздействия угрозы:\n{record.Destination};\n\nНарушение конфиденциальности: {record.PrivacyViolation};\n\n"
                + $"Нарушение целостности: {record.IntegrityViolation};\n\nНарушение доступности: {record.AccessViolation};");
                return;
            }
         
            string str = $"Данные об угрозе:\n\nId: {record.Id};\n\n";
            str += recordEq("Наименование:\n", record2.Name, record.Name);
            str += recordEq("Описание:\n", record2.Description, record.Description);
            str += recordEq("Источник:\n", record2.Source, record.Source);
            str += recordEq("Объект воздействия угрозы:\n", record2.Destination, record.Destination);
            str += recordEq("Нарушение конфиденциальности: ", record2.PrivacyViolation.ToString(), record.PrivacyViolation.ToString());
            str += recordEq("Нарушение целостности: ", record2.IntegrityViolation.ToString(), record.IntegrityViolation.ToString());
            str += recordEq("Нарушение доступности: ", record2.AccessViolation.ToString(), record.AccessViolation.ToString());
            MessageBox.Show(str);


        }

        private string recordEq(string name, string str1, string str2)
        {
            if (str1 == str2)
            {
                return $"{name}{str1};\n\n";
            }
            else
            {
                return $"Было {name}{str1};\nСтало{name}{str2};\n\n";
            }
        }
    }
}
