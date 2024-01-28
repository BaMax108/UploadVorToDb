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
    public class WallCanalsSs : Creator, ITaskType
    {
        private enum WorkName { wn1, wn2, wn3 }
        private readonly string Code = "ШТР-СС-";
        
        /// <summary></summary>
        public string TaskName => Tasks.Types[Tasks.Type.wall_canal].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Architecture];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.SS];

        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public WallCanalsSs() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {
            { WorkName.wn1, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (Dy20)" },
            { WorkName.wn2, "Прокладка кабельной линии (КЛ) в трубе скрыто в штробе (Dy25)" },
            { WorkName.wn3, "Установка распаечных коробок скрыто в штробе 90Х71 h74" },
        };

        /// <summary></summary>
        private Dictionary<Built.Part, List<StandardType>> Types => new Dictionary<Built.Part, List<StandardType>>()
        {
            {
                Built.Part.Parking, new List<StandardType>()
                {
                    new StandardType($"{Code}1", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}2", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}3", WorkNameDict[WorkName.wn3])
                }
            },
            {
                Built.Part.Dispatching, new List<StandardType>()
                {
                    new StandardType($"{Code}4", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}5", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}6", WorkNameDict[WorkName.wn3])
                }
            },
            {
                Built.Part.InformationCenter, new List<StandardType>()
                {
                    new StandardType($"{Code}7", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}8", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}9", WorkNameDict[WorkName.wn3])
                }
            },
            {
                Built.Part.LivingAreaApartment, new List<StandardType>()
                {
                    new StandardType($"{Code}10", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}11", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}12", WorkNameDict[WorkName.wn3])
                }
            },
            {
                Built.Part.LivingAreaPublic, new List<StandardType>()
                {
                    new StandardType($"{Code}13", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}14", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}15", WorkNameDict[WorkName.wn3])
                }
            },
        };
    }
}
