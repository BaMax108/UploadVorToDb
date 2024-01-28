using System.Windows;
using UploadVorToDb.UI.Controllers;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectExportTypeWindow.xaml
    /// </summary>
    public partial class SelectExportTypeWindow : Window
    {
        readonly ExportController Controller;

        /// <summary>
        /// Экземпляр класса SelectExportTypeWindow - окно выбора проекта.
        /// </summary>
        public SelectExportTypeWindow(ExportController controller)
        { 
            InitializeComponent();
            Controller = controller;
            RadBtnOld.IsChecked = true;
        } 

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void RadBtnNew_Checked(object sender, RoutedEventArgs e) => Controller.SetExportType(true);

        private void RadBtnOld_Checked(object sender, RoutedEventArgs e) => Controller.SetExportType(false);
    }
}
