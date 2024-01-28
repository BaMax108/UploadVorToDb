using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectSheetWindow.xaml
    /// </summary>
    public partial class SelectSheetWindow : Window
    {
        /// <summary>Индекс листа.</summary>
        public int SheetIndex { get; private set; }

        /// <summary>
        /// Экземпляр класса SelectSheetWindow - окно выбора листа, содержащегося в файле xlsx.
        /// </summary>
        public SelectSheetWindow(List<string> _sheets)
        {
            InitializeComponent();
            ComboBoxSheets.ItemsSource = _sheets;
        }

        private void ComboBoxSheets_SelectionChanged(object sender, SelectionChangedEventArgs e) => SheetIndex = ComboBoxSheets.SelectedIndex;

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
