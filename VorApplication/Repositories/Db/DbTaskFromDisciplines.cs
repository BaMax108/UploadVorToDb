using System.Collections.Generic;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public readonly struct DbTaskFromDisciplines
    {
        /// <summary></summary>
        public enum Discipline : int
        {
            /// <summary>ЭОМ</summary>
            EOM = 0,
            /// <summary>СС</summary>
            SS = 1
        }

        /// <summary></summary>
        public readonly static Dictionary<Discipline, string> Disciplines = new Dictionary<Discipline, string>()
        {
            { Discipline.EOM, "ЭОМ" },
            { Discipline.SS, "СС" }
        };
    }
}
