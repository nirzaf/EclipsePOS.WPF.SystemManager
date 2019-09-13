//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.UnityExtensions.Tests.Mocks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.UnityExtensions.Tests
{
    [TestClass]
    public class UnityBootstrapperFixture
    {
        [TestMethod]
        public void CanCreateConcreteBootstrapper()
        {
            new DefaultBootstrapper();
        }

        [TestMethod]
        public void CanRunBootstrapper()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.Run();
        }

        [TestMethod]
        public void ShouldInitializeContainer()
        {
            var bootstrapper = new DefaultBootstrapper();
            var container = bootstrapper.GetBaseContainer();

            Assert.IsNull(container);

            bootstrapper.Run();

            container = bootstrapper.GetBaseContainer();

            Assert.IsNotNull(container);
            Assert.IsInstanceOfType(container, typeof(UnityContainer));
        }

        [TestMethod]
        public void ShouldCallInitializeModules()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.InitializeModulesCalled);
        }

        [TestMethod]
        public void ShouldRegisterDefaultMappings()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.Run();

            Assert.IsNotNull(bootstrapper.DefaultRegionAdapterMappings);
            Assert.IsNotNull(bootstrapper.DefaultRegionAdapterMappings.GetMapping(typeof(ItemsControl)));
            Assert.IsNotNull(bootstrapper.DefaultRegionAdapterMappings.GetMapping(typeof(ContentControl)));
            Assert.IsNotNull(bootstrapper.DefaultRegionAdapterMappings.GetMapping(typeof(Selector)));
#if SILVERLIGHT
            Assert.IsNotNull(bootstrapper.DefaultRegionAdapterMappings.GetMapping(typeof(TabControl)));
#endif
        }

        [TestMethod]
        public void ShouldRegisterDefaultRegionBehaviorTypes()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.DefaultRegionBehaviorTypes.ContainsKey(AutoPopulateRegionBehavior.BehaviorKey));

            Assert.IsTrue(bootstrapper.DefaultRegionBehaviorTypes.ContainsKey(BindRegionContextToDependencyObjectBehavior.BehaviorKey));

            Assert.IsTrue(bootstrapper.DefaultRegionBehaviorTypes.ContainsKey(RegionActiveAwareBehavior.BehaviorKey));

            Assert.IsTrue(bootstrapper.DefaultRegionBehaviorTypes.ContainsKey(SyncRegionContextWithHostBehavior.BehaviorKey));

            Assert.IsTrue(bootstrapper.DefaultRegionBehaviorTypes.ContainsKey(RegionManagerRegistrationBehavior.BehaviorKey));

            Assert.AreEqual(5, bootstrapper.DefaultRegionBehaviorTypes.Count());
        }

        [TestMethod]
        public void ShouldCallConfigureRegionAdapterMappings()
        {
            var bootstrapper = new DefaultBootstrapper();

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.ConfigureRegionAdapterMappingsCalled);
        }

        [TestMethod]
        public void ShouldAssignRegionManagerToReturnedShell()
        {
            var bootstrapper = new DefaultBootstrapper();
            var shell = new UserControl();
            bootstrapper.CreateShellReturnValue = shell;

            Assert.IsNull(RegionManager.GetRegionManager(shell));

            bootstrapper.Run();

            Assert.IsNotNull(RegionManager.GetRegionManager(shell));
        }

        [TestMethod]
        public void ShouldCallGetLogger()
        {
            var bootstrapper = new DefaultBootstrapper();

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.GetLoggerCalled);
        }

        [TestMethod]
        public void ShouldCallGetCatalog()
        {
            var bootstrapper = new DefaultBootstrapper();

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.GetModuleCatalogCalled);
        }

        [TestMethod]
        public void ShouldCallCreateSell()
        {
            var bootstrapper = new DefaultBootstrapper();

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.CreateShellCalled);
        }

        [TestMethod]
        public void ShouldCallConfigureTypeMappings()
        {
            var bootstrapper = new DefaultBootstrapper();

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.ConfigureContainerCalled);
        }

        [TestMethod]
        public void NullLoggerThrows()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.ReturnNullDefaultLogger = true;

            AssertExceptionThrownOnRun(bootstrapper, typeof(InvalidOperationException), "ILoggerFacade");
        }

        [TestMethod]
        public void NullModuleCatalogThrowsOnDefaultModuleInitialization()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.ModuleCatalog = null;

            AssertExceptionThrownOnRun(bootstrapper, typeof(InvalidOperationException), "IModuleCatalog");
        }

        [TestMethod]
        public void NotOvewrittenGetModuleCatalogThrowsOnDefaultModuleInitialization()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.OverrideGetModuleCatalog = false;

            AssertExceptionThrownOnRun(bootstrapper, typeof(InvalidOperationException), "IModuleCatalog");
        }

        [TestMethod]
        public void GetLoggerShouldHaveDefault()
        {
            var bootstrapper = new DefaultBootstrapper();
            Assert.IsNull(bootstrapper.DefaultLogger);
            bootstrapper.Run();

            Assert.IsNotNull(bootstrapper.DefaultLogger);
            Assert.IsInstanceOfType(bootstrapper.DefaultLogger, typeof(TextLogger));
        }

        [TestMethod]
        public void ShouldNotFailIfReturnedNullShell()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.CreateShellReturnValue = null;
            bootstrapper.Run();
        }

        [TestMethod]
        public void ShouldRegisterDefaultTypeMappings()
        {
            var bootstrapper = new MockedBootstrapper();

            bootstrapper.MockUnityContainer.ResolveBag.Add(typeof(IModuleCatalog), bootstrapper.ModuleCatalog);
            bootstrapper.MockUnityContainer.ResolveBag.Add(typeof(IModuleInitializer), new MockModuleInitializer());
            bootstrapper.MockUnityContainer.ResolveBag.Add(typeof(IModuleManager), new MockModuleManager());

            bootstrapper.Run();

            Assert.IsTrue(bootstrapper.MockUnityContainer.Instances.ContainsKey(typeof(ILoggerFacade)));
            Assert.AreSame(bootstrapper.Logger, bootstrapper.MockUnityContainer.Instances[typeof(ILoggerFacade)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IServiceLocator)));
            Assert.AreEqual(typeof(UnityServiceLocatorAdapter), bootstrapper.MockUnityContainer.Types[typeof(IServiceLocator)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IModuleInitializer)));
            Assert.AreEqual(typeof(ModuleInitializer), bootstrapper.MockUnityContainer.Types[typeof(IModuleInitializer)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Instances.ContainsKey(typeof(IModuleCatalog)));
            Assert.AreSame(bootstrapper.ModuleCatalog, bootstrapper.MockUnityContainer.Instances[typeof(IModuleCatalog)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IRegionManager)));
            Assert.AreEqual(typeof(RegionManager), bootstrapper.MockUnityContainer.Types[typeof(IRegionManager)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(RegionAdapterMappings)));
            Assert.AreEqual(typeof(RegionAdapterMappings), bootstrapper.MockUnityContainer.Types[typeof(RegionAdapterMappings)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IRegionViewRegistry)));
            Assert.AreEqual(typeof(RegionViewRegistry), bootstrapper.MockUnityContainer.Types[typeof(IRegionViewRegistry)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IRegionBehaviorFactory)));
            Assert.AreEqual(typeof(RegionBehaviorFactory), bootstrapper.MockUnityContainer.Types[typeof(IRegionBehaviorFactory)]);

            Assert.IsTrue(bootstrapper.MockUnityContainer.Types.ContainsKey(typeof(IEventAggregator)));
            Assert.AreEqual(typeof(EventAggregator), bootstrapper.MockUnityContainer.Types[typeof(IEventAggregator)]);

            Assert.AreEqual(8, bootstrapper.MockUnityContainer.Types.Count);

        }

        [TestMethod]
        public void ShouldCallRunOnModuleManager()
        {
            var bootstrapper = new MockedBootstrapper();

            var moduleManager = new MockModuleManager();
            bootstrapper.MockUnityContainer.ResolveBag.Add(typeof(IModuleManager), moduleManager);

            bootstrapper.Run();

            Assert.IsTrue(moduleManager.RunCalled);
        }

        [TestMethod]
        public void ReturningNullContainerThrows()
        {
            var bootstrapper = new MockedBootstrapper();
            bootstrapper.MockUnityContainer = null;

            AssertExceptionThrownOnRun(bootstrapper, typeof(InvalidOperationException), "IUnityContainer");
        }

        [TestMethod]
        public void ShouldCallTheMethodsInOrder()
        {
            var bootstrapper = new TestableOrderedBootstrapper();
            bootstrapper.Run();

            Assert.IsTrue(CompareOrder("LoggerFacade", "CreateContainer", bootstrapper.OrderedMethodCallList) < 0);
            Assert.IsTrue(CompareOrder("CreateContainer", "ConfigureContainer", bootstrapper.OrderedMethodCallList) < 0);
            Assert.IsTrue(CompareOrder("ConfigureContainer", "GetModuleCatalog", bootstrapper.OrderedMethodCallList) < 0);
            Assert.IsTrue(CompareOrder("GetModuleCatalog", "ConfigureRegionAdapterMappings", bootstrapper.OrderedMethodCallList) < 0);
            Assert.IsTrue(CompareOrder("ConfigureRegionAdapterMappings", "CreateShell", bootstrapper.OrderedMethodCallList) < 0);
            Assert.IsTrue(CompareOrder("CreateShell", "InitializeModules", bootstrapper.OrderedMethodCallList) < 0);
        }

        [TestMethod]
        public void ShouldLogBootstrapperSteps()
        {
            var bootstrapper = new TestableOrderedBootstrapper();
            bootstrapper.Run();
            var messages = bootstrapper.Logger.Messages;

            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Creating Unity container")));
            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Configuring container")));
            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Configuring region adapters")));
            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Creating shell")));
            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Initializing modules")));
            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Bootstrapper sequence completed")));
        }

        [TestMethod]
        public void ShouldNotRegisterDefaultServicesAndTypes()
        {
            var bootstrapper = new NonconfiguredBootstrapper();
            bootstrapper.Run(false);
#if !SILVERLIGHT
            Assert.IsFalse(bootstrapper.HasRegisteredType(typeof(IEventAggregator)));
#endif
            Assert.IsFalse(bootstrapper.HasRegisteredType(typeof(IRegionManager)));
            Assert.IsFalse(bootstrapper.HasRegisteredType(typeof(RegionAdapterMappings)));
            Assert.IsFalse(bootstrapper.HasRegisteredType(typeof(IServiceLocator)));
            Assert.IsFalse(bootstrapper.HasRegisteredType(typeof(IModuleInitializer)));
        }

        [TestMethod]
        public void ShoudLogRegisterTypeIfMissingMessage()
        {
            var bootstrapper = new TestableOrderedBootstrapper();
            bootstrapper.AddCustomTypeMappings = true;
            bootstrapper.Run();
            var messages = bootstrapper.Logger.Messages;

            Assert.IsNotNull(messages.FirstOrDefault(msg => msg.Contains("Type 'IRegionManager' was already registered by the application")));
        }

        [TestMethod]
        public void ShouldRegisterFrameworkExceptionTypes()
        {
            var bootstrapper = new DefaultBootstrapper();
            bootstrapper.Run();

            Assert.IsTrue(ExceptionExtensions.IsFrameworkExceptionRegistered(
                typeof (Microsoft.Practices.ServiceLocation.ActivationException)));

            Assert.IsTrue(ExceptionExtensions.IsFrameworkExceptionRegistered(
                typeof(Microsoft.Practices.Unity.ResolutionFailedException)));

            Assert.IsTrue(ExceptionExtensions.IsFrameworkExceptionRegistered(
                typeof(Microsoft.Practices.ObjectBuilder2.BuildFailedException)));
        }

        private static int CompareOrder(string firstString, string secondString, IList<string> list)
        {
            return list.IndexOf(firstString).CompareTo(list.IndexOf(secondString));
        }

        private static void AssertExceptionThrownOnRun(UnityBootstrapper bootstrapper, Type expectedExceptionType, string expectedExceptionMessageSubstring)
        {
            bool exceptionThrown = false;
            try
            {
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedExceptionType, ex.GetType());
                StringAssert.Contains(ex.Message, expectedExceptionMessageSubstring);
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                Assert.Fail("Exception not thrown.");
            }
        }
    }

    internal class MockModuleManager : IModuleManager
    {
        public bool RunCalled;

        public void Run()
        {
            RunCalled = true;
        }

        public void LoadModule(string moduleName)
        {
            throw new System.NotImplementedException();
        }
    }

    class NonconfiguredBootstrapper : UnityBootstrapper
    {
        private MockUnityContainer mockContainer;

        protected override void InitializeModules()
        {
        }

        protected override IUnityContainer CreateContainer()
        {
            mockContainer = new MockUnityContainer();
            return mockContainer;
        }

        protected override DependencyObject CreateShell()
        {
            return null;
        }

        public bool HasRegisteredType(Type t)
        {
            return mockContainer.Types.ContainsKey(t);
        }
    }

    internal class DefaultBootstrapper : UnityBootstrapper
    {
        public bool GetEnumeratorCalled;
        public bool GetLoggerCalled;
        public bool InitializeModulesCalled;
        public bool CreateShellCalled;
        public bool ReturnNullDefaultLogger;
        public bool OverrideGetModuleCatalog = true;
        public IModuleCatalog ModuleCatalog = new MockModuleCatalog();
        public ILoggerFacade DefaultLogger;
        public DependencyObject CreateShellReturnValue;
        public bool ConfigureContainerCalled;
        public bool GetModuleCatalogCalled;
        public bool ConfigureRegionAdapterMappingsCalled;
        public RegionAdapterMappings DefaultRegionAdapterMappings;
        public IRegionBehaviorFactory DefaultRegionBehaviorTypes;

        public bool ConfigureDefaultRegionBehaviorsCalled;

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            ConfigureRegionAdapterMappingsCalled = true;
            var regionAdapterMappings = base.ConfigureRegionAdapterMappings();

            DefaultRegionAdapterMappings = regionAdapterMappings;

            return regionAdapterMappings;
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            ConfigureDefaultRegionBehaviorsCalled = true;
            this.DefaultRegionBehaviorTypes = base.ConfigureDefaultRegionBehaviors();
            return this.DefaultRegionBehaviorTypes;
        }

        public IUnityContainer GetBaseContainer()
        {
            return base.Container;
        }

        protected override void ConfigureContainer()
        {
            ConfigureContainerCalled = true;
            base.ConfigureContainer();
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            GetModuleCatalogCalled = true;
            if (OverrideGetModuleCatalog)
            {
                return ModuleCatalog;
            }
            else
            {
                return base.GetModuleCatalog();
            }
        }

        protected override ILoggerFacade LoggerFacade
        {
            get
            {
                GetLoggerCalled = true;
                if (ReturnNullDefaultLogger)
                {
                    return null;
                }
                else
                {
                    DefaultLogger = base.LoggerFacade;
                    return DefaultLogger;
                }
            }
        }

        protected override void InitializeModules()
        {
            InitializeModulesCalled = true;
            base.InitializeModules();
        }

        protected override DependencyObject CreateShell()
        {
            CreateShellCalled = true;

            return CreateShellReturnValue;
        }
    }

    internal class MockModuleCatalog : IModuleCatalog
    {
        public void Initialize()
        {
        }

        public IEnumerable<ModuleInfo> Modules
        {
            get { return new List<ModuleInfo>(); }
        }

        public IEnumerable<ModuleInfo> CompleteListWithDependencies(IEnumerable<ModuleInfo> modules)
        {
            return new List<ModuleInfo>();
        }

        public IEnumerable<ModuleInfo> GetDependentModules(ModuleInfo moduleInfo)
        {
            return new List<ModuleInfo>();
        }

        public IModuleCatalog AddModule(ModuleInfo moduleInfo)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ModuleInfo> GetModulesWithDependencies(Func<ModuleInfo, bool> filter)
        {
            return new List<ModuleInfo>();
        }
    }

    class MockedBootstrapper : UnityBootstrapper
    {
        public MockUnityContainer MockUnityContainer = new MockUnityContainer();
        public MockModuleCatalog ModuleCatalog = new MockModuleCatalog();
        public MockLoggerAdapter Logger = new MockLoggerAdapter();

        protected override IUnityContainer CreateContainer()
        {
            return this.MockUnityContainer;
        }

        protected override ILoggerFacade LoggerFacade
        {
            get { return Logger; }
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            return ModuleCatalog;
        }

        protected override DependencyObject CreateShell()
        {
            return null;
        }
    }

    class TestableOrderedBootstrapper : UnityBootstrapper
    {
        public IList<string> OrderedMethodCallList = new List<string>();
        public MockLoggerAdapter Logger = new MockLoggerAdapter();
        public bool AddCustomTypeMappings;

        protected override IUnityContainer CreateContainer()
        {
            OrderedMethodCallList.Add("CreateContainer");
            return base.CreateContainer();
        }

        protected override ILoggerFacade LoggerFacade
        {
            get
            {
                OrderedMethodCallList.Add("LoggerFacade");
                return Logger;
            }
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            OrderedMethodCallList.Add("GetModuleCatalog");
            return new MockModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            OrderedMethodCallList.Add("ConfigureContainer");
            if (AddCustomTypeMappings)
            {
                RegisterTypeIfMissing(typeof(IRegionManager), typeof(MockRegionManager), true);
            }
            base.ConfigureContainer();
        }

        protected override void InitializeModules()
        {
            OrderedMethodCallList.Add("InitializeModules");
            base.InitializeModules();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            OrderedMethodCallList.Add("ConfigureRegionAdapterMappings");
            return base.ConfigureRegionAdapterMappings();
        }

        protected override DependencyObject CreateShell()
        {
            OrderedMethodCallList.Add("CreateShell");
            return null;
        }
    }
}
