using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaskNavigator;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.Defaults;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows;
using System.Windows.Controls;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries
{
    public class ReportsModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        public DelegateCommand<object> ShowReportsTaskCommand { get; private set; }
        private IRegion taskRegion;
        private IRegion mainRegion;

        public ReportsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            //taskRegion = _regionManager.Regions[Regions.TaskNavigatorRegion];
            //mainRegion = _regionManager.Regions[Regions.MainRegion];

            //ShowReportsTaskCommand = new DelegateCommand<object>(ShowReportsTask, CanShowReportsTask);
            //Commands.ShowEnquiryAndReportsTaskView.RegisterCommand(ShowReportsTaskCommand);
        }

        public void Initialize()
        {
           // RegisterServices();
            this.AddReportsTab();
          
            
        }
        /*
        private void RegisterServices()
        {
            //_container.RegisterType<IInventoryNavigatorView, InventoryNavigatorView>();
            //_container.RegisterType<IInventoryNavigatorViewPresenter, InventoryNavigatorViewPresenter>();
        }



        public bool CanShowReportsTask(Object obj)
        {
            return true;
        }



        public void ShowReportsTask(object obj)
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
            
            
            var view = _container.Resolve<ReportsNavigatorView>();
            taskRegion.Add(view, "ActiveView");
            taskRegion.Activate(view);

          
        }
         * */

        private void AddReportsTab()
        {
            //Remove the view on data source task  region 
            IRegion reportsTab = _regionManager.Regions[Regions.ReportsTasks];

            var view = _container.Resolve<ReportsNavigatorView>();
            reportsTab.Add(view);
            reportsTab.Activate(view);

            IRegion mainRegion = _regionManager.Regions[Regions.ReportsMain];
            var defaultView = _container.Resolve<MainRegionView>();
            mainRegion.Add(defaultView, "MainView");
            mainRegion.Activate(defaultView);

        }

    }
}
