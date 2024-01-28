namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий кодовое обозначение и наименование вида работ.</summary>
    public class StandardType
    {
        /// <summary>Инициализатор класса DbStandardType.</summary>
        /// <param name="code">Кодовое обозначение вида работ.</param>
        /// <param name="name">Наименование вида работ.</param>
        public StandardType(string code, string name) 
        { 
            Code = code;
            WorkName = name;
        }

        /// <summary>Кодовое обозначение вида работ.</summary>
        public string Code { get; }

        /// <summary>Наименование вида работ.</summary>
        public string WorkName { get; }
    }
}
