using VCRevitRibbonUtil;
using Autodesk.Revit.UI;
using RevitRibbonParametersManager.Properties;


namespace RevitRibbonParametersManager
{
    internal class MainRibbon : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication pPanel)
        {
            pPanel.CreateRibbonTab("Работа с параметрами семейств");
            var applicationRibbon = Ribbon.GetApplicationRibbon(pPanel);
            var pluginTab = applicationRibbon.Tab("Работа с параметрами семейств");

            pluginTab.Panel("Работа с параметрами семейств")

                .CreateButton<batchAddingParameters>("batchAddingParameters", "batchAddingParameters",
                    btn => btn.SetLongDescription("Инструмент для пакетной обработки параметров в семействе")
                    .SetLargeImage(Resources.AddingParametersToFamilyBig).SetSmallImage(Resources.AddingParametersToFamilySmall));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}


