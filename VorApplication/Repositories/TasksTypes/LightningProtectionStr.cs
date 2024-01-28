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
    public class LightningProtectionStr : Creator, ITaskType
    {
        private enum WorkName { wn1, wn2, wn3, wn4 }
        private readonly string Code = "МЗ-";
        
        /// <summary></summary>
        public string TaskName => Tasks.Types[Tasks.Type.lightning_protection].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Structural];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.EOM];

        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public LightningProtectionStr() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {
            { WorkName.wn1, "Заземлитель, проложенный скрыто в монолите в пилонах и колоннах Ст.25х4 (в т.ч. горизонтальные пояса по высоте здания)" },
            { WorkName.wn2, "Заземлитель, проложенный скрыто в монолите в фундаментной плите Ст.40х4" },
            { WorkName.wn3, "Горизонтальный заземлитель наружного контура заземления Ст.40х4 (прокладка в земле)" },
            { WorkName.wn4, "Вертикальные заземлители Ст.50х50х5 (1шт.=3,0м), забить и приварить к наружному горизонтальному заземлителю" }
        };

        /// <summary></summary>
        private Dictionary<Built.Part, List<StandardType>> Types => new Dictionary<Built.Part, List<StandardType>>()
        {
            {
                Built.Part.Parking, new List<StandardType>()
                {
                    new StandardType($"{Code}3", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}4", WorkNameDict[WorkName.wn2]),
                    new StandardType($"{Code}5", WorkNameDict[WorkName.wn3]),
                    new StandardType($"{Code}6", WorkNameDict[WorkName.wn4]),
                }
            },
            {
                Built.Part.IndividualHeating, new List<StandardType>()
                {
                    new StandardType($"{Code}7", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}8", WorkNameDict[WorkName.wn2]),
                }
            },
            {
                Built.Part.WithoutTechnology, new List<StandardType>()
                {
                    new StandardType($"{Code}9", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}10", WorkNameDict[WorkName.wn2]),
                }
            },
            {
                Built.Part.LivingAreaPublic, new List<StandardType>()
                {
                    new StandardType($"{Code}11", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}12", WorkNameDict[WorkName.wn2]),
                }
            },
        };
    }
}
