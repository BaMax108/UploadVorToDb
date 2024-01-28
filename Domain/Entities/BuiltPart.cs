namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий содержащий кодовое обозначение и наименование функциональной части здания.</summary>
    public class BuiltPart
    {
        /// <summary>Наименование.</summary>
        public string Name { get; set; }

        /// <summary>Кодовое обозначение.</summary>
        public string Code { get; set; }
    }
}
