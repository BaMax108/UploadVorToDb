using System.Collections.Generic;

namespace UploadVorToDb.Domain.Interfaces
{
    /// <summary></summary>
    public interface ITaskType
    {
        /// <summary></summary>
        string TaskName { get; }
        /// <summary></summary>
        string Chapter { get; }
        /// <summary></summary>
        string Discipline { get; }
        /// <summary></summary>
        Dictionary<string, List<IElementFields>> WorkProperties { get; }
    }
}
