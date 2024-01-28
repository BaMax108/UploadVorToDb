using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.VorApplication.UseCasaes.Builder
{
    /// <summary></summary>
    public class StructureBuilder
    {
        // Example TasksDictionary["TaskName"]["DisciplineFrom"]["DisciplineTo"]["BuiltPart"]
        /// <summary></summary>
        public Dictionary<string, 
            Dictionary<string, 
                Dictionary<string, 
                    Dictionary<string, List<IElementFields>>>>>
            Repository { get; }

        /// <summary></summary>
        public StructureBuilder()
        {
            Repository = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, List<IElementFields>>>>>();
            Searching();
        }

        private void Searching()
        {
            foreach (Type type in Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == "UploadVorToDb.VorApplication.Repositories.TasksTypes")
                .ToArray())
            {
                if (type == null) continue;
                if (Activator.CreateInstance(Type.GetType(type.FullName)) is ITaskType targetObject) Builder(targetObject);
            }
        }

        private void Builder(ITaskType type)
        {
            if (Repository == null) return;
            if (Repository.ContainsKey(type.TaskName))
            {
                if (Repository[type.TaskName].ContainsKey(type.Chapter))
                {
                    if (Repository[type.TaskName][type.Chapter].ContainsKey(type.Discipline))
                    {
                        foreach (var builtPart in Repository[type.TaskName][type.Chapter][type.Discipline].Keys)
                        {
                            if (Repository[type.TaskName][type.Chapter][type.Discipline].ContainsKey(builtPart))
                            { 
                                Repository[type.TaskName][type.Chapter][type.Discipline][builtPart].AddRange(type.WorkProperties[builtPart]);
                            }
                            else
                            { 
                                Repository[type.TaskName][type.Chapter][type.Discipline].Add(builtPart, type.WorkProperties[builtPart]);
                            }
                        }
                    }
                    else
                    { 
                        Repository[type.TaskName][type.Chapter].Add(type.Discipline, type.WorkProperties);
                    }
                }
                else
                { 
                    Repository[type.TaskName].Add(type.Chapter, new Dictionary<string, Dictionary<string, List<IElementFields>>>
                    {
                        { type.Discipline, type.WorkProperties }
                    });
                }
            }
            else
            {
                Repository.Add(type.TaskName, new Dictionary<string, Dictionary<string, Dictionary<string, List<IElementFields>>>>
                {
                    {
                        type.Chapter, new Dictionary<string , Dictionary <string, List<IElementFields>>>
                        {
                            { type.Discipline, type.WorkProperties }
                        } 
                    }
                });
            }
        }
    }
}
