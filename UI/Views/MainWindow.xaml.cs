using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.UI.Interfaces;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainController Controller;

        /// <summary>Экземпляр класса MainWindow - основное окно приложения.</summary>
        public MainWindow(IMainController controller)
        {
            Controller = controller;
            InitializeComponent();
            Settings();
        }

        private void Settings()
        {
            TxtBoxCurretUser.Text = $"Текущий пользователь: {Controller.GetUserName()}";
            DataGridMain.DataContext = Controller.Get();
        }

        private void BtnSelectProject_Click(object sender, RoutedEventArgs e)
        {
            Controller.SelectProjectName();
            TxtBoxProjectName.Text = Controller.GetProjectName();
        } 

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Controller.Create();

        private void BtnLoadFromXlsx_Click(object sender, RoutedEventArgs e) => Controller.LoadFromExcel();

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Для изменения необходимо выбрать одну или несколько записей из таблицы."); return;
            }    
            Controller.Edit(DataGridMain.SelectedItems.Cast<IUiRecord>().ToList());   
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Для удаления необходимо выбрать одну или несколько записей из таблицы."); return;
            }
            Controller.Delete(DataGridMain.SelectedItems.Cast<IUiRecord>().ToList());
        }

        private void BtnUploadFromTable_Click(object sender, RoutedEventArgs e) => Controller.Export();

        private void TxtBoxProjectName_TextChanged(object sender, TextChangedEventArgs e) =>
            BtnLoadFromTable.IsEnabled = TxtBoxProjectName.Text != "Проект не выбран";
    }
}
