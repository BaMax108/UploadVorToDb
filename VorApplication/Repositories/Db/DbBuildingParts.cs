using System.Collections.Generic;
using UploadVorToDb.Domain.Entities;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public readonly struct DbBuildingParts
    {
        /// <summary></summary>
        public enum Part
        {
            /// <summary>Автостоянка + эвак. выходы.</summary>
            Parking,
            /// <summary>Технические помещения под жилыми секциями.</summary>
            Underground,
            /// <summary>ИТП.</summary>
            IndividualHeating,
            /// <summary>Техпространство.</summary>
            TechnicalFloor,
            /// <summary>ОДС - диспетчеризация.</summary>
            Dispatching,
            /// <summary>ЦИН - центр информирования населения.</summary>
            InformationCenter,
            /// <summary>КП МПТЦ - межотраслевой производственно-технический центр.</summary>
            InterindustryCenter,
            /// <summary>Нежилая надземная часть.</summary>
            Aboveground,
            /// <summary>БКТ - без конкретной технологии. нежилые помещения.</summary>
            WithoutTechnology,
            /// <summary>Типовой этаж.</summary>
            StandardFloor,
            /// <summary>Жилая часть (квартиры).</summary>
            LivingAreaApartment,
            /// <summary>Жилая часть (места общего пользования).</summary>
            LivingAreaPublic,
            /// <summary>Нет соответствия.</summary>
            Unknown
        }

        /// <summary></summary>
        public readonly static Dictionary<Part, BuiltPart> Parts = new Dictionary<Part, BuiltPart>()
        {
            {
                Part.Parking,
                new BuiltPart() { Code = "10",  Name = "Автостоянка + эвак. выходы" }
            },
            {
                Part.Underground,
                new BuiltPart() { Code = "20",  Name = "Технические помещения под жилыми секциями" }
            },
            {
                Part.IndividualHeating,
                new BuiltPart() { Code = "30",  Name = "ИТП" }
            },
            {
                Part.TechnicalFloor,
                new BuiltPart() { Code = "40",  Name = "Техпространство" }
            },
            {
                Part.Dispatching,
                new BuiltPart() { Code = "50",  Name = "ОДС" }
            },
            {
                Part.InformationCenter,
                new BuiltPart() { Code = "60",  Name = "ЦИН" }
            },
            {
                Part.InterindustryCenter,
                new BuiltPart() { Code = "70",  Name = "КП МПТЦ" }
            },
            {
                Part.Aboveground,
                new BuiltPart() { Code = "80",  Name = "Нежилая надземная часть" }
            },
            {
                Part.WithoutTechnology,
                new BuiltPart() { Code = "90",  Name = "БКТ" }
            },
            {
                Part.StandardFloor,
                new BuiltPart() { Code = "100", Name = "Типовые этажи" }
            },
            {
                Part.LivingAreaApartment,
                new BuiltPart() { Code = "100", Name = "Жилая часть (квартиры)" }
            },
            {
                Part.LivingAreaPublic,
                new BuiltPart() { Code = "100", Name = "Жилая часть (места общего пользования)" }
            }
        };
    }
}
