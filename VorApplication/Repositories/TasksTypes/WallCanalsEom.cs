using System.Collections.Generic;
using Built = UploadVorToDb.VorApplication.Repositories.Db.DbBuildingParts;
using TaskFrom = UploadVorToDb.VorApplication.Repositories.Db.DbTaskFromDisciplines;
using TaskTo = UploadVorToDb.VorApplication.Repositories.Db.DbTaskToDisciplines;
using Tasks = UploadVorToDb.VorApplication.Repositories.Db.DbTaskTypes;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.VorApplication.Repositories.TasksTypes
{
    /// <summary></summary>
    public class WallCanalsEom : Creator, ITaskType
    {
        private enum WorkName { wn1, wn2, wn3, wn4, wn5, wn6, wn7 }
        private readonly string Code = "ШТР-Э-";
        
        /// <summary></summary>
        public string TaskName => Tasks.Types[Tasks.Type.wall_canal].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Architecture];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.EOM];

        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public WallCanalsEom() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {   //               Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 16 мм.)
            { WorkName.wn1, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 16 мм)" },
            { WorkName.wn2, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 20 мм)" },
            { WorkName.wn3, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 25 мм)" },
            { WorkName.wn4, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 32 мм)" },
            { WorkName.wn5, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (д. 40 мм)" },
            { WorkName.wn6, "Установка распаечных коробок скрыто в штробе (Ø91×50 мм)" },
            { WorkName.wn7, "Сверление отверстий в строительных конструкциях из кирпича установками алмазного сверления, диаметр кольцевого алмазного сверла 40 мм" }
        };

        /// <summary></summary>
        private Dictionary<Built.Part, List<StandardType>> Types => new Dictionary<Built.Part, List<StandardType>>()
        {
            { 
                Built.Part.Parking, new List<StandardType>()
                {
                    new StandardType($"{Code}1", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}2", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}3", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}4", WorkNameDict[WorkName.wn4]),
                    new StandardType($"{Code}5", WorkNameDict[WorkName.wn5]),
                    new StandardType($"{Code}6", WorkNameDict[WorkName.wn6]),
                    new StandardType($"{Code}7", WorkNameDict[WorkName.wn7])
                }
            },
            {
                Built.Part.Dispatching, new List<StandardType>()
                {
                    new StandardType($"{Code}8", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}9", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}10", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}11", WorkNameDict[WorkName.wn4]),
                    new StandardType($"{Code}12", WorkNameDict[WorkName.wn5]),
                    new StandardType($"{Code}13", WorkNameDict[WorkName.wn6]),
                    new StandardType($"{Code}14", WorkNameDict[WorkName.wn7])
                }
            },
            {
                Built.Part.InformationCenter, new List<StandardType>()
                {
                    new StandardType($"{Code}15", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}16", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}17", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}18", WorkNameDict[WorkName.wn4]),
                    new StandardType($"{Code}19", WorkNameDict[WorkName.wn5]),
                    new StandardType($"{Code}20", WorkNameDict[WorkName.wn6]),
                    new StandardType($"{Code}21", WorkNameDict[WorkName.wn7])
                }
            },
            {
                Built.Part.LivingAreaApartment, new List<StandardType>()
                {
                    new StandardType($"{Code}22", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}23", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}24", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}25", WorkNameDict[WorkName.wn4]),
                    new StandardType($"{Code}26", WorkNameDict[WorkName.wn5]),
                    new StandardType($"{Code}27", WorkNameDict[WorkName.wn6]),
                    new StandardType($"{Code}28", WorkNameDict[WorkName.wn7])
                }
            },
            {
                Built.Part.LivingAreaPublic, new List<StandardType>()
                {
                    new StandardType($"{Code}29", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}30", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}31", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}32", WorkNameDict[WorkName.wn4]),
                    new StandardType($"{Code}34", WorkNameDict[WorkName.wn5]),
                    new StandardType($"{Code}35", WorkNameDict[WorkName.wn6]),
                    new StandardType($"{Code}36", WorkNameDict[WorkName.wn7])
                } 
            },
        };
    }
}
