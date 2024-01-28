namespace UploadVorToDb.Domain.Interfaces
{
    /// <summary>Интерфейс, содержащий информацию о проекте.</summary>
    public interface IProject
    {
        /// <summary>Наименование подключения для отображения в пользовательском интерфейсе.</summary>
        string Name { get; }

        /// <summary>Наименование базы данных.</summary>
        string DbName { get; }

        /// <summary>Наименование таблицы.</summary>
        string DBTableName { get; }

        /// <summary>Строка подключения.</summary>
        string ConnectionString { get; }
    }
}
