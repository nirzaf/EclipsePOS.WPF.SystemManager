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
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class RegionActiveAwareBehaviorFixture
    {
        [TestMethod]
        public void SetsIsActivePropertyOnIActiveAwareObjects()
        {
            var region = new MockRegion();
            var behavior = new RegionActiveAwareBehavior { Region = region };
            behavior.Attach();
            var collection = region.MockActiveViews.Items;

            ActiveAwareObject activeAwareObject = new ActiveAwareObject();

            Assert.IsFalse(activeAwareObject.IsActive);
            collection.Add(activeAwareObject);

            Assert.IsTrue(activeAwareObject.IsActive);

            collection.Remove(activeAwareObject);
            Assert.IsFalse(activeAwareObject.IsActive);
        }

        [TestMethod]
        public void DetachStopsListeningForChanges()
        {
            var region = new MockRegion();
            var behavior = new RegionActiveAwareBehavior { Region = region };
            var collection = region.MockActiveViews.Items;
            behavior.Attach();
            behavior.Detach();
            ActiveAwareObject activeAwareObject = new ActiveAwareObject();

            collection.Add(activeAwareObject);

            Assert.IsFalse(activeAwareObject.IsActive);
        }

        [TestMethod]
        public void DoesNotThrowWhenAddingNonActiveAwareObjects()
        {
            var region = new MockRegion();
            var behavior = new RegionActiveAwareBehavior { Region = region };
            behavior.Attach();
            var collection = region.MockActiveViews.Items;

            collection.Add(new object());
        }

        class ActiveAwareObject : IActiveAware
        {
            public bool IsActive { get; set; }
            public event EventHandler IsActiveChanged;
        }
    }
}