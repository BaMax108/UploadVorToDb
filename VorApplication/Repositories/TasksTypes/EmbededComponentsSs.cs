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
    public class EmbededComponentsSs : Creator, ITaskType
    {
        private enum WorkName { wn1, wn2, wn3, wn4 }
        private readonly string Code = "ЗД-СС-";
        
        /// <summary></summary>
        public string TaskName =>Tasks.Types[Tasks.Type.embedded_components].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Structural];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.SS];

        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public EmbededComponentsSs() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {
            { WorkName.wn1, "Прокладка кабельной линии (КЛ) в трубе в монолите (Dy25)" },
            { WorkName.wn2, "Прокладка кабельной линии (КЛ) в трубе в монолите (Dy20)" },
            { WorkName.wn3, "Установка распаечных коробок в монолите 90Х71 h74 (стены)" },
            { WorkName.wn4, "Установка распаечных коробок в монолите 90х71, h114 (потолок)" }
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
                }
            },
            {
                Built.Part.Dispatching, new List<StandardType>()
                {
                    new StandardType($"{Code}4", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}5", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}6", WorkNameDict[WorkName.wn3]),
                }
            },
            {
                Built.Part.InformationCenter, new List<StandardType>()
                {
                    new StandardType($"{Code}7", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}8", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}9", WorkNameDict[WorkName.wn3]),
                }
            },
            {
                Built.Part.LivingAreaApartment, new List<StandardType>()
                {
                    new StandardType($"{Code}10", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}11", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}12", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}13", WorkNameDict[WorkName.wn4]),
                }
            },
            {
                Built.Part.LivingAreaPublic, new List<StandardType>()
                {
                    new StandardType($"{Code}14", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}15", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}16", WorkNameDict[WorkName.wn3]),
                }
            },
        };
    }

}
