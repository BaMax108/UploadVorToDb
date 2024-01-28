using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace UploadVorToDb
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalApplication
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Application : IExternalApplication
    {
        /// <summary>
        /// Implements the on Shutdown event
        /// </summary>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        /// <summary>
        /// Implements the OnStartup event
        /// </summary>
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel panel = RibbonPanel(application);
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            AddButton(panel, thisAssemblyPath,
                "UploadVorToDbButton",
                "Добавить элементв БД",
                "UploadVorToDb.Command",
                "Добавить вручную элемент в базу данных по ВОР",
                new BitmapImage(
                    new Uri(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Autodesk\Revit\Addins\2021\CGN_AddIns\ICO", "Hand32.png"))));

            return Result.Succeeded;
        }

        /// <summary></summary>
        private void AddButton(RibbonPanel panel, string thisAssemblyPath, string btnName, string btnTxt, string btnClassName, string tooltip, BitmapImage img)
        {
            PushButton button = panel.AddItem(new PushButtonData(btnName, btnTxt, thisAssemblyPath, btnClassName)) as PushButton;
            button.ToolTip = tooltip;
            button.LargeImage = img;
        }

        /// <summary></summary>
        public RibbonPanel RibbonPanel(UIControlledApplication a)
        {
            string tab = "ВОР_test";
            a.CreateRibbonTab(tab);
            return a.CreateRibbonPanel(tab, "ВОР");
        }

    }
}