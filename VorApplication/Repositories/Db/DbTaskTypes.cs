using System.Collections.Generic;
using UploadVorToDb.Domain.Entities;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public readonly struct DbTaskTypes
    {
        /// <summary></summary>
        public enum Type
        {
            /// <summary>Штробление стен</summary>
            wall_canal,
            /// <summary>Молниезащита</summary>
            lightning_protection,
            /// <summary>Закладные детали</summary>
            embedded_components,
            /// <summary>Металлоконструкции</summary>
            metal_struct,
            /// <summary>Крепления электроприборов</summary>
            electricalAppliances_bracing,
        }

        /// <summary></summary>
        public static Dictionary<Type, TaskType> Types = new Dictionary<Type, TaskType>
        {
            { 
                Type.wall_canal, 
                new TaskType()
                { 
                    Name = "Штробление стен",
                    Code = "wall_canal" 
                }  
            },
            { 
                Type.lightning_protection, 
                new TaskType()
                { 
                    Name = "Молниезащита", 
                    Code = "lightning_guard"
                }  
            },
            { 
                Type.embedded_components, 
                new TaskType()
                { 
                    Name = "Закладные детали", 
                    Code = "embedded_part"
                }  
            },
            {
                Type.metal_struct,
                new TaskType()
                {
                    Name = "Металлоконструкции",
                    Code = "metal_struct"
                }
            },
            {
                Type.electricalAppliances_bracing,
                new TaskType()
                {
                    Name = "Крепления электроприборов",
                    Code = "electricalAppliances_bracing"
                }
            }
        };

        /// <summary>
        /// Строки для поиска в xlsx.
        /// </summary>
        public static readonly Dictionary<string, List<string>> KeyStrings = new Dictionary<string, List<string>>()
        {
            {
                Types[Type.wall_canal].Name, new List<string>()
                {
                    "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе",
                    "Установка распаечных коробок скрыто в штробе",
                    "Сверление отверстий в строительных конструкциях из кирпича",
                }
            },
            {
                Types[Type.lightning_protection].Name, new List<string>()
                {
                    "Заземлитель, проложенный скрыто в монолите",
                    "Заземлитель, проложенный открыто по строительным основаниям",
                    "Горизонтальный заземлитель",
                    "Горизонтальные заземлители",
                    "Вертикальный заземлитель",
                    "Вертикальные заземлители",
                }
            },
            {
                Types[Type.embedded_components].Name, new List<string>()
                {
                    "Прокладка кабельной линии (КЛ) в трубе в монолите",
                    "Установка распаечных коробок в монолите",
                    "Труба гладкая ПНД",
                    "Коробка универсальная потолочная для заливки в бетон",
                    "Универсальная установочная коробка для заливки в бетон",

                }
            },
            {
                Types[Type.metal_struct].Name, new List<string>()
                {
                    "Металлоконструкции",
                }
            },
            {
                Types[Type.electricalAppliances_bracing].Name, new List<string>()
                {
                    "Комплект из платформы и подвеса для крепления",
                }
            },
        };
    }
}
