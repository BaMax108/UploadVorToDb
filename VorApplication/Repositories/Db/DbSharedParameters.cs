using System.Collections.Generic;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary>
    /// Структура, содержащая общие параметры для выгрузки в БД.
    /// </summary>
    public class DbSharedParameters
    {
        /// <summary>
        /// Шаблон для выгрузки общих параметров.
        /// </summary>
        public List<IDBSharedParameter> ParamFields(IUiRecord rd)
        {
            return new List<IDBSharedParameter>()
            {
                new DBSharedParameter(
                    "ADSK_Стандарт_Тип",
                    "string",
                    rd.StandardType,
                    0m),
                new DBSharedParameter(
                    "ADSK_ВОР_Назначение",
                    "string",
                    rd.Assignment,
                    0m),
                new DBSharedParameter(
                    "ADSK_Секция",
                    "string",
                    rd.Section,
                    0m),
                new DBSharedParameter(
                    "ADSK_Единица измерения",
                    "string",
                    rd.Units,
                    0m),
                new DBSharedParameter(
                    "ADSK_Количество",
                    "decimal",
                    "'NULL'",
                    rd.Count)
            };
        }
    }
}
