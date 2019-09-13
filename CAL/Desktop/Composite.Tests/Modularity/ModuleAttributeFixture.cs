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
    public class ModuleAttributeFixture
    {
        [TestMethod]
        public void StartupLoadedDefaultsToTrue()
        {
            var moduleAttribute = new ModuleAttribute();

            Assert.AreEqual(false, moduleAttribute.OnDemand);
        }

        [TestMethod]
        public void CanGetAndSetProperties()
        {
            var moduleAttribute = new ModuleAttribute();
            moduleAttribute.ModuleName = "Test";
            moduleAttribute.OnDemand = true;

            Assert.AreEqual("Test", moduleAttribute.ModuleName);
            Assert.AreEqual(true, moduleAttribute.OnDemand);
        }

        [TestMethod]
        public void ModuleDependencyAttributeStoresModuleName()
        {
            var moduleDependencyAttribute = new ModuleDependencyAttribute("Test");

            Assert.AreEqual("Test", moduleDependencyAttribute.ModuleName);
        }
    }
}