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
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.Practices.Composite.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionBehaviorFactoryFixture
    {
        [TestMethod]
        public void CanRegisterType()
        {
            RegionBehaviorFactory factory = new RegionBehaviorFactory(null);

            factory.AddIfMissing("key1", typeof(MockRegionBehavior));
            factory.AddIfMissing("key2", typeof(MockRegionBehavior));

            Assert.AreEqual(2, factory.Count());
            Assert.IsTrue(factory.ContainsKey("key1"));
            
        }

        [TestMethod]
        public void WillNotAddTypesWithDuplicateKeys()
        {
            RegionBehaviorFactory factory = new RegionBehaviorFactory(null);

            factory.AddIfMissing("key1", typeof(MockRegionBehavior));
            factory.AddIfMissing("key1", typeof(MockRegionBehavior));

            Assert.AreEqual(1, factory.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTypeThatDoesNotInheritFromIRegionBehaviorThrows()
        {
            RegionBehaviorFactory factory = new RegionBehaviorFactory(null);

            factory.AddIfMissing("key1", typeof(object));
        }

        [TestMethod]
        public void CanCreateRegisteredType()
        {
            var expectedBehavior = new MockRegionBehavior();

            RegionBehaviorFactory factory = new RegionBehaviorFactory(new MockServiceLocator() { GetInstance = (t) => expectedBehavior });

            factory.AddIfMissing("key1", typeof(MockRegionBehavior));
            var behavior = factory.CreateFromKey("key1");

            Assert.AreSame(expectedBehavior, behavior);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateWithUnknownKeyThrows()
        {
            RegionBehaviorFactory factory = new RegionBehaviorFactory(null);

            factory.CreateFromKey("Key1");
        }

    }
}
