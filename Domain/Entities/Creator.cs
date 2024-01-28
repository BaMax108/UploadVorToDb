using System.Collections.Generic;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.VorApplication.Repositories.Db;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary></summary>
    abstract public class Creator
    {
        /// <summary></summary>
        /// <param name="types"></param>
        /// <param name="chapter"></param>
        /// <param name="discipline"></param>
        /// <returns></returns>
        virtual public Dictionary<string, List<IElementFields>> SetElementProperties(Dictionary<DbBuildingParts.Part, List<StandardType>> types, string chapter, string discipline)
        {
            Dictionary<string, List<IElementFields>> result = new Dictionary<string, List<IElementFields>>();
            foreach (var bPart in types.Keys)
            {
                result.Add(DbBuildingParts.Parts[bPart].Name, new List<IElementFields>());
                foreach (var sType in types[bPart])
                {
                    result[DbBuildingParts.Parts[bPart].Name].Add(new ElementFields(chapter, discipline, DbBuildingParts.Parts[bPart], sType));
                }
            }
            return result;
        }
    }
}
