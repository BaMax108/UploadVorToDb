using System.ComponentModel;
using UploadVorToDb.Domain.Enums;

namespace UploadVorToDb.Domain.Interfaces
{
    /// <summary>Интерфейс, содержащий данные для отображения в пользовательском интерфейсе.</summary>
    public interface IUiRecord : INotifyPropertyChanged
    {
        /// <summary>Уникальный идентификатор.</summary>
        int Id { get; set; }

        /// <summary>Наименование задания.</summary>
        string WorkNameShort { get; set; }

        /// <summary>Раздел, передающий задание.</summary>
        string Discipline { get; set; }

        /// <summary>Раздел, которому передается задание.</summary>
        string Chapter { get; set; }

        /// <summary>Функциональная часть здания.</summary>
        string BuildingPart { get; set; }

        /// <summary>Наименование вида работ.</summary>
        string WorkNameFull { get; set; }

        /// <summary>CGN_Стандарт_Тип.</summary>
        string StandardType { get; set; }

        /// <summary>CGN_ВОР_Назначение.</summary>
        string Assignment { get; set; }

        /// <summary>CGN_Секция.</summary>
        string Section { get; set; }

        /// <summary>CGN_Описание.</summary>
        string Discription { get; set; }

        /// <summary>ADSK_Единица измерения.</summary>
        string Units { get; set; }

        /// <summary>ADSK_Количество.</summary>
        decimal Count { get; set; }

        /// <summary></summary>
        ExportTypes ExportBy { get; set; }
    }
}
