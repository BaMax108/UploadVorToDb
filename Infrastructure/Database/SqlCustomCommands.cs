using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using UploadVorToDb.VorApplication.Repositories;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.VorApplication.Repositories.Db;

namespace UploadVorToDb.Infrastructure.Database
{
    /// <summary>Запросы к БД.</summary>
    public class SqlCustomCommands
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса SqlCustomCommands, 
        /// который создает новое или использует существующее подключение к БД.
        /// </summary>
        public SqlCustomCommands()
        {
            if (InitialData.ProjectName == null) return;
            IProject p = new DbConnectionStrings().ProjectsList.FirstOrDefault(x => x.Name == InitialData.ProjectName);

            // Проверка необходимости создания нового подключения.
            if (InitialData.ConnectionString == p.ConnectionString &
                InitialData.Table == p.DBTableName &
                InitialData.Connection != null) 
                return;

            InitialData.ConnectionString = p.ConnectionString;
            InitialData.Table = p.DBTableName;
            InitialData.Connection = new SqlConnection(InitialData.ConnectionString);
        }

        /// <summary>
        /// Получение коллекции идентификаторов в поле id_element.
        /// </summary>
        /// <returns>Коллекция идентификаторов.</returns>
        public ICollection<int> GetAllIds()
        {
            if (InitialData.Connection.State != ConnectionState.Open)
                InitialData.Connection.Open();

            List<int> strings = new List<int>();
            SqlDataReader reader = new SqlCommand($"SELECT DISTINCT id_element FROM {InitialData.Table} ORDER BY id_element", InitialData.Connection).ExecuteReader();
            while (reader.Read())
            {
                strings.Add(int.Parse(reader["id_element"].ToString()));
            }
            reader.Close();
            strings.Sort();
            return strings;
        }

        #region Get Record

        /// <summary>
        /// Получение максимального значения поля number_load для всех элементов, где поле chapter равно значению ВИС.
        /// </summary>
        /// <returns>Максимальное значение.</returns>
        public int GetMaxNumberLoad()
        {
            if (InitialData.Connection.State != ConnectionState.Open)
                InitialData.Connection.Open();

            SqlCommand cmd = new SqlCommand($@"SELECT MAX(number_load) FROM {InitialData.Table} WHERE chapter = N'ВИС'", InitialData.Connection);
            string obj = cmd.ExecuteScalar().ToString();

            int result = 0;
            if (obj == null || obj == String.Empty)
                return result;
            else
                result = int.Parse(obj);

            return result;
        }

        #endregion

        #region Insert

        /// <summary>
        /// Запрос на создание новой записи.
        /// </summary>
        public void InsertRecord(DBRecord record)
        {
            if (InitialData.Connection.State != ConnectionState.Open)
                InitialData.Connection.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO {InitialData.Table} (" +
                "id_element," +
                "chapter," +
                "type_element," +
                "id_parameter," +
                "name_parameter," +
                "type_parameter," +
                "string_parameter," +
                "decimal_parameter," +
                "date_time," +
                "version," +
                "number_load" +
                ") VALUES (" +
                $"@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", InitialData.Connection);
            command.Parameters.AddRange
                (new SqlParameter[] {
                    new SqlParameter("@p1", record.DBIdElement),
                    new SqlParameter("@p2", "ВИС"),
                    new SqlParameter("@p3", record.DBTypeElement),
                    new SqlParameter("@p4", record.DBIdParameter),
                    new SqlParameter("@p5", record.DBNameParameter),
                    new SqlParameter("@p6", record.DBTypeParameter),
                    new SqlParameter("@p7", record.DBValueString),
                    new SqlParameter("@p8", record.DBValueDecimal),
                    new SqlParameter("@p9", record.DBDateTime),
                    new SqlParameter("@p10", record.DBVersion),
                    new SqlParameter("@p11", record.DBNumberLoad)
                });
            command.ExecuteNonQueryAsync();
        }
        #endregion
    }
}
