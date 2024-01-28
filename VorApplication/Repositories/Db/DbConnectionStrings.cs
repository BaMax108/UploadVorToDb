using System.Collections.Generic;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.Domain.Interfaces;

namespace UploadVorToDb.VorApplication.Repositories.Db
{
    /// <summary></summary>
    public class DbConnectionStrings
    {
        /// <summary></summary>
        public readonly List<IProject> ProjectsList = new List<IProject>()
        {
            new Project(@"Test__Db", 
                "TestDb", 
                "TableTest",
                @"Server=(localdb)\MSSQLLocalDB;Database=TestDb;Trusted_Connection=true;Pooling=true;MultipleActiveResultSets=true")
        };
    }
}
