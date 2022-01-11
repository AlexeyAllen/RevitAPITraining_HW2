using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_HW2_1_AirDuctsCount
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;


            var airDucts = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Cast<Duct>()
                .ToList();

            TaskDialog.Show("Информация о воздуховодах", airDucts.Count.ToString());

            return Result.Succeeded;
        }
    }
}
