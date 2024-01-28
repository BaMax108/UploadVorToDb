using System.Collections.Generic;
using Built = UploadVorToDb.VorApplication.Repositories.Db.DbBuildingParts;
using TaskFrom = UploadVorToDb.VorApplication.Repositories.Db.DbTaskFromDisciplines;
using TaskTo = UploadVorToDb.VorApplication.Repositories.Db.DbTaskToDisciplines;
using Tasks = UploadVorToDb.VorApplication.Repositories.Db.DbTaskTypes;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.Domain.Entities;

namespace UploadVorToDb.VorApplication.Repositories.TasksTypes
{
    /// <summary></summary>
    public class ElectricalAppliancesBracingEom : Creator, ITaskType
    {
        private enum WorkName { wn1 }
        private readonly string Code = "КЭ-Э-";

        /// <summary></summary>
        public string TaskName => Tasks.Types[Tasks.Type.electricalAppliances_bracing].Name;
        /// <summary></summary>
        public string Chapter => TaskTo.Chapters[TaskTo.Discipline.Architecture];
        /// <summary></summary>
        public string Discipline => TaskFrom.Disciplines[TaskFrom.Discipline.EOM];
        /// <summary></summary>
        public Dictionary<string, List<IElementFields>> WorkProperties { get; }
        
        /// <summary></summary>
        public ElectricalAppliancesBracingEom() =>
            WorkProperties = SetElementProperties(Types, Chapter, Discipline);

        private readonly Dictionary<WorkName, string> WorkNameDict = new Dictionary<WorkName, string>()
        {
            { WorkName.wn1, "Комплект из платформы и подвеса для крепления осветительного прибора" },
        };

        /// <summary></summary>
        private Dictionary<Built.Part, List<StandardType>> Types => new Dictionary<Built.Part, List<StandardType>>()
        {
            {
                Built.Part.LivingAreaApartment, new List<StandardType>()
                { 
                    new StandardType($"{Code}01", WorkNameDict[WorkName.wn1]) 
                }
            }
        };
    }
}
