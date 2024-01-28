using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий поля для выгрузки в БД.</summary>
    public class DBRecord : IDBRecord
    {
        /// <summary>
        /// Сквозной идентификатор.
        /// </summary>
        public int DBId { get; set; }

        /// <summary>
        /// Идентификатор операции.
        /// </summary>
        public string DBIdElement { get; set; }

        /// <summary>
        /// Целевой раздел.
        /// </summary>
        public string DBChapter { get; set; }

        /// <summary>
        /// Тип элемента.
        /// </summary>
        public string DBTypeElement { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string DBIdParameter { get; set; }

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string DBNameParameter { get; set; }

        /// <summary>
        /// Тип данных.
        /// </summary>
        public string DBTypeParameter { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string DBValueString { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public decimal DBValueDecimal { get; set; }

        /// <summary>
        /// Время создания записи в БД.
        /// </summary>
        public string DBDateTime { get; set; }

        /// <summary>
        /// Версия ВОР.
        /// </summary>
        public string DBVersion { get; set; }

        /// <summary>
        /// Номер выгрузки/обновления записи.
        /// </summary>
        public int DBNumberLoad { get; set; }
    }
}
