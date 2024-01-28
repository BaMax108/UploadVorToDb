using UploadVorToDb.Infrastructure.Database;
using UploadVorToDb.UI.Views;
using UploadVorToDb.VorApplication.Repositories;

namespace UploadVorToDb.UI.Controllers
{
    /// <summary>Контроллер для управления экспортом данных в БД.</summary>
    public class ExportController
    {
        /// <summary>
        /// Экземпляр класса ExportController, открывает окно выбора типа экспорта.
        /// </summary>
        public ExportController()
        { 
            var exportWin = new SelectExportTypeWindow(this);
            exportWin.ShowDialog();
            exportWin.Close();
        }

        /// <summary>Экспорт данных в БД.</summary>
        public void Export() => new DbDataModel().Export();

        /// <summary>Изменение типа экспорта.</summary>
        public void SetExportType(bool isNew) => InitialData.IsNewExport = isNew;
    }
}
