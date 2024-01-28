using System.Collections.Generic;
using System.Linq;
using UploadVorToDb.UI.Views;
using UploadVorToDb.UI.Interfaces;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.VorApplication.UseCasaes.Excel;
using UploadVorToDb.VorApplication.Repositories.Db;
using UploadVorToDb.VorApplication.Repositories;

namespace UploadVorToDb.UI.Controllers
{
    /// <summary>Контроллер для управления созданием/изменением записей.</summary>
    public class RecordsController : IRecordsController
    {
        private readonly IRecordsController Controller;
        private CreateRecordWindow CreateRecordView;

        /// <summary>Экземпляр класса RecordsController.</summary>
        public RecordsController() => Controller = this;

        /// <summary>Открывает окно для выбора настроек чтения файла xlsx.</summary>
        /// <returns>Массив, содержащий название задания, раздел (передающий задание), раздел (которому передается задание).</returns>
        public string[] GetTaskInfo()
        {
            var taskWnd = new SelectTaskWindow(
                DbTaskTypes.Types.Values.Select(x => x.Name).ToArray(),
                DbTaskFromDisciplines.Disciplines.Values.ToArray(),
                DbTaskToDisciplines.Chapters.Values.ToArray());
            taskWnd.ShowDialog();
            string[] result = new string[] { taskWnd.TaskName, taskWnd.Discipline, taskWnd.Chapter };
            taskWnd.Close();
            return result;
        }

        /// <summary>Открывает окно для выбора листа, из файла xlsx.</summary>
        /// <param name="sheets">Коллекция названий листов.</param>
        /// <returns>Индекс выбранного листа.</returns>
        public int GetSheetIndex(List<string> sheets)
        {
            var sheetWnd = new SelectSheetWindow(sheets);
            sheetWnd.ShowDialog();
            int sheetIndex = sheetWnd.SheetIndex;
            sheetWnd.Close();
            if (sheetIndex < 0)
                return 1;
            else
                return sheetIndex;
        }

        /// <summary>Открывает окно создания новой записи.</summary>
        public void Create()
        {
            CreateRecordView = new CreateRecordWindow(Controller);
            CreateRecordView.ShowDialog();
            CreateRecordView.Close();
        }

        /// <summary>Добавление новых записей в основную коллекцию.</summary>
        public void Create(IUiRecord r) => MainCollection.AddRecord(r);

        /// <summary>Открывает окно изменения записей.</summary>
        /// <param name="records">Коллекция выбранных записей.</param>
        public void Edit(IList<IUiRecord> records)
        {
            CreateRecordView = new CreateRecordWindow(Controller, records);
            CreateRecordView.ShowDialog();
            CreateRecordView.Close();
        }

        /// <summary>Изменение выбранных записей.</summary>
        public void Edit(IUiRecord r, IList<IUiRecord> value) => MainCollection.Edit(r, value);

        /// <summary>Удаление выбранных записей.</summary>
        public void Delete(IList<IUiRecord> items) => MainCollection.Delete(items);

        /// <summary>Загрузка данных из файла xlsx.</summary>
        public void LoadFromExcel()
        {
            ReadTemplate xlsx = new ReadTemplate(this);
            
            xlsx.Run();
            if (xlsx.RecordList == null) return;
            if (xlsx.RecordList.Count > 0 & xlsx.RecordList != null)
            {
                MainCollection.AddRecords(xlsx.RecordList);
            }
        }

        /// <summary>Плучение наименований заданий.</summary>
        /// <returns>Массив наименований.</returns>
        public string[] GetTaskTypes() => DbTaskTypes.Types.Values.Select(x => x.Name).ToArray();

        /// <summary>Получение разделов, передающих задание.</summary>
        /// <returns>Массив сокращений.</returns>
        public string[] GestTaskFrom() => DbTaskFromDisciplines.Disciplines.Values.ToArray();

        /// <summary>Получение разделов, которым передается задание.</summary>
        /// <returns>Массив сокращений.</returns>
        public string[] GetTaskTo() => DbTaskToDisciplines.Chapters.Values.ToArray();

        /// <summary>Получение наименований функциональных частей здания.</summary>
        /// <returns>Массив наименований.</returns>
        public string[] GetBuildingPart() => DbBuildingParts.Parts.Values.Select(e => e.Name).ToArray();

        /// <summary>Получение коллекции единиц измерения.</summary>
        /// <returns>Массив сокращений.</returns>
        public string[] GetUnits() => new DbUnits().Units.Values.ToArray();
    }
}
