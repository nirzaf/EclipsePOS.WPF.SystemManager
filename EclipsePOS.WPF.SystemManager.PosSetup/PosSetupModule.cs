using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
// using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.TaskNavigator;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Help;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorDataSource;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOrganization;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOperations;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorWorkbench;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.Defaults;

using System.Windows;
using System.Windows.Controls;



namespace EclipsePOS.WPF.SystemManager.PosSetup
{
    public class PosSetupModule:IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IRegion contentRegion;
        private IPosNavigatorView view;

        public PosSetupModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
           // contentRegion = _regionManager.Regions[Regions.OrganizationTasks];

        }

        public void Initialize()
        {
            
            this.AddDataSourceTab();
            this.AddOrganizationTab();
            this.AddOperationsTab();
            this.AddWorkbenchTab();
        }

       

        private void AddViews()
        {
            
            //Remove the view on main region 
         /*   object mainView = contentRegion.GetView("ActiveView");
            if (mainView != null)
            {
                contentRegion.Remove(mainView);
            }


            var view = _container.Resolve<PosNavigatorView>();
            contentRegion.Add(view, "ActiveView");
            contentRegion.Activate(view);
          * */
        }


        private void AddDataSourceTab()
        {
            //Remove the view on data source task  region 
            IRegion dataSourceTab = _regionManager.Regions[Regions.DataSourceTask];

            var view = _container.Resolve<DataSourceNavView>();
            dataSourceTab.Add(view);
            dataSourceTab.Activate(view);

            IRegion mainRegion = _regionManager.Regions[Regions.DataSourceMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);

        }

        private void AddOrganizationTab()
        {
            //Remove the view on data source task  region 
            IRegion organizationTab = _regionManager.Regions[Regions.OrganizationTasks];

            var view = _container.Resolve<OrganizationNavView>();
            organizationTab.Add(view);
            organizationTab.Activate(view);

            IRegion mainRegion = _regionManager.Regions[Regions.OrganizationMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);

        }

        private void AddOperationsTab()
        {
            //Remove the view on data source task  region 
            IRegion operationsTab = _regionManager.Regions[Regions.OperationTasks];

            var view = _container.Resolve<OperationsNavView>();
            operationsTab.Add(view);
            operationsTab.Activate(view);

            IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);

        }

        private void AddWorkbenchTab()
        {
            //Remove the view on data source task  region 
            IRegion operationsTab = _regionManager.Regions[Regions.WorkbenchTasks];

            var view = _container.Resolve<WorkbenchNavView>();
            operationsTab.Add(view);
            operationsTab.Activate(view);


            IRegion mainRegion = _regionManager.Regions[Regions.WorkbenchMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);
        

        }

        
       
    }
}
