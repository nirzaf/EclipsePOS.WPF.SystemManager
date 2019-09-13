using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Station;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Store;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Users;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.EmployeeRoles;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Employee;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Promotion;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.TableGroup;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Table;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.TaxGroup;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Tax;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.CurrencyCode;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.CurrencyRate;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.DataSource;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Customer;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Surcharge;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.CardMedia;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOperations
{
    public class OperationsNavPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DelegateCommand<object> ShowUsersCommand;
        public DelegateCommand<object> ShowEmployeeRolesCommand;
        public DelegateCommand<object> ShowEmployeeCommand;
        public DelegateCommand<object> ShowPromotionCommand;
        public DelegateCommand<object> ShowTaxGroupCommand;
        public DelegateCommand<object> ShowTaxCommand;
        public DelegateCommand<object> ShowCurrencyCodeCommand;
        public DelegateCommand<object> ShowCurrencyRateCommand;
        public DelegateCommand<object> ShowTableGroupCommand;
        public DelegateCommand<object> ShowTableCommand;
        public DelegateCommand<object> ShowCustomerCommand;
        public DelegateCommand<object> ShowSurchargesCommand;
        public DelegateCommand<object> ShowCardMediaCommand;

        public OperationsNavPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            ShowUsersCommand = new DelegateCommand<object>(OnShowUsersCommandExecute, OnShowUsersCommandCanExecute);
            ShowEmployeeRolesCommand = new DelegateCommand<object>(OnShowEmployeeRolesCommandExecute, OnShowEmployeeRolesCommandCanExecute);
            ShowEmployeeCommand = new DelegateCommand<object>(OnShowEmployeeCommandExecute, OnShowEmployeeCommandCanExecute);
            ShowPromotionCommand = new DelegateCommand<object>(OnShowPromotionCommandExecute, OnShowPromotionCommandCanExecute);
            ShowTaxGroupCommand = new DelegateCommand<object>(OnShowTaxGroupCommandExecute, OnShowTaxGroupCommandCanExecute);
            ShowTaxCommand = new DelegateCommand<object>(OnShowTaxCommandExecute, OnShowTaxCommandCanExecute);
            ShowCurrencyCodeCommand = new DelegateCommand<object>(OnShowCurrencyCodeCommandExecute, OnShowCurrencyCodeCommandCanExecute);
            ShowCurrencyRateCommand = new DelegateCommand<object>(OnShowCurrencyRateCommandExecute, OnShowCurrencyRateCommandCanExecute);
            ShowTableGroupCommand = new DelegateCommand<object>(OnShowTableGroupCommandExecute, OnShowTableGroupCommandCanExecute);
            ShowTableCommand = new DelegateCommand<object>(OnShowTableCommandExecute, OnShowTableCommandCanExecute);
            ShowCustomerCommand = new DelegateCommand<object>(OnShowCustomerCommandExecute, OnShowCustomerCommandCanExecute);
            ShowSurchargesCommand = new DelegateCommand<object>(OnShowSurchargesCommandExecute, OnShowSurchargesCommandCanExecute);
            ShowCardMediaCommand = new DelegateCommand<object>(OnShowCardMediaCommandExecute, OnShowCardMediaCommandCanExecute);
  

        }

        private IOperationsNavView _view;
        public IOperationsNavView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                View.SetEmployeeRolesContext(ShowEmployeeRolesCommand);
                View.SetEmployeeContext(ShowEmployeeCommand);
                View.SetPromotionContext(ShowPromotionCommand);

                View.SetTaxGroupContext(ShowTaxGroupCommand);
                View.SetTaxContext(ShowTaxCommand);
                View.SetCurrencyCodeContext(ShowCurrencyCodeCommand);
                View.SetCurrencyRateContext(ShowCurrencyRateCommand);
                
                View.SetTableGroupContext(ShowTableGroupCommand);
                View.SetTableContext(ShowTableCommand);
                View.SetCustomerContext(ShowCustomerCommand);
                View.SetSurchargesContext(ShowSurchargesCommand);
                View.SetCardMediaContext(ShowCardMediaCommand);

                View.SetUsersContext(ShowUsersCommand);
            }
        }

        #region Show users command

        public void OnShowUsersCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {


                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                var view = _container.Resolve<UsersView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowUsersCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion



        

        
        #region Show Employee Roles command

        public void OnShowEmployeeRolesCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                var view = _container.Resolve<EmployeeRolesView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowEmployeeRolesCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show Employee command

        public void OnShowEmployeeCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                var view = _container.Resolve<EmployeeView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowEmployeeCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        
        
        #region Show Promotion command

        public void OnShowPromotionCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                var view = _container.Resolve<PromotionView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowPromotionCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        



        #region Show tax group command

        public void OnShowTaxGroupCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<TaxGroupView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowTaxGroupCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Show tax command

        public void OnShowTaxCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<TaxView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowTaxCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show currency command

        public void OnShowCurrencyCodeCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<CurrencyCodeView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowCurrencyCodeCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show currency rate command

        public void OnShowCurrencyRateCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<CurrencyView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowCurrencyRateCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        
       

        #region Show Table Group command

        public void OnShowTableGroupCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<TableGroupView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowTableGroupCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show Table command

        public void OnShowTableCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<TableView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowTableCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Show Customer command

        public void OnShowCustomerCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<CustomerView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowCustomerCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Show Surcharges command

        public void OnShowSurchargesCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<SerchargeView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowSurchargesCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Show Card Media command

        public void OnShowCardMediaCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {
                IRegion mainRegion = _regionManager.Regions[Regions.OperationMain];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<CardMediaView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }

        }

        public bool OnShowCardMediaCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion






    }
}
