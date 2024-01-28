using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using UploadVorToDb.UI.Controllers;
using UploadVorToDb.VorApplication.Repositories;

namespace UploadVorToDb
{
    /// <summary></summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        /// <summary>
        /// Overload this method to implement and external command within Revit.
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            InitialData.SetUserName(new UIApplication(commandData.Application.Application).Application.Username);

            new MainController().Run();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            return Result.Succeeded;
        }
    }
}
