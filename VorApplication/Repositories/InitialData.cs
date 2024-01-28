using System.Data.SqlClient;

namespace UploadVorToDb.VorApplication.Repositories
{
    /// <summary></summary>
    public struct InitialData
    {
        /// <summary>Версия ВОР.</summary>
        readonly public static string Version = "ВОР1";
        
        /// <summary>Текущий пользователь.</summary>
        public static string User { get; private set; }
        /// <summary>Изменение имени текущего пользователя.</summary>
        public static void SetUserName(string user) => User = user;

        /// <summary>Наименование выбранного проекта.</summary>
        public static string ProjectName { get; private set; }
        /// <summary>Изменение наименования проекта.</summary>
        public static void SetProjectName(string projectName) => ProjectName = projectName;

        /// <summary>Является ли выгружаемое задание новым.</summary>
        public static bool IsNewExport { get; set; }

        /// <summary>Подключение к БД.</summary>
        public static SqlConnection Connection { get; set; }

        /// <summary>Строка подключения к БД.</summary>
        public static string ConnectionString { get; set; }

        /// <summary>Целевая таблица в БД.</summary>
        public static string Table { get; set; }
    }
}
