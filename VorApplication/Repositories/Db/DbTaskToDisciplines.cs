using System.Collections.Generic;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public readonly struct DbTaskToDisciplines
    {
        /// <summary></summary>
        public enum Discipline
        {
            /// <summary>АР</summary>
            Architecture = 0,
            /// <summary>КР</summary>
            Structural = 1
        }

        /// <summary></summary>
        public readonly static Dictionary<Discipline, string> Chapters = new Dictionary<Discipline, string>() 
        {
            { Discipline.Architecture, "АР" },
            { Discipline.Structural, "КР" }
        };
    }
}
