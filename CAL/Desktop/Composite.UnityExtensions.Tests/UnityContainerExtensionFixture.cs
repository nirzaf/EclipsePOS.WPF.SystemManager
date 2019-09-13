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
using System.Collections.Generic;
using Microsoft.Practices.Composite.UnityExtensions.Tests.Mocks;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.UnityExtensions.Tests
{
    [TestClass]
    public class UnityContainerExtensionFixture
    {
        [TestMethod]
        public void ExtensionReturnsTrueIfThereIsAPolicyForType()
        {
            UnityContainer container = new UnityContainer();
            container.AddNewExtension<UnityBootstrapperExtension>();

            container.RegisterType<object, string>();
            Assert.IsTrue(container.IsTypeRegistered(typeof(object)));
            Assert.IsFalse(container.IsTypeRegistered(typeof(int)));

            container.RegisterType<IList<int>, List<int>>();

            Assert.IsTrue(container.IsTypeRegistered(typeof(IList<int>)));
            Assert.IsFalse(container.IsTypeRegistered(typeof(IList<string>)));

            container.RegisterType(typeof(IDictionary<,>), typeof(Dictionary<,>));
            Assert.IsTrue(container.IsTypeRegistered(typeof(IDictionary<,>)));
        }

        [TestMethod]
        public void TryResolveShouldResolveTheElementIfElementExist()
        {
            var container = new UnityContainer();
            container.RegisterType<IService, MockService>();

            object dependantA = container.TryResolve<IService>();
            Assert.IsNotNull(dependantA);
        }

        [TestMethod]
        public void TryResolveShouldReturnNullIfElementNotExist()
        {
            var container = new UnityContainer();

            object dependantA = container.TryResolve<IDependantA>();
            Assert.IsNull(dependantA);
        }

        [TestMethod]
        public void TryResolveWorksWithValueTypes()
        {
            var container = new UnityContainer();

            int valueType = container.TryResolve<int>();
            Assert.AreEqual(default(int), valueType);
        }

    }
}