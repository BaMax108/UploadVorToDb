namespace UploadVorToDb.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс, содержащий поля для выгрузки в БД.
    /// </summary>
    public interface IDBRecord
    {
        /// <summary>
        /// Сквозной идентификатор.
        /// </summary>
        int DBId { get; }
        /// <summary>
        /// Идентификатор операции.
        /// </summary>
        string DBIdElement { get; }
        /// <summary></summary>
        string DBChapter { get; }
        /// <summary>
        /// Тип элемента.
        /// </summary>
        string DBTypeElement { get; }
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        string DBIdParameter { get; }
        /// <summary>
        /// Название параметра.
        /// </summary>
        string DBNameParameter { get; }
        /// <summary>
        /// Тип данных.
        /// </summary>
        string DBTypeParameter { get; }
        /// <summary>
        /// Значение параметра.
        /// </summary>
        string DBValueString { get; }
        /// <summary>
        /// Значение параметра.
        /// </summary>
        decimal DBValueDecimal { get; }
        /// <summary>
        /// Время создания записи в БД.
        /// </summary>
        string DBDateTime { get; }
        /// <summary>
        /// Версия ВОР.
        /// </summary>
        string DBVersion { get; }
        /// <summary>
        /// Номер выгрузки/обновления записи.
        /// </summary>
        int DBNumberLoad { get; }
    }
}
