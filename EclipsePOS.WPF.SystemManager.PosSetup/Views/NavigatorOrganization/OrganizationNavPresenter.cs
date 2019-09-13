using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Presentation.Commands;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Station;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.Store;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOrganization
{
    public class OrganizationNavPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DelegateCommand<object> ShowOgranizationsCommand;
        public DelegateCommand<object> ShowStationCommand;
        public DelegateCommand<object> ShowStoreCommand;
        public DelegateCommand<object> ShowStartupSettingsCommand;
        

        public OrganizationNavPresenter(IUnityContainer container, IRegionManager regionManager)
        {

            _container = container;
            _regionManager = regionManager;

            ShowOgranizationsCommand = new DelegateCommand<object>(OnShowOrganizationsCommandExecute, OnShowOrganizationsCommandCanExecute);
            ShowStoreCommand = new DelegateCommand<object>(OnShowStoreCommandExecute, OnShowStoreCommandCanExecute);
            ShowStationCommand = new DelegateCommand<object>(OnShowStationCommandExecute, OnShowStationCommandCanExecute);
            ShowStartupSettingsCommand = new DelegateCommand<object>(OnShowStartupSettingsCommandExecute, OnShowStartupSettingsCommandCanExecute);
           
        }


        private IOrganizationNavView _view;
        public IOrganizationNavView View
        {
            set
            {
                _view = value;
                View.SetOrganizationContext(ShowOgranizationsCommand);
                View.SetStoreContext(ShowStoreCommand);
                View.SetStationContext(ShowStationCommand);
                View.SetStartupSettingsContext(ShowStartupSettingsCommand);
            }
            get
            {
                return _view;


            }
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

        public bool OnShowOrganizationsCommandCanExecute(object obj)
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


        #region Show startup settings command

        public void OnShowStartupSettingsCommandExecute(object obj)
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




    }
}
