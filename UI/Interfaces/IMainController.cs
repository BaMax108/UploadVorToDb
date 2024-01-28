using System.Collections.Generic;
using System.Collections.ObjectModel;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.UI.Interfaces
{
    /// <summary>Контроллер для управления основным окном прилодения.</summary>
    public interface IMainController
    {
        /// <summary>Открывает основное окно приложения.</summary>
        void Run();

        /// <summary>Создание записи.</summary>
        void Create();

        /// <summary>Изменение выбранных записей.</summary>
        void Edit(IList<IUiRecord> r);
        
        /// <summary>Удаление выбранных записей.</summary>
        void Delete(IList<IUiRecord> items);

        /// <summary>Выбор наименования проекта.</summary>
        void SelectProjectName();
        
        /// <summary>Загрузка данных из файла xlsx./</summary>
        void LoadFromExcel();

        /// <summary>Экспорт данных в БД.</summary>
        void Export();
        
        /// <summary>Получение имени текущего пользователя.</summary>
        string GetUserName();

        /// <summary>Получение наименования проекта.</summary>
        string GetProjectName();

        /// <summary>Получение коллекции записей.</summary>
        ObservableCollection<IUiRecord> Get();
    }
}
