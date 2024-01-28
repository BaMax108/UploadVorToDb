using UploadVorToDb.UI.Views;
using UploadVorToDb.UI.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.VorApplication.Repositories;

namespace UploadVorToDb.UI.Controllers
{
    /// <summary>Контроллер для управления основным окном приложения.</summary>
    public class MainController : IMainController
    {
        readonly IMainController Controller;

        /// <summary>Экземпляр класса MainController.</summary>
        public MainController() => Controller = this;

        /// <summary>Открывает основное окно приложения.</summary>
        public void Run()
        {
            var win = new MainWindow(Controller);
            win.ShowDialog();
            win.Close();
        }

        #region CRUD

        /// <summary>Создание записи.</summary>
        public void Create() => new RecordsController().Create();

        /// <summary>Получение коллекции записей.</summary>
        public ObservableCollection<IUiRecord> Get() => MainCollection.RecordDataCollection;

        /// <summary>Изменение выбранных записей.</summary>
        public void Edit(IList<IUiRecord> i) => new RecordsController().Edit(i);

        /// <summary>Удаление выбранных записей.</summary>
        public void Delete(IList<IUiRecord> items) => new RecordsController().Delete(items);

        #endregion

        /// <summary>Загрузка данных из файла xlsx./</summary>
        public void LoadFromExcel() => new RecordsController().LoadFromExcel();

        /// <summary>Экспорт данных в БД.</summary>
        public void Export()
        {
            if (MainCollection.RecordDataCollection.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для выгрузки в БД."); return;
            }
            if (InitialData.ProjectName == null)
            {
                MessageBox.Show("Проект не выбран."); return;
            }

            new ExportController().Export();
        }

        /// <summary>Выбор наименования проекта.</summary>
        public void SelectProjectName() => new ProjectsController().SelectProjectName();

        /// <summary>Получение наименования проекта.</summary>
        public string GetProjectName() => InitialData.ProjectName;
        
        /// <summary>Получение имени текущего пользователя.</summary>
        public string GetUserName() => InitialData.User;
    }
}
