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
using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Modularity
{
    [TestClass]
    public class ModuleManagerFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullLoaderThrows()
        {
            new ModuleManager(null, new MockModuleCatalog(), new MockLogger());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCatalogThrows()
        {
            new ModuleManager(new MockModuleInitializer(), null, new MockLogger());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullLoggerThrows()
        {
            new ModuleManager(new MockModuleInitializer(), new MockModuleCatalog(), null);
        }

        [TestMethod]
        public void ShouldNotInitializeModulesSynchronously()
        {
            var loader = new MockModuleInitializer();
            var catalog = new MockModuleCatalog { Modules = { CreateModuleInfo("ModuleThatNeedsRetrieval", InitializationMode.WhenAvailable) } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { new MockModuleTypeLoader() };
            manager.Run();

            Assert.IsFalse(loader.LoadCalled);
        }

        [TestMethod]
        public void ShouldInvokeRetrieverForModules()
        {
            var loader = new MockModuleInitializer();
            var moduleInfo = CreateModuleInfo("needsRetrieval", InitializationMode.WhenAvailable);
            var catalog = new MockModuleCatalog { Modules = { moduleInfo } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };

            manager.Run();

            Assert.IsTrue(moduleTypeLoader.beginLoadModuleTypeCalls.Contains(moduleInfo));
        }

        [TestMethod]
        public void ShouldInitializeModulesOnRetrievalCompleted()
        {
            var loader = new MockModuleInitializer();
            var backgroungModuleInfo = CreateModuleInfo("NeedsRetrieval", InitializationMode.WhenAvailable);
            var catalog = new MockModuleCatalog { Modules = { backgroungModuleInfo } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };
            manager.Run();
            Assert.IsFalse(loader.LoadCalled);

            moduleTypeLoader.RaiseCallbackForModule(backgroungModuleInfo);

            Assert.IsTrue(loader.LoadCalled);
            Assert.AreEqual(1, loader.LoadedModules.Count);
            Assert.AreEqual(backgroungModuleInfo, loader.LoadedModules[0]);
        }

        [TestMethod]
        public void ShouldInitializeModuleOnDemand()
        {
            var loader = new MockModuleInitializer();
            var onDemandModule = CreateModuleInfo("NeedsRetrieval", InitializationMode.OnDemand);
            var catalog = new MockModuleCatalog { Modules = { onDemandModule } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleRetriever = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleRetriever };
            manager.Run();

            Assert.IsFalse(loader.LoadCalled);
            Assert.AreEqual(0, moduleRetriever.beginLoadModuleTypeCalls.Count);

            manager.LoadModule("NeedsRetrieval");

            Assert.AreEqual(1, moduleRetriever.beginLoadModuleTypeCalls.Count);

            moduleRetriever.RaiseCallbackForModule(onDemandModule);

            Assert.IsTrue(loader.LoadCalled);
            Assert.AreEqual(1, loader.LoadedModules.Count);
            Assert.AreEqual(onDemandModule, loader.LoadedModules[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ModuleNotFoundException))]
        public void InvalidOnDemandModuleNameThrows()
        {
            var loader = new MockModuleInitializer();

            var catalog = new MockModuleCatalog { Modules = new List<ModuleInfo> { CreateModuleInfo("Missing", InitializationMode.OnDemand) } };

            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };
            manager.Run();

            manager.LoadModule("NonExistent");
        }

        [TestMethod]
        [ExpectedException(typeof(ModuleNotFoundException))]
        public void EmptyOnDemandModuleReturnedThrows()
        {
            var loader = new MockModuleInitializer();

            var catalog = new MockModuleCatalog { CompleteListWithDependencies = modules => new List<ModuleInfo>() };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleRetriever = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleRetriever };
            manager.Run();

            manager.LoadModule("NullModule");
        }

        [TestMethod]
        public void ShouldNotLoadTypeIfModuleInitialized()
        {
            var loader = new MockModuleInitializer();
            var alreadedPresentModule = CreateModuleInfo(typeof(MockModule), InitializationMode.WhenAvailable);
            alreadedPresentModule.State = ModuleState.ReadyForInitialization;
            var catalog = new MockModuleCatalog { Modules = { alreadedPresentModule } };
            var manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };

            manager.Run();

            Assert.IsFalse(moduleTypeLoader.beginLoadModuleTypeCalls.Contains(alreadedPresentModule));
            Assert.IsTrue(loader.LoadCalled);
            Assert.AreEqual(1, loader.LoadedModules.Count);
            Assert.AreEqual(alreadedPresentModule, loader.LoadedModules[0]);
        }

        [TestMethod]
        public void ShouldNotLoadSameModuleTwice()
        {
            var loader = new MockModuleInitializer();
            var onDemandModule = CreateModuleInfo(typeof(MockModule), InitializationMode.OnDemand);
            var catalog = new MockModuleCatalog { Modules = { onDemandModule } };
            var manager = new ModuleManager(loader, catalog, new MockLogger());
            manager.Run();
            manager.LoadModule("MockModule");
            loader.LoadCalled = false;
            manager.LoadModule("MockModule");

            Assert.IsFalse(loader.LoadCalled);
        }

        [TestMethod]
        public void ShouldNotLoadModuleThatNeedsRetrievalTwice()
        {
            var loader = new MockModuleInitializer();
            var onDemandModule = CreateModuleInfo("ModuleThatNeedsRetrieval", InitializationMode.OnDemand);
            var catalog = new MockModuleCatalog { Modules = { onDemandModule } };
            var manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };
            manager.Run();
            manager.LoadModule("ModuleThatNeedsRetrieval");
            moduleTypeLoader.RaiseCallbackForModule(onDemandModule);
            loader.LoadCalled = false;

            manager.LoadModule("ModuleThatNeedsRetrieval");

            Assert.IsFalse(loader.LoadCalled);
        }

        [TestMethod]
        public void ShouldCallValidateCatalogBeforeGettingGroupsFromCatalog()
        {
            var loader = new MockModuleInitializer();
            var catalog = new MockModuleCatalog();
            var manager = new ModuleManager(loader, catalog, new MockLogger());
            bool validateCatalogCalled = false;
            bool getModulesCalledBeforeValidate = false;

            catalog.ValidateCatalog = () => validateCatalogCalled = true;
            catalog.CompleteListWithDependencies = f =>
                                                     {
                                                         if (!validateCatalogCalled)
                                                         {
                                                             getModulesCalledBeforeValidate = true;
                                                         }

                                                         return null;
                                                     };
            manager.Run();

            Assert.IsTrue(validateCatalogCalled);
            Assert.IsFalse(getModulesCalledBeforeValidate);
        }

        [TestMethod]
        public void ShouldNotInitializeIfDependenciesAreNotMet()
        {
            var loader = new MockModuleInitializer();
            var requiredModule = CreateModuleInfo("ModuleThatNeedsRetrieval1", InitializationMode.WhenAvailable);
            requiredModule.ModuleName = "RequiredModule";
            var dependantModuleInfo = CreateModuleInfo("ModuleThatNeedsRetrieval2", InitializationMode.WhenAvailable, "RequiredModule");

            var catalog = new MockModuleCatalog { Modules = { requiredModule, dependantModuleInfo } };
            catalog.GetDependentModules = m => new[] { requiredModule };

            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };

            manager.Run();

            moduleTypeLoader.RaiseCallbackForModule(dependantModuleInfo);

            Assert.IsFalse(loader.LoadCalled);
            Assert.AreEqual(0, loader.LoadedModules.Count);
        }

        [TestMethod]
        public void ShouldInitializeIfDependenciesAreMet()
        {
            var loader = new MockModuleInitializer();
            var requiredModule = CreateModuleInfo("ModuleThatNeedsRetrieval1", InitializationMode.WhenAvailable);
            requiredModule.ModuleName = "RequiredModule";
            var dependantModuleInfo = CreateModuleInfo("ModuleThatNeedsRetrieval2", InitializationMode.WhenAvailable, "RequiredModule");

            var catalog = new MockModuleCatalog { Modules = { requiredModule, dependantModuleInfo } };
            catalog.GetDependentModules = delegate(ModuleInfo module)
                                              {
                                                  if (module == dependantModuleInfo)
                                                      return new[] { requiredModule };
                                                  else
                                                      return null;
                                              };

            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };

            manager.Run();

            moduleTypeLoader.RaiseCallbackForModule(dependantModuleInfo);
            moduleTypeLoader.RaiseCallbackForModule(requiredModule);

            Assert.IsTrue(loader.LoadCalled);
            Assert.AreEqual(2, loader.LoadedModules.Count);
        }

        [TestMethod]
        public void ShouldThrowOnRetrieverErrorAndWrapException()
        {
            var loader = new MockModuleInitializer();
            var moduleInfo = CreateModuleInfo("NeedsRetrieval", InitializationMode.WhenAvailable);
            var catalog = new MockModuleCatalog { Modules = { moduleInfo } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };
            manager.Run();
            Assert.IsFalse(loader.LoadCalled);

            Exception retrieverException = new Exception();

            try
            {
                moduleTypeLoader.RaiseCallbackForModule(moduleInfo, retrieverException);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ModuleTypeLoadingException));
                Assert.AreEqual(moduleInfo.ModuleName, ((ModularityException)ex).ModuleName);
                StringAssert.Contains(ex.Message, moduleInfo.ModuleName);
                Assert.AreSame(retrieverException, ex.InnerException);
                return;
            }

            Assert.Fail("Exception not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ModuleTypeLoaderNotFoundException))]
        public void ShouldThrowIfNoRetrieverCanRetrieveModule()
        {
            var loader = new MockModuleInitializer();
            var catalog = new MockModuleCatalog { Modules = { CreateModuleInfo("ModuleThatNeedsRetrieval", InitializationMode.WhenAvailable) } };
            ModuleManager manager = new ModuleManager(loader, catalog, new MockLogger());
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { new MockModuleTypeLoader() { canLoadModuleTypeReturnValue = false } };
            manager.Run();
        }

        [TestMethod]
        public void ShouldLogMessageOnModuleRetrievalError()
        {
            var loader = new MockModuleInitializer();
            var moduleInfo = CreateModuleInfo("ModuleThatNeedsRetrieval", InitializationMode.WhenAvailable);
            var catalog = new MockModuleCatalog { Modules = { moduleInfo } };
            var logger = new MockLogger();
            ModuleManager manager = new ModuleManager(loader, catalog, logger);
            var moduleTypeLoader = new MockModuleTypeLoader();
            manager.ModuleTypeLoaders = new List<IModuleTypeLoader> { moduleTypeLoader };
            manager.Run();

            try
            {
                moduleTypeLoader.RaiseCallbackForModule(moduleInfo, new Exception());
            }
            catch
            {
                // Ignore all errors to make sure logger is called even if errors thrown.
            }

            Assert.IsNotNull(logger.LastMessage);
            StringAssert.Contains(logger.LastMessage, "ModuleThatNeedsRetrieval");
            Assert.AreEqual<Category>(Category.Exception, logger.LastMessageCategory);
        }

        [TestMethod]
        public void ShouldWorkIfModuleLoadsAnotherOnDemandModuleWhenInitializing()
        {
            var initializer = new StubModuleInitializer();
            var onDemandModule = CreateModuleInfo(typeof(MockModule), InitializationMode.OnDemand);
            onDemandModule.ModuleName = "OnDemandModule";
            var moduleThatLoadsOtherModule = CreateModuleInfo(typeof(MockModule), InitializationMode.WhenAvailable);
            var catalog = new MockModuleCatalog { Modules = { moduleThatLoadsOtherModule, onDemandModule } };
            ModuleManager manager = new ModuleManager(initializer, catalog, new MockLogger());
            
            bool onDemandModuleWasInitialized = false;
            initializer.Initialize = m =>
                                     {
                                         if (m == moduleThatLoadsOtherModule)
                                         {
                                             manager.LoadModule("OnDemandModule");
                                         }
                                         else if (m == onDemandModule)
                                         {
                                             onDemandModuleWasInitialized = true;
                                         }
                                     };

            manager.Run();

            Assert.IsTrue(onDemandModuleWasInitialized);
        }


        private static ModuleInfo CreateModuleInfo(string name, InitializationMode initializationMode, params string[] dependsOn)
        {
            ModuleInfo moduleInfo = new ModuleInfo(name, name);
            moduleInfo.InitializationMode = initializationMode;
            moduleInfo.DependsOn.AddRange(dependsOn);
            return moduleInfo;
        }

        private static ModuleInfo CreateModuleInfo(Type type, InitializationMode initializationMode, params string[] dependsOn)
        {
            ModuleInfo moduleInfo = new ModuleInfo(type.Name, type.AssemblyQualifiedName);
            moduleInfo.InitializationMode = initializationMode;
            moduleInfo.DependsOn.AddRange(dependsOn);
            return moduleInfo;
        }
    }

    internal class MockModule : IModule
    {
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class MockModuleCatalog : IModuleCatalog
    {
        public List<ModuleInfo> Modules = new List<ModuleInfo>();
        public Func<ModuleInfo, IEnumerable<ModuleInfo>> GetDependentModules;

        public Func<IEnumerable<ModuleInfo>, IEnumerable<ModuleInfo>> CompleteListWithDependencies;
        public Action ValidateCatalog;

        public void Initialize()
        {
            if (this.ValidateCatalog != null)
            {
                this.ValidateCatalog();
            }
        }

        IEnumerable<ModuleInfo> IModuleCatalog.Modules
        {
            get { return this.Modules; }
        }

        IEnumerable<ModuleInfo> IModuleCatalog.GetDependentModules(ModuleInfo moduleInfo)
        {
            if (GetDependentModules == null)
                return new List<ModuleInfo>();

            return GetDependentModules(moduleInfo);
        }

        IEnumerable<ModuleInfo> IModuleCatalog.CompleteListWithDependencies(IEnumerable<ModuleInfo> modules)
        {
            if (CompleteListWithDependencies != null)
                return CompleteListWithDependencies(modules);
            return modules;
        }
    }

    internal class MockModuleInitializer : IModuleInitializer
    {
        public bool LoadCalled;
        public List<ModuleInfo> LoadedModules = new List<ModuleInfo>();

        public void Initialize(ModuleInfo moduleInfo)
        {
            LoadCalled = true;
            this.LoadedModules.Add(moduleInfo);
        }
    }

    internal class StubModuleInitializer : IModuleInitializer
    {
        public Action<ModuleInfo> Initialize;

        void IModuleInitializer.Initialize(ModuleInfo moduleInfo)
        {
            this.Initialize(moduleInfo);
        }
    }

    internal class MockDelegateModuleInitializer : IModuleInitializer
    {
        public Action<ModuleInfo> LoadBody;

        public void Initialize(ModuleInfo moduleInfo)
        {
            LoadBody(moduleInfo);
        }
    }
}
