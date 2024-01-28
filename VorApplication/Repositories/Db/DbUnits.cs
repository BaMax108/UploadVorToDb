using System.Collections.Generic;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public class DbUnits
    {
        /// <summary></summary>
        public enum Unit
        {
            /// <summary>Пагонные метры</summary>
            MeterLinear,
            /// <summary>Штуки</summary>
            Pieces,
            /// <summary>Килограммы</summary>
            Kilo
        }

        /// <summary></summary>
        public readonly Dictionary<Unit, string> Units = new Dictionary<Unit, string>()
        {
            { Unit.MeterLinear, "п.м." },
            { Unit.Pieces, "шт." },
            { Unit.Kilo, "кг" },
        };
    }
}
