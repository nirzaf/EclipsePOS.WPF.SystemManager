using System;
using Microsoft.Practices.Unity;
using System.Data.Linq;
using Prism.Modularity;
using Prism.Ioc;

namespace EclipsePOS.WPF.SystemManager.Data
{
    public class DataModule : IModule
    {
        private IUnityContainer _container;
        public DataModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            RegisterServices();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }

        private void RegisterServices()
        {
            _container.RegisterType<DataContext, DataClasses1DataContext>();

        }
    }
}
