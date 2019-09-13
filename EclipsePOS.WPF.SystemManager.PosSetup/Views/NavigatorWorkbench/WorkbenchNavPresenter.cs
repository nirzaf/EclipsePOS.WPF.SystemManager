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
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot;
using EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorWorkbench
{
    public class WorkbenchNavPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DelegateCommand<object> ShowPosConfigCommand;
        public DelegateCommand<object> ShowPosParamCommand;
        public DelegateCommand<object> ShowMenuRootCommand;
        public DelegateCommand<object> ShowMenuPanelsCommand;
        public DelegateCommand<object> ShowPosKeyCommand;
        public DelegateCommand<object> ShowStartPosCommand;
        

        public WorkbenchNavPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            ShowPosConfigCommand = new DelegateCommand<object>(OnShowPosConfigCommandExecute, OnShowPosConfigCommandCanExecute);
            ShowPosParamCommand = new DelegateCommand<object>(OnShowPosParamCommandExecute, OnShowPosParamCommandCanExecute);
            ShowMenuRootCommand = new DelegateCommand<object>(OnShowMenuRootCommandExecute, OnShowMenuRootCommandCanExecute);
            ShowStartPosCommand = new DelegateCommand<object>(OnShowStartPosCommandExecute, OnShowStartPosCommandCanExecute);
            

            
        }

        private IWorkbenchNavView _view;
        public IWorkbenchNavView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                View.SetPosConfigContext(ShowPosConfigCommand);
                View.SetPosParamContext(ShowPosParamCommand);
                
                View.SetMenuRootContext(ShowMenuRootCommand);
               // View.SetPosWorkbenchContext(ShowPosWorkbenchCommand);
                View.SetStartPosContext(ShowStartPosCommand);
            }
        }


        #region Show PosConfig command

        public void OnShowPosConfigCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.WorkbenchMain];

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

        #region Show PosParam command

        public void OnShowPosParamCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.WorkbenchMain];

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

        #region Show Menu Root command

        public void OnShowMenuRootCommandExecute(object obj)
        {
            IAuthenticationService authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.Authenticate())
            {

                IRegion mainRegion = _regionManager.Regions[Regions.WorkbenchMain];

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

       
        #region Show startup settings command

        public void OnShowStartPosCommandExecute(object obj)
        {
            try
            {
                Process.Start(@"..\EclipsePosWorkbench\EclipsePOS.WPF.PosWorkBench.exe");
                Application.Current.Shutdown();
            }
            catch (Exception e)
            {
                Microsoft.Windows.Controls.MessageBox.Show(e.ToString(), "Start POS command", MessageBoxButton.OK, MessageBoxImage.Error);
   
            }


        }

        public bool OnShowStartPosCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion
        
    }
}
