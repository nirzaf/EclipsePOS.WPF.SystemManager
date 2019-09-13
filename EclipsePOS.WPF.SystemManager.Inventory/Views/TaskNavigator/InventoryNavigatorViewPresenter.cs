using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;
using EclipsePOS.WPF.SystemManager.Inventory.Views.ItemList;
using EclipsePOS.WPF.SystemManager.Inventory.Views.Department;
using EclipsePOS.WPF.SystemManager.Inventory.Views.Stock;
using EclipsePOS.WPF.SystemManager.Inventory.Views.ItemGroup;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.TaskNavigator
{
    public class InventoryNavigatorViewPresenter
    {
        public DelegateCommand<object> ShowDepartmentCommand;
        public DelegateCommand<object> ShowItemGroupCommand;
        public DelegateCommand<object> ShowItemListCommand;
       // public DelegateCommand<object> ShowDefaultStoreGroupCommand;
        public DelegateCommand<object> ShowStockDiaryCommand;


        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IInventoryNavigatorView _view;
              

        public InventoryNavigatorViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {

            _container = container;
            _regionManager = regionManager;

            ShowDepartmentCommand = new DelegateCommand<object>(OnShowDepartmentCommandExecute, OnShowDepartmentCommandCanExecute);
            ShowItemGroupCommand = new DelegateCommand<object>(OnShowItemGroupCommandExecute, OnShowItemGroupCommandCanExecute);
            ShowItemListCommand = new DelegateCommand<object>(OnShowItemListCommandExecute, OnShowItemListCommandCanExecute);
            //ShowDefaultStoreGroupCommand = new DelegateCommand<object>(OnShowStoreGroupCommandExecute, OnShowStoreGroupCommandCanExecute);    
            ShowStockDiaryCommand = new DelegateCommand<object>(OnShowStockDiaryCommandExecute, OnShowStockDiaryCommandCanExecute);    
           
        }

        public IInventoryNavigatorView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                View.SetDataContextDeptView(ShowDepartmentCommand);
                View.SetDataContextItemListView(ShowItemListCommand);
                View.SetDataContextStockDiaryView(ShowStockDiaryCommand);
                View.SetDataContextItemGroupView(ShowItemGroupCommand);
            }
        }

        

        #region Show Department Command

        public void OnShowDepartmentCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.InventoryMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<DepartmentView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowDepartmentCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 


        #region Show Item Group Command

        public void OnShowItemGroupCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.InventoryMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<ItemGroupView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }
        }

        public bool OnShowItemGroupCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region Show Item List Command

        public void OnShowItemListCommandExecute(object obj)
        {
           IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
           if (authenticationService.Authenticate())
           {
               // Implement business logic for myCommand.
               IRegion mainRegion = _regionManager.Regions[Regions.InventoryMain];

               //Remove the view on main region 
               object mainView = mainRegion.GetView("MainView");
               if (mainView != null)
               {
                   mainRegion.Remove(mainView);
               }

               var view = _container.Resolve<ItemListView>();
               mainRegion.Add(view, "MainView");
               mainRegion.Activate(view);
           }

        }

        public bool OnShowItemListCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 

        #region Show Stock Diary Command

        public void OnShowStockDiaryCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                // Implement business logic for myCommand.
                IRegion mainRegion = _regionManager.Regions[Regions.InventoryMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<StockDiaryView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowStockDiaryCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 



    }
}
