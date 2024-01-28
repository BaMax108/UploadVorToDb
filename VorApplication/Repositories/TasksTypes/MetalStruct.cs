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
    public class MetalStruct : Creator, ITaskType
    {
        private enum WorkName { wn1, wn2 }
        private readonly string Code = "МК-";
        
        /// <summary></summary>
        public string TaskName => Tasks.Types[Tasks.Type.metal_struct].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Structural];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.EOM];

        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public MetalStruct() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {
            { WorkName.wn1, "Металлоконструкции для установки ВРУ на высоте 400мм от уровня пола (в подвале от затопления)" },
            { WorkName.wn2, "Металлоконструкции для опуска в кабельный приямок (лючок, лестница)" }
        };

        /// <summary></summary>
        private Dictionary<Built.Part, List<StandardType>> Types => new Dictionary<Built.Part, List<StandardType>>()
        {
            {
                Built.Part.Parking, new List<StandardType>()
                {
                    new StandardType($"{Code}01", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}02", WorkNameDict[WorkName.wn2]),
                }
            },
            {
                Built.Part.WithoutTechnology, new List<StandardType>()
                {
                    new StandardType($"{Code}03", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}04", WorkNameDict[WorkName.wn2]),
                }
            },
            {
                Built.Part.LivingAreaPublic, new List<StandardType>()
                {
                    new StandardType($"{Code}05", WorkNameDict[WorkName.wn1]),
                    new StandardType($"{Code}06", WorkNameDict[WorkName.wn2]),
                }
            },
        };
    }
}
