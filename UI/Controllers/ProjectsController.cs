using UploadVorToDb.UI.Views;
using UploadVorToDb.VorApplication.Repositories;
using UploadVorToDb.VorApplication.Repositories.Db;
using System.Linq;

namespace UploadVorToDb.UI.Controllers
{
    /// <summary>Контроллер для управления окном выбора проекта.</summary>
    public class ProjectsController
    {
        /// <summary>Выбор существующего проекта.</summary>
        public void SelectProjectName()
        {
            ProjectsWindow view = new ProjectsWindow(this, GetProjectsNames());
            view.ShowDialog();
            view.Close();
        }

        /// <summary>Изменение наименования текущего проекта.</summary>
        public void SetName(string projectName) => InitialData.SetProjectName(projectName);

        /// <summary>
        /// Получение коллекции проектов.
        /// </summary>
        private string[] GetProjectsNames() => new DbConnectionStrings().ProjectsList.Select(x=>x.Name).ToArray();
    }
}
