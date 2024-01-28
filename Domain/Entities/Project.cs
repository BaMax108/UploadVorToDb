using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий информацию о проекте.</summary>
    public class Project : IProject
    {
        /// <summary>Инициализатор класса Project.</summary>
        /// <param name="name">Наименование подключения для отображения в пользовательском интерфейсе.</param>
        /// <param name="dbName">Наименование базы данных.</param>
        /// <param name="dbTableName">Наименование таблицы.</param>
        /// <param name="connectionString">Строка подключения.</param>
        public Project(string name, string dbName, string dbTableName, string connectionString)
        {
            Name = name;
            DbName = dbName;
            DBTableName = dbTableName;
            ConnectionString = connectionString;
        }

        /// <summary>Наименование подключения для отображения в пользовательском интерфейсе.</summary>
        public string Name { get; }

        /// <summary>Наименование базы данных.</summary>
        public string DbName { get; }

        /// <summary>Наименование таблицы.</summary>
        public string DBTableName { get; }

        /// <summary>Строка подключения.</summary>
        public string ConnectionString { get; }
    }
}
