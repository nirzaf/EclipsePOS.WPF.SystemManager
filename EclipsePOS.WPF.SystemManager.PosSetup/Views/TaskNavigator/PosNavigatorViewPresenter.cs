using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;

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
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaskNavigator
{
    public class PosNavigatorViewPresenter
    {

        private IPosNavigatorView _view;

        public DelegateCommand<object> ShowOgranizationsCommand;
        public DelegateCommand<object> ShowPosConfigCommand;
        public DelegateCommand<object> ShowStationCommand;
        public DelegateCommand<object> ShowStoreCommand;
        public DelegateCommand<object> ShowUsersCommand;
        public DelegateCommand<object> ShowPosParamCommand;
        public DelegateCommand<object> ShowEmployeeRolesCommand;
        public DelegateCommand<object> ShowEmployeeCommand;
        public DelegateCommand<object> ShowPromotionCommand;
        public DelegateCommand<object> ShowMenuRootCommand;
       // public DelegateCommand<object> ShowPosWorkbenchCommand;
        public DelegateCommand<object> ShowMenuPanelsCommand;
        public DelegateCommand<object> ShowPosKeyCommand;
        public DelegateCommand<object> ShowTaxGroupCommand;
        public DelegateCommand<object> ShowTaxCommand;
        public DelegateCommand<object> ShowCurrencyCodeCommand;
        public DelegateCommand<object> ShowCurrencyRateCommand;
        public DelegateCommand<object> ShowDataSourceCommand;
        public DelegateCommand<object> ShowStartupSettingsCommand;
        public DelegateCommand<object> ShowTableGroupCommand;
        public DelegateCommand<object> ShowTableCommand;
        public DelegateCommand<object> ShowCustomerCommand;


        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public PosNavigatorViewPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
          
            ShowOgranizationsCommand = new DelegateCommand<object>(OnShowOrganizationsCommandExecute, OnShowOrganizationsCommandCanExecute);
            ShowPosConfigCommand = new DelegateCommand<object>(OnShowPosConfigCommandExecute, OnShowPosConfigCommandCanExecute);
            ShowUsersCommand = new DelegateCommand<object>(OnShowUsersCommandExecute, OnShowUsersCommandCanExecute);
            ShowStoreCommand = new DelegateCommand<object>(OnShowStoreCommandExecute, OnShowStoreCommandCanExecute);
            ShowStationCommand = new DelegateCommand<object>(OnShowStationCommandExecute, OnShowStationCommandCanExecute);
            ShowPosParamCommand = new DelegateCommand<object>(OnShowPosParamCommandExecute, OnShowPosParamCommandCanExecute);
            ShowEmployeeRolesCommand = new DelegateCommand<object>(OnShowEmployeeRolesCommandExecute, OnShowEmployeeRolesCommandCanExecute);
            ShowEmployeeCommand = new DelegateCommand<object>(OnShowEmployeeCommandExecute, OnShowEmployeeCommandCanExecute);
            ShowPromotionCommand = new DelegateCommand<object>(OnShowPromotionCommandExecute, OnShowPromotionCommandCanExecute);
            ShowMenuRootCommand = new DelegateCommand<object>(OnShowMenuRootCommandExecute, OnShowMenuRootCommandCanExecute);
            //ShowPosWorkbenchCommand = new DelegateCommand<object>(OnShowPosWorkbenchCommandExecute, OnShowPosWorkbenchCommandCanExecute);
            ShowStartupSettingsCommand = new DelegateCommand<object>(OnShowStartupSettingsCommandExecute, OnShowStartupSettingsCommandCanExecute);
            ShowTaxGroupCommand = new DelegateCommand<object>(OnShowTaxGroupCommandExecute, OnShowTaxGroupCommandCanExecute);
            ShowTaxCommand = new DelegateCommand<object>(OnShowTaxCommandExecute, OnShowTaxCommandCanExecute);
            ShowCurrencyCodeCommand = new DelegateCommand<object>(OnShowCurrencyCodeCommandExecute, OnShowCurrencyCodeCommandCanExecute);
            ShowCurrencyRateCommand = new DelegateCommand<object>(OnShowCurrencyRateCommandExecute, OnShowCurrencyRateCommandCanExecute);
            ShowDataSourceCommand = new DelegateCommand<object>(OnShowDataSourceCommandExecute, OnShowDataSourceCommandCanExecute);
            ShowTableGroupCommand = new DelegateCommand<object>(OnShowTableGroupCommandExecute, OnShowTableGroupCommandCanExecute);
            ShowTableCommand = new DelegateCommand<object>(OnShowTableCommandExecute, OnShowTableCommandCanExecute);
            ShowCustomerCommand = new DelegateCommand<object>(OnShowCustomerCommandExecute, OnShowCustomerCommandCanExecute);
            
        }



        public IPosNavigatorView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                View.SetOrganizationContext(ShowOgranizationsCommand);
                View.SetPosConfigContext(ShowPosConfigCommand);
                View.SetUsersContext(ShowUsersCommand);
                View.SetStoreContext(ShowStoreCommand);
                View.SetStationContext(ShowStationCommand);
                View.SetPosParamContext(ShowPosParamCommand);
                View.SetEmployeeRolesContext(ShowEmployeeRolesCommand);
                View.SetEmployeeContext(ShowEmployeeCommand);
                View.SetPromotionContext(ShowPromotionCommand);

                View.SetMenuRootContext(ShowMenuRootCommand);
               // View.SetPosWorkbenchContext(ShowPosWorkbenchCommand);
                View.SetStartupSettingsContext(ShowStartupSettingsCommand);
                View.SetTaxGroupContext(ShowTaxGroupCommand);
                View.SetTaxContext(ShowTaxCommand);
                View.SetCurrencyCodeContext(ShowCurrencyCodeCommand);
                View.SetCurrencyRateContext(ShowCurrencyRateCommand);
                View.SetDataSourceContext(ShowDataSourceCommand);

                View.SetTableGroupContext(ShowTableGroupCommand);
                View.SetTableContext(ShowTableCommand);
                View.SetCustomerContext(ShowCustomerCommand);

            }
        }

        public void ShowView()
        {

        }


      

        #region Show organization command

        public void OnShowOrganizationsCommandExecute(object obj)
       {
           IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
           if (authenticationService.Authenticate())
           {


               IRegion mainRegion = _regionManager.Regions[Regions.OrganizationMain];

               //Remove the view on main region 
               object mainView = mainRegion.GetView("MainView");
               if (mainView != null)
               {
                   mainRegion.Remove(mainView);
               }

               // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
               var view = _container.Resolve<OrganizationsView>();
               mainRegion.Add(view, "MainView");
               mainRegion.Activate(view);
           }


        }

        public  bool OnShowOrganizationsCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
           return true;
        }

        #endregion



        #region Show PosConfig command

        public void OnShowPosConfigCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                var view = _container.Resolve<PosConfigurationsView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            
            }


        }

        public bool OnShowPosConfigCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

       
        #region Show users command

        public void OnShowUsersCommandExecute(object obj)
        {
             IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
             if (authenticationService.Authenticate())
             {


                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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
       


        #region Show store command

        public void OnShowStoreCommandExecute(object obj)
        {
             IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
             if (authenticationService.Authenticate())
             {

                 IRegion mainRegion = _regionManager.Regions[Regions.OrganizationMain];

                 //Remove the view on main region 
                 object mainView = mainRegion.GetView("MainView");
                 if (mainView != null)
                 {
                     mainRegion.Remove(mainView);
                 }

                 // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                 var view = _container.Resolve<StoreView>();
                 mainRegion.Add(view, "MainView");
                 mainRegion.Activate(view);
             }


        }

        public bool OnShowStoreCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show station command

        public void OnShowStationCommandExecute(object obj)
        {
             IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
             if (authenticationService.Authenticate())
             {

                 IRegion mainRegion = _regionManager.Regions[Regions.OrganizationMain];

                 //Remove the view on main region 
                 object mainView = mainRegion.GetView("MainView");
                 if (mainView != null)
                 {
                     mainRegion.Remove(mainView);
                 }

                 // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                 var view = _container.Resolve<StationView>();
                 mainRegion.Add(view, "MainView");
                 mainRegion.Activate(view);
             }


        }

        public bool OnShowStationCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Show PosParam command

        public void OnShowPosParamCommandExecute(object obj)
        {
             IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
             if (authenticationService.Authenticate())
             {

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

                 //Remove the view on main region 
                 object mainView = mainRegion.GetView("MainView");
                 if (mainView != null)
                 {
                     mainRegion.Remove(mainView);
                 }

                 // IOrganizationViewPresenter presenter = _container.Resolve<IOrganizationViewPresenter>();
                 var view = _container.Resolve<PosParamView>();
                 mainRegion.Add(view, "MainView");
                 mainRegion.Activate(view);
             }


        }

        public bool OnShowPosParamCommandCanExecute(object obj)
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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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


        #region Show Menu Root command

        public void OnShowMenuRootCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<MenuRootView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowMenuRootCommandCanExecute(object obj)
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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

                 IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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

        #region Show data source command

        public void OnShowDataSourceCommandExecute(object obj)
        {

            IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

            //Remove the view on main region 
            object mainView = mainRegion.GetView("MainView");
            if (mainView != null)
            {
                mainRegion.Remove(mainView);
            }

            var view = _container.Resolve<DataSourceView>();
            mainRegion.Add(view, "MainView");
            mainRegion.Activate(view);


        }

        public bool OnShowDataSourceCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Show startup settings command

        public void OnShowStartupSettingsCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

                //Remove the view on main region 
                object mainView = mainRegion.GetView("MainView");
                if (mainView != null)
                {
                    mainRegion.Remove(mainView);
                }

                var view = _container.Resolve<SettingsView>();
                mainRegion.Add(view, "MainView");
                mainRegion.Activate(view);
            }


        }

        public bool OnShowStartupSettingsCommandCanExecute(object obj)
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

                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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
                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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
                IRegion mainRegion = _regionManager.Regions[Regions.MainRegion];

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








    }
}
