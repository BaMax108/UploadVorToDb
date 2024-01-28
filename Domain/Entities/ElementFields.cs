using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий поля, соответствующие полям записи в БД.</summary>
    public class ElementFields : IElementFields
    {
        /// <summary>
        /// Поля новой записи.
        /// </summary>
        /// <param name="chapter">Раздел которому передается задание.</param>
        /// <param name="discipline">Раздел, передающий задание.</param>
        /// <param name="builtPart">Тип, содержащий наименование функциональной части здания и кодовое обозначение.</param>
        /// <param name="standardType">Тип, содержащий наименование вида работ и кодовое обозначение.</param>
        public ElementFields(string chapter, string discipline, BuiltPart builtPart, StandardType standardType) 
        {
            Chapter = chapter;
            Discipline = discipline;
            BuildingPart = builtPart.Name;
            Assignment = builtPart.Code;
            StandardType = standardType.Code;
            TaskName = standardType.WorkName;
        }

        /// <summary>Раздел, которому передается задание.</summary>
        public string Chapter { get; }

        /// <summary>Раздел, передающий задание.</summary>
        public string Discipline { get; }

        /// <summary>Кодовое обозначение вида работ.</summary>
        public string StandardType { get; }

        /// <summary>Функциональная часть здания.</summary>
        public string BuildingPart { get; }

        /// <summary>Кодовое обозначение функциональной части здания.</summary>
        public string Assignment { get; }

        /// <summary>Наименование вида работ.</summary>
        public string TaskName { get; }
    }
}
