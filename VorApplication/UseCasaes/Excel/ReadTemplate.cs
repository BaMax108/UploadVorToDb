using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.UI.Controllers;
using UploadVorToDb.Domain.Interfaces;
using xl = Microsoft.Office.Interop.Excel;
using UploadVorToDb.VorApplication.Repositories.Db;

namespace UploadVorToDb.VorApplication.UseCasaes.Excel
{
    /// <summary>Класс, определяющий логику чтения файла в формате xlsx.</summary>
    public class ReadTemplate
    {
        /// <summary>Коллекция записей, полученных из файла.</summary>
        public List<IUiRecord> RecordList { get; private set; }

        private readonly RecordsController Controller;
        private string FilePath, Discipline, Chapter, TaskName;
        private xl.Application xlApp;
        private xl.Workbook xlBook;
        private xl._Worksheet xlSheet;

        /// <summary>
        /// Экземпляр класса ReadTemplate.
        /// </summary>
        public ReadTemplate(RecordsController controller)
        {
            Controller = controller;
            RecordList = new List<IUiRecord>();
        }

        /// <summary>Запуск чтения файла.</summary>
        public void Run()
        {
            if (!IsValidData()) return;

            SelectSheet(
                GetSheetList());
            
            GetListFromFile();

            xlBook.Close();
            xlApp.Quit();
        }

        private bool IsValidData()
        {
            string[] taskInfo = Controller.GetTaskInfo();
            TaskName = taskInfo[0];
            if (TaskName == null)
                return ErrorMessage("Тип задания не выбран.");
            
            Discipline = taskInfo[1];
            if (Discipline == null)
                return ErrorMessage("Передающий задание раздел  не выбран.");
            
            Chapter = taskInfo[2];
            if (Chapter == null)
                return ErrorMessage("Раздел не выбран.");
            
            return IsFileInfoValid();
        }

        private bool ErrorMessage(string msg)
        {
            MessageBox.Show(msg);
            return false;
        }
        
        private bool IsFileInfoValid()
        {
            string fileName;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Text files (*.xlsx)|*.xlsx";
                openFileDialog.ShowDialog();
                fileName = openFileDialog.SafeFileName;
                FilePath = openFileDialog.FileName;
            }
            return FilePath != "" && fileName != "" || ErrorMessage("Файл не выбран.");
        }

        /// <summary>
        /// Получение коллекции листов.
        /// </summary>
        /// <returns>Коллекция листов.</returns>
        private List<string> GetSheetList()
        {
            xlApp = new xl.Application();
            List<string> sheets = new List<string>();
            xlBook = xlApp.Workbooks.Open(FilePath, ReadOnly: true);

            foreach (var w in xlBook.Sheets)
            { 
                if(w is xl.Worksheet sheet)
                {
                    sheets.Add(sheet.Name);
                }
            }
            return sheets;
        }

        /// <summary>
        /// Выбор листа для чтения.
        /// </summary>
        /// <param name="sheets">Коллекция листов.</param>
        private void SelectSheet(List<string> sheets) => xlSheet = sheets.Count > 1 ? 
            xlBook.Sheets[sheets[Controller.GetSheetIndex(sheets)]] : xlBook.Sheets[1];

        /// <summary>
        /// Получение коллекции записей из файла.
        /// </summary>
        private void GetListFromFile()
        {
            xl.Range range = xlSheet.UsedRange;
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;

            // Координаты первой ячейки
            int startRow = 3, startColumn = 7;
            // Строки, содержащие функциональное деление и  деление по секциям
            int builtPartRow = 1, sectionsRow = 2;
            // Индексы колонок [№ п/п][Наименование вида работ][Ед.изм.]
            int numberColumn = 4, workColumn = 5, unitsColumn = 6;
            // Название колонки секций, которую следует игнорировать (Все секции, ИТОГО, Общее и т.п.)
            string ignoredSection = "Все секции";

            string section, builtPart, builtPartTemp, workName, units;
            section = builtPart = builtPartTemp = workName = units = string.Empty;
            int cellCount, i, j;
            cellCount = i = j = 0;
            string[] builtParts = DbBuildingParts.Parts.Values.Select(x => x.Name.ToLower()).ToArray();
            dynamic count = 0;

            // Чтение и фильтрация данных
            for (j = startColumn; j <= colCount; j++)
            {
                if (TryToString(range.Cells[builtPartRow, j].Value, out builtPartTemp))
                {
                    builtPart = builtPartTemp;
                    cellCount = range.Cells[builtPartRow, j].MergeArea.Count;
                }

                if (!TryToString(range.Cells[sectionsRow, j].Value, out section)) continue;
                if (cellCount > 1 & section == ignoredSection) continue;

                for (i = startRow; i <= rowCount; i++)
                {
                    if (range.Cells[i, numberColumn].Value != null)
                    { 
                        count = range.Cells[i, j].Value;
                        if (count != null)
                        { 
                            if (decimal.TryParse(count.ToString(), out decimal countDecimal) != null)
                            {
                                if (countDecimal > 0)
                                { 
                                    if (!TryToString(range.Cells[i, workColumn].Value, out workName)) continue;
                                    if (!TryToString(range.Cells[i, unitsColumn].Value, out units)) continue;

                                    if (!builtParts.Contains(builtPart.ToLower())) continue;

                                    AddRecord(builtPart, workName, section, units, (decimal)count);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Добавление валидной записи в коллекцию.
        /// </summary>
        private void AddRecord(string buildingPart, string workName, string section, string units, decimal count)
        {
            if (DbTaskTypes.KeyStrings.ContainsKey(TaskName))
            { 
                foreach (string taskName in DbTaskTypes.KeyStrings[TaskName])
                {
                    if (!workName.StartsWith(taskName)) continue;

                    if(buildingPart == DbBuildingParts.Parts[DbBuildingParts.Part.Parking].Name) section = "Автостоянка";

                    if (section == "Автостоянка" || section.StartsWith("Секци"))
                    { 
                        RecordList.Add(new UiRecord()
                        {
                            Id = 0,
                            Discipline = Discipline,
                            BuildingPart = buildingPart,
                            WorkNameFull = workName,
                            Section = section,
                            Units = units,
                            Count = count,
                            Chapter = Chapter,
                            StandardType = "",
                            Assignment = "",
                            Discription = "",
                            WorkNameShort = TaskName,
                            ExportBy = Domain.Enums.ExportTypes.ByXlsx
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Преобразует динамическое представление в эквивалентное ему текстовое значение.
        /// Возвращает значение, указывающее, успешно ли выполнено преобразование.
        /// </summary>
        /// <param name="value">Значение dynamic.</param>
        /// <param name="result">Результат преобразования.</param>
        /// <returns>
        /// Значение true, если параметр value успешно преобразован; в противном случае — значение false.
        /// </returns>
        private bool TryToString(dynamic value, out string result) => (result = value?.ToString()) != null;
    }
}
