namespace UploadVorToDb.Domain.Interfaces
{
    /// Интерфейс, содержащий поля, описывающие общие параметры, выгружаемые в БД.
    public interface IDBSharedParameter
    {
        /// <summary>
        /// Название параметра.
        /// </summary>
        string DbFName { get; }

        /// <summary>
        /// Тип данных.
        /// </summary>
        string DbFType { get; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        string DbFValueString { get; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        decimal DbFValueDecimal { get; }
    }
}
