using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.VorApplication.Repositories;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.VorApplication.Repositories.Db;

namespace UploadVorToDb.Infrastructure.Database
{
    /// <summary>Логика взаимодействия с БД.</summary>
    public class DbDataModel
    {
        readonly SqlCustomCommands SqlQueries;

        /// <summary>
        /// Экзкмпляр класса DbDataModel.
        /// </summary>
        public DbDataModel() => SqlQueries = new SqlCustomCommands();

        /// <summary>
        /// Экспорт коллекции MainCollection.RecordDataCollection в БД.
        /// </summary>
        public void Export()
        {
            DbSharedParameters sharedParams = new DbSharedParameters();
            InitialData.Connection.Open();

            // Получение максимального значения number_load.
            int maxLoad = SqlQueries.GetMaxNumberLoad();
            if (InitialData.IsNewExport || maxLoad == 0) maxLoad += 1;

            // Временная коллекция, для обеспечения очистки основной коллекции записей.
            List<IUiRecord> list = MainCollection.RecordDataCollection.ToList();
            ICollection<int> ids;
            int index = 0;
            foreach (IUiRecord rec in list)
            {
                ids = SqlQueries.GetAllIds();
                if (ids.Count == 0) 
                    index = 1;
                else
                    index = BinarySearchingId(ids);

                DBRecord recordNew = new DBRecord()
                {
                    DBIdElement = index.ToString(),
                    DBChapter = rec.Chapter,
                    DBTypeElement = DbTaskTypes.Types.Values.ToArray().FirstOrDefault(e => e.Name == rec.WorkNameShort).Code,
                    DBDateTime = DateTime.Now.ToString(),
                    DBVersion = InitialData.Version,
                    DBNumberLoad = maxLoad
                };

                switch (rec.ExportBy)
                {
                    case Domain.Enums.ExportTypes.ByUser:
                        recordNew.DBIdParameter = $"Ручное добавление by {InitialData.User}";
                        break;
                    case Domain.Enums.ExportTypes.ByXlsx:
                        recordNew.DBIdParameter = $"Выгрузка из Excel by {InitialData.User}";
                        break;
                    default: break;
                }

                foreach (var param in sharedParams.ParamFields(rec))
                { 
                    CreateRecordsWithSharedParapeters(recordNew, param);
                }

                MainCollection.RecordDataCollection.Remove(rec);
            }

            InitialData.Connection.Close();
            MessageBox.Show("Выгрузка в базу данных завершена.");
        }

        private void CreateRecordsWithSharedParapeters(DBRecord recordNew, IDBSharedParameter param)
        {
            recordNew.DBNameParameter = param.DbFName;
            recordNew.DBTypeParameter = param.DbFType;
            recordNew.DBValueString = param.DbFValueString;
            recordNew.DBValueDecimal = param.DbFValueDecimal;

            SqlQueries.InsertRecord(recordNew);
        }

        private int BinarySearchingId(ICollection<int> ids)
        {
            int index = 0;
            for (int i = 1; i <= ids.Count + 1; i++)
            {
                index = Array.BinarySearch(ids.ToArray(), (object)i);
                if (ids.Count == 1)
                {
                    index = i + 1; break;
                }
                if (index == 0) continue;
                if (index < 0)
                {
                    index *= (-1); break;
                }
            }
            if (index == 0) index = 1;

            return index;
        }
    }
}

