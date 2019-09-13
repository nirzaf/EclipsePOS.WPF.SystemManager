using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager
{
    public class Bootstrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            shell.Show();
            return shell;
         }

        protected override IModuleCatalog GetModuleCatalog()
        {
           // ModuleCatalog catalog = new ModuleCatalog().AddModule(typeof(HelloWorld.HelloWorldModule)); 
            ModuleCatalog catalog = new ModuleCatalog().AddModule(typeof(EclipsePOS.WPF.SystemManager.Infrastructure.InfrastructureModule));
               catalog.AddModule(typeof(EclipsePOS.WPF.SystemManager.PosSetup.PosSetupModule) );
               catalog.AddModule(typeof(EclipsePOS.WPF.SystemManager.Inventory.InventoryModule));
               catalog.AddModule(typeof(EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportsModule));
               //catalog.AddModule(typeof(EclipsePOS.AccpacDataSync.AccpacDataSyncModule));
              // catalog.AddModule(typeof(EclipsePOS.PosDataSync.Client.ClientModule));
            return catalog;
        }

    }


}
