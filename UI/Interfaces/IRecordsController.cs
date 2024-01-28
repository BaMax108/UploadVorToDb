using System.Collections.Generic;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.UI.Interfaces
{
    /// <summary>Контроллер для управления созданием/изменением записей.</summary>
    public interface IRecordsController
    {
        /// <summary>Открывает окно для выбора настроек чтения файла xlsx.</summary>
        /// <returns>Массив, содержащий название задания, раздел (передающий задание), раздел (которому передается задание).</returns>
        string[] GetTaskInfo();

        /// <summary>Открывает окно для выбора листа, из файла xlsx.</summary>
        /// <param name="sheets">Коллекция названий листов.</param>
        /// <returns>Индекс выбранного листа.</returns>
        int GetSheetIndex(List<string> sheets);

        /// <summary>Открывает окно создания новой записи.</summary>
        void Create();

        /// <summary>Добавление новых записей в основную коллекцию.</summary>
        void Create(IUiRecord record);

        /// <summary>Открывает окно изменения записей.</summary>
        /// <param name="records">Коллекция выбранных записей.</param>
        void Edit(IList<IUiRecord> records);

        /// <summary>Изменение выбранных записей.</summary>
        void Edit(IUiRecord record, IList<IUiRecord> records);

        /// <summary>Удаление выбранных записей.</summary>
        void Delete(IList<IUiRecord> items);

        /// <summary>Загрузка данных из файла xlsx.</summary>
        void LoadFromExcel();

        /// <summary>Плучение наименований заданий.</summary>
        /// <returns>Массив наименований.</returns>
        string[] GetTaskTypes();

        /// <summary>Получение разделов, передающих задание.</summary>
        /// <returns>Массив сокращений.</returns>
        string[] GestTaskFrom();

        /// <summary>Получение разделов, которым передается задание.</summary>
        /// <returns>Массив сокращений.</returns>
        string[] GetTaskTo();

        /// <summary>Получение наименований функциональных частей здания.</summary>
        /// <returns>Массив наименований.</returns>
        string[] GetBuildingPart();

        /// <summary>Получение коллекции единиц измерения.</summary>
        /// <returns>Массив сокращений.</returns>
        string[] GetUnits();
    }
}
