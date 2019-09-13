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
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests
{
    [TestClass]
    public class ServiceLocatorExtensionsFixture
    {
        [TestMethod]
        public void TryResolveShouldReturnNullIfNotFound()
        {
            IServiceLocator sl = new MockServiceLocator(() => null);

            object value = sl.TryResolve(typeof(ServiceLocatorExtensionsFixture));

            Assert.IsNull(value);
        }

        [TestMethod]
        public void ShouldResolveFoundtypes()
        {
            IServiceLocator sl = new MockServiceLocator(() => new ServiceLocatorExtensionsFixture());

            object value = sl.TryResolve(typeof(ServiceLocatorExtensionsFixture));

            Assert.IsNotNull(value);
        }

        [TestMethod]
        public void GenericTryResolveShouldReturn()
        {
            IServiceLocator sl = new MockServiceLocator(() => new ServiceLocatorExtensionsFixture());

            ServiceLocatorExtensionsFixture value = sl.TryResolve<ServiceLocatorExtensionsFixture>();

            Assert.IsNotNull(value);
        }
    }

    internal class MockServiceLocator : ServiceLocatorImplBase
    {
        public Func<object> ResolveMethod;

        public MockServiceLocator(Func<object> resolveMethod)
        {
            ResolveMethod = resolveMethod;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return ResolveMethod();
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return null;
        }
    }
}