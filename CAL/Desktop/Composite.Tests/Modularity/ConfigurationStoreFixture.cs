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
using Microsoft.Practices.Composite.Modularity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Modularity
{
    [TestClass]
    public class ConfigurationStoreFixture
    {
        [TestMethod]
        public void ShouldRetrieveModuleConfiguration()
        {
            ConfigurationStore store = new ConfigurationStore();
            var section = store.RetrieveModuleConfigurationSection();

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Modules);
            Assert.AreEqual(1, section.Modules.Count);
            Assert.IsNotNull(section.Modules[0].AssemblyFile);
            Assert.AreEqual("MockModuleA", section.Modules[0].ModuleName);
            Assert.IsNotNull(section.Modules[0].AssemblyFile);
            Assert.IsTrue(section.Modules[0].AssemblyFile.Contains(@"MocksModules\MockModuleA.dll"));
            Assert.IsNotNull(section.Modules[0].ModuleType);
            Assert.IsTrue(section.Modules[0].StartupLoaded);
            Assert.AreEqual("Microsoft.Practices.Composite.Tests.Mocks.Modules.MockModuleA", section.Modules[0].ModuleType);
        }
    }
}