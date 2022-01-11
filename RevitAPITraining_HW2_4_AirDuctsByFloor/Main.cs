using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_HW2_4_AirDuctsByFloor
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            ElementId level1Id = new ElementId(378117);
            ElementId level2Id = new ElementId(378118);

            var airDucts1 = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Where(e => e.LevelId == level1Id)
                .ToList();

            var airDucts2 = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Where(e => e.LevelId == level2Id)
                .Cast<Duct>()
                .ToList();

            TaskDialog.Show("Информация о воздуховодах", "Количество на 1м эт: " + airDucts1.Count.ToString()
                + Environment.NewLine + "Количество на 2м эт: " + airDucts2.Count.ToString());

            return Result.Succeeded;
        }
    }
}


#region
//ElementId level1Id = new ElementId(378117);
//ElementId level2Id = new ElementId(378118);

//ElementClassFilter ductClassFilter = new ElementClassFilter(typeof(Duct));
//ElementLevelFilter level1Filter = new ElementLevelFilter(level1Id);

//ElementLevelFilter level2Filter = new ElementLevelFilter(level2Id);

//LogicalAndFilter ductFilter1 = new LogicalAndFilter(ductClassFilter, level1Filter);
//LogicalAndFilter ductFilter2 = new LogicalAndFilter(ductClassFilter, level2Filter);

//var airDucts1 = new FilteredElementCollector(doc)
//    .WherePasses(ductFilter1)
//    .Cast<Duct>()
//    .ToList();

//var airDucts2 = new FilteredElementCollector(doc)
//    .WherePasses(ductFilter2)
//    .Cast<Duct>()
//    .ToList();

//TaskDialog.Show("Информация о воздуховодах", "Количество на 1м эт: " + airDucts1.Count.ToString()
//    + Environment.NewLine + "Количество на 2м эт: " + airDucts2.Count.ToString());
#endregion