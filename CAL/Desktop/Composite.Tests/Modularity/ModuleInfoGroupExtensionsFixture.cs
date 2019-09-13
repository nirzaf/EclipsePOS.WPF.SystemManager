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
using System.Linq;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Modularity
{
    /// <summary>
    /// Summary description for ModuleInfoGroupExtensionsFixture
    /// </summary>
    [TestClass]
    public class ModuleInfoGroupExtensionsFixture
    {
        [TestMethod]
        public void ShouldAddModuleToModuleInfoGroup()
        {
            string moduleName = "MockModule";
            ModuleInfoGroup groupInfo = new ModuleInfoGroup();
            groupInfo.AddModule(moduleName, typeof(MockModule));

            Assert.AreEqual<int>(1, groupInfo.Count);
            Assert.AreEqual<string>(moduleName, groupInfo.ElementAt(0).ModuleName);
        }

        [TestMethod]
        public void ShouldSetModuleTypeCorrectly()
        {
            ModuleInfoGroup groupInfo = new ModuleInfoGroup();
            groupInfo.AddModule("MockModule", typeof(MockModule));

            Assert.AreEqual<int>(1, groupInfo.Count);
            Assert.AreEqual<string>(typeof(MockModule).AssemblyQualifiedName, groupInfo.ElementAt(0).ModuleType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTypeThrows()
        {
            ModuleInfoGroup groupInfo = new ModuleInfoGroup();
            groupInfo.AddModule("NullModule", null);
        }

        [TestMethod]
        public void ShouldSetDependencies()
        {
            string dependency1 = "ModuleA";
            string dependency2 = "ModuleB";

            ModuleInfoGroup groupInfo = new ModuleInfoGroup();
            groupInfo.AddModule("MockModule", typeof(MockModule), dependency1, dependency2);

            Assert.IsNotNull(groupInfo.ElementAt(0).DependsOn);
            Assert.AreEqual(2, groupInfo.ElementAt(0).DependsOn.Count);
            Assert.IsTrue(groupInfo.ElementAt(0).DependsOn.Contains(dependency1));
            Assert.IsTrue(groupInfo.ElementAt(0).DependsOn.Contains(dependency2));
        }

        [TestMethod]
        public void ShouldUseTypeNameIfNoNameSpecified()
        {
            ModuleInfoGroup groupInfo = new ModuleInfoGroup();
            groupInfo.AddModule(typeof(MockModule));

            Assert.AreEqual<int>(1, groupInfo.Count);
            Assert.AreEqual<string>(typeof(MockModule).Name, groupInfo.ElementAt(0).ModuleName);
        }


        public class MockModule : IModule
        {
            public void Initialize()
            {
            }
        }
    }
}
