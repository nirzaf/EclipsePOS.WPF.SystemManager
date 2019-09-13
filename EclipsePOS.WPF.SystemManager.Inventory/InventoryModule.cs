using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.Inventory.Views.TaskNavigator;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.Defaults;

using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows;
using System.Windows.Controls;



namespace EclipsePOS.WPF.SystemManager.Inventory
{
    public class InventoryModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
       // public DelegateCommand<object> ShowInventoryNavigatorTaskCommand { get; private set; }
        private IRegion taskRegion;
        private IRegion mainRegion;

        public InventoryModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

           // taskRegion = _regionManager.Regions[Regions.TaskNavigatorRegion];
           // mainRegion = _regionManager.Regions[Regions.MainRegion];

           // ShowInventoryNavigatorTaskCommand = new DelegateCommand<object>(ShowInventoryTask, CanShowInventoryTask);
           // Commands.ShowInventoryTaskView.RegisterCommand(ShowInventoryNavigatorTaskCommand);
        }

        public void Initialize()
        {
            //RegisterServices();
            this.AddInventoryTab();
            
        }

        /*
        private void RegisterServices()
        {
            //_container.RegisterType<IInventoryNavigatorView, InventoryNavigatorView>();
            //_container.RegisterType<IInventoryNavigatorViewPresenter, InventoryNavigatorViewPresenter>();
        }



        public bool CanShowInventoryTask(Object obj)
        {
            return true;
        }



        public void ShowInventoryTask(object obj)
        {
            
            object view1 = taskRegion.GetView("ActiveView");
            try
            {
                taskRegion.Remove(view1);
            }
            catch
            {
            }

            object view2 = mainRegion.GetView("MainView");
            try
            {
                mainRegion.Remove(view2);
            }
            catch
            {
            }
            
            
             var view = _container.Resolve<InventoryNavigatorView>();
            taskRegion.Add(view, "ActiveView");
            taskRegion.Activate(view);

           // var view0 = _container.Resolve<HelpView>();
           // mainRegion.Add(view0, "MainView");
           // mainRegion.Activate(view0);
        }
         */

        private void AddInventoryTab()
        {
            //Remove the view on data source task  region 
            IRegion inventoryTab = _regionManager.Regions[Regions.InventoryTasks];

            var view = _container.Resolve<InventoryNavigatorView>();
            inventoryTab.Add(view);
            inventoryTab.Activate(view);

            IRegion mainRegion = _regionManager.Regions[Regions.InventoryMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);

        }


    }
}
