namespace UploadVorToDb.Domain.Interfaces
{
    /// <summary>Интерфейс, содержащий поля, соответствующие полям записи в БД.</summary>
    public interface IElementFields
    {
        /// <summary>Раздел, которому передается задание.</summary>
        string Chapter { get; }
        /// <summary>Раздел, передающий задание.</summary>
        string Discipline { get; }
        /// <summary>Кодовое обозначение вида работ.</summary>
        string StandardType { get; }
        /// <summary>Функциональная часть здания.</summary>
        string BuildingPart { get; }
        /// <summary>Кодовое обозначение функциональной части здания.</summary>
        string Assignment { get; }
        /// <summary>Наименование вида работ.</summary>
        string TaskName { get; }
    }
}
