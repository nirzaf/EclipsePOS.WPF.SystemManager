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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.Practices.Composite.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class RegionManagerRegistrationBehaviorFixture
    {
        [TestMethod]
        public void ShouldRegisterRegionIfRegionManagerIsSet()
        {
            var control = new ItemsControl();
            var regionManager = new MockRegionManager();
            var accessor = new MockRegionManagerAccessor
            {
                GetRegionManager = d => regionManager
            };
            var region = new MockRegion() {Name = "myRegionName"};
            var behavior = new RegionManagerRegistrationBehavior()
                               {
                                   RegionManagerAccessor = accessor,
                                   Region = region,
                                   HostControl = control
                               };

            behavior.Attach();

            Assert.IsTrue(regionManager.MockRegionCollection.AddCalled);
            Assert.AreSame(region, regionManager.MockRegionCollection.AddArgument);
        }

        [TestMethod]
        public void DoesNotFailIfRegionManagerIsNotSet()
        {
            var control = new ItemsControl();
            var accessor = new MockRegionManagerAccessor();

            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = new MockRegion() { Name = "myRegionWithoutManager" },
                HostControl = control
            };
            behavior.Attach();
        }

        [TestMethod]
        public void RegionGetsAddedInRegionManagerWhenAddedIntoAScopeAndAccessingRegions()
        {
            var regionManager = new MockRegionManager();
            var control = new MockFrameworkElement();

            var regionScopeControl = new ContentControl();
            var accessor = new MockRegionManagerAccessor
            {
                GetRegionManager = d => d == regionScopeControl ? regionManager : null
            };

            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = new MockRegion() { Name = "myRegionName" },
                HostControl = control
            };
            behavior.Attach();

            Assert.IsFalse(regionManager.MockRegionCollection.AddCalled);

            regionScopeControl.Content = control;
            accessor.UpdateRegions();

            Assert.IsTrue(regionManager.MockRegionCollection.AddCalled);
        }

        [TestMethod]
        public void RegionDoesNotGetAddedTwiceWhenUpdatingRegions()
        {
            var regionManager = new MockRegionManager();
            var control = new MockFrameworkElement();

            var regionScopeControl = new ContentControl();
            var accessor = new MockRegionManagerAccessor
            {
                GetRegionManager = d => d == regionScopeControl ? regionManager : null
            };

            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = new MockRegion() { Name = "myRegionName" },
                HostControl = control
            };
            behavior.Attach();

            Assert.IsFalse(regionManager.MockRegionCollection.AddCalled);

            regionScopeControl.Content = control;
            accessor.UpdateRegions();

            Assert.IsTrue(regionManager.MockRegionCollection.AddCalled);
            regionManager.MockRegionCollection.AddCalled = false;

            accessor.UpdateRegions();
            Assert.IsFalse(regionManager.MockRegionCollection.AddCalled);
        }

        [TestMethod]
        public void RegionGetsRemovedFromRegionManagerWhenRemovedFromScope()
        {
            var regionManager = new MockRegionManager();
            var control = new MockFrameworkElement();
            var regionScopeControl = new ContentControl();
            var accessor = new MockRegionManagerAccessor
            {
                GetRegionManager = d => d == regionScopeControl ? regionManager : null
            };

            var region = new MockRegion() {Name = "myRegionName"};
            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = region,
                HostControl = control
            };
            behavior.Attach();

            regionScopeControl.Content = control;
            accessor.UpdateRegions();
            Assert.IsTrue(regionManager.MockRegionCollection.AddCalled);
            Assert.AreSame(region, regionManager.MockRegionCollection.AddArgument);

            regionScopeControl.Content = null;
            accessor.UpdateRegions();

            Assert.IsTrue(regionManager.MockRegionCollection.RemoveCalled);
        }

        [TestMethod]
        public void CanAttachBeforeSettingName()
        {
            var control = new ItemsControl();
            var regionManager = new MockRegionManager();
            var accessor = new MockRegionManagerAccessor
            {
                GetRegionManager = d => regionManager
            };
            var region = new MockRegion() { Name = null };
            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = region,
                HostControl = control
            };

            behavior.Attach();
            Assert.IsFalse(regionManager.MockRegionCollection.AddCalled);

            region.Name = "myRegionName";

            Assert.IsTrue(regionManager.MockRegionCollection.AddCalled);
            Assert.AreSame(region, regionManager.MockRegionCollection.AddArgument);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void HostControlSetAfterAttachThrows()
        {
            var behavior = new RegionManagerRegistrationBehavior();
            var hostControl1 = new MockDependencyObject();
            var hostControl2 = new MockDependencyObject();
            behavior.HostControl = hostControl1;
            behavior.Attach();
            behavior.HostControl = hostControl2;
        }

        [TestMethod]
        public void BehaviorDoesNotPreventRegionManagerFromBeingGarbageCollected()
        {
            var control = new MockFrameworkElement();
            var regionManager = new MockRegionManager();
            var regionManagerWeakReference = new WeakReference(regionManager);

            var accessor = new MockRegionManagerAccessor
            {
                GetRegionName = d => "myRegionName",
                GetRegionManager = d => regionManager
            };

            var behavior = new RegionManagerRegistrationBehavior()
            {
                RegionManagerAccessor = accessor,
                Region = new MockRegion(),
                HostControl = control
            };
            behavior.Attach();

            Assert.IsTrue(regionManagerWeakReference.IsAlive);
            GC.KeepAlive(regionManager);

            regionManager = null;

            GC.Collect();

            Assert.IsFalse(regionManagerWeakReference.IsAlive);
        }

        internal class MockRegionManager : IRegionManager
        {
            public MockRegionCollection MockRegionCollection = new MockRegionCollection();

            #region IRegionManager Members

            public IRegionCollection Regions
            {
                get { return this.MockRegionCollection; }
            }

            IRegionManager IRegionManager.CreateRegionManager()
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }
    }

    internal class MockRegionCollection : IRegionCollection
    {
        public bool RemoveCalled;
        public bool AddCalled;
        public IRegion AddArgument;

        IEnumerator<IRegion> IEnumerable<IRegion>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public IRegion this[string regionName]
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Add(IRegion region)
        {
            AddCalled = true;
            AddArgument = region;
        }

        public bool Remove(string regionName)
        {
            RemoveCalled = true;
            return true;
        }

        public bool ContainsRegionWithName(string regionName)
        {
            throw new System.NotImplementedException();
        }
    }
}
