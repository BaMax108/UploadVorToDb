using System.Windows;
using System.Windows.Controls;
using UploadVorToDb.UI.Controllers;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {
        private readonly string[] Projects;
        readonly ProjectsController Controller;

        /// <summary>
        /// Экземпляр класса ProjectsWindow - окно выбора проекта.
        /// </summary>
        public ProjectsWindow(ProjectsController controller, string[] projects)
        {
            Controller = controller;
            Projects = projects;
            InitializeComponent();
            Settings();
        }

        private void Settings()
        {
            foreach (var projectName in Projects)
            {
                RadioButton rb = new RadioButton 
                { 
                    GroupName = "RdBttnProjects", 
                    Content = projectName
                };
                rb.Checked += RadioButton_Checked;
                ListBox.Items.Add(rb);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void RadioButton_Checked(object sender, RoutedEventArgs e) => Controller.SetName((sender as RadioButton).Content.ToString());
    }
}
