using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.ModuleNavigator;
using EclipsePOS.WPF.SystemManager.Infrastructure.Services;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.Login;
using EclipsePOS.WPF.SystemManager.Infrastructure.Views.Defaults;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.Infrastructure
{
    public class InfrastructureModule : IModule
    {

        private IUnityContainer _container;
        private IAuthenticationService authenticationService;
        private IRegionManager _regionManager;

       // public DelegateCommand<object> ShowPosSetupNavigatorTaskCommand { get; private set; }


        public InfrastructureModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

          
            RegisterBaseServices();

            RegisterOtherServicesAndView();

           // IRegion navRegion = _regionManager.Regions["ModuleNavigatorRegion"];
           // IModuleNavigatorView view = _container.Resolve<IModuleNavigatorView>();
           // navRegion.Add(view);
           // navRegion.Activate(view);
          
        }

        private void RegisterBaseServices()
        {
            _container.RegisterType<IAuthenticationService, AuthenticationService>();
            _container.RegisterType<ILoginView, LoginView>();
            _container.RegisterType<ILoginViewPresenter, LoginViewPresenter>();
        }

        private void RegisterOtherServicesAndView()
        {
            _container.RegisterType<IModuleNavigatorView, ModuleNavigatorView>();
          
        }

        public static string GetCurrentUser()
        {
            return Properties.Settings.Default.SecurityToken;
        }


        
        
       
    }
}
