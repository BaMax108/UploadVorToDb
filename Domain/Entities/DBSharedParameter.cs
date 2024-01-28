using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary>
    /// Тип, содержащий поля, описывающие общие параметры, выгружаемые в БД.
    /// </summary>
    public class DBSharedParameter : IDBSharedParameter
    {
        /// <summary></summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="valueString"></param>
        /// <param name="valueDecimal"></param>
        public DBSharedParameter(string name, string type, string valueString, decimal valueDecimal) 
        { 
            DbFName = name;
            DbFType = type;
            DbFValueString = valueString;
            DbFValueDecimal = valueDecimal;
        }

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string DbFName { get; }

        /// <summary>
        /// Тип данных.
        /// </summary>
        public string DbFType { get; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string DbFValueString { get; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public decimal DbFValueDecimal { get; }
    }
}
