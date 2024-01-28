using System.Windows;
using System.Windows.Controls;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectTaskWindow.xaml
    /// </summary>
    public partial class SelectTaskWindow : Window
    {
        /// <summary>Наименование задания.</summary>
        public string TaskName { get; private set; }
        /// <summary>Раздел, которому передается задание.</summary>
        public string Chapter { get; private set; }
        /// <summary>Раздел, передающий задание.</summary>
        public string Discipline { get; private set; }

        /// <summary>
        /// Экземпляр класса SelectTaskWindow - окно выбора настроек чтения файла xlsx.
        /// </summary>
        public SelectTaskWindow(string[] _tasks, string[] _disciplines, string[] _chapters)
        {
            InitializeComponent();
            ComboBoxTaskName.ItemsSource = _tasks;
            ComboBoxTaskFrom.ItemsSource = _disciplines;
            ComboBoxTaskTo.ItemsSource = _chapters;
        }

        private void ComboBoxTaskName_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            TaskName = e.AddedItems?[0].ToString();

        private void ComboBoxTaskTo_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            Chapter = e.AddedItems?[0].ToString();


        private void ComboBoxTaskFrom_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            Discipline = e.AddedItems?[0].ToString();

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
