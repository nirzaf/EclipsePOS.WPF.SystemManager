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
using System.Windows;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class SyncRegionContextWithHostBehaviorFixture
    {
        [TestMethod]
        public void ShouldForwardRegionContextValueToHostControl()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            DependencyObject mockDependencyObject = new MockDependencyObject();
            behavior.HostControl = mockDependencyObject;

            behavior.Attach();
            Assert.IsNull(region.Context);
            RegionContext.GetObservableContext(mockDependencyObject).Value = "NewValue";

            Assert.AreEqual("NewValue", region.Context);

        }

        [TestMethod]
        public void ShouldUpdateHostControlRegionContextValueWhenContextOfRegionChanges()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            DependencyObject mockDependencyObject = new MockDependencyObject();
            behavior.HostControl = mockDependencyObject;

            ObservableObject<object> observableRegionContext = RegionContext.GetObservableContext(mockDependencyObject);

            behavior.Attach();
            Assert.IsNull(observableRegionContext.Value);
            region.Context = "NewValue";

            Assert.AreEqual("NewValue", observableRegionContext.Value);

        }

        [TestMethod]
        public void ShouldGetInitialValueFromHostAndSetOnRegion()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            DependencyObject mockDependencyObject = new MockDependencyObject();
            behavior.HostControl = mockDependencyObject;

            RegionContext.GetObservableContext(mockDependencyObject).Value = "NewValue";

            Assert.IsNull(region.Context);
            behavior.Attach();
            Assert.AreEqual("NewValue", region.Context);

        }

        [TestMethod]
        public void AttachShouldNotThrowWhenHostControlNull()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            behavior.Attach();
        }

        [TestMethod]
        public void AttachShouldNotThrowWhenHostControlNullAndRegionContextSet()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            behavior.Attach();
            region.Context = "Changed";
        }

        [TestMethod]
        public void ChangingRegionContextObservableObjectValueShouldAlsoChangeRegionContextDependencyProperty()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            DependencyObject hostControl = new MockDependencyObject();
            behavior.HostControl = hostControl;

            behavior.Attach();

            Assert.IsNull(RegionManager.GetRegionContext(hostControl));
            RegionContext.GetObservableContext(hostControl).Value = "NewValue";

            Assert.AreEqual("NewValue", RegionManager.GetRegionContext(hostControl));
        }

        [TestMethod]
        public void AttachShouldChangeRegionContextDependencyProperty()
        {
            MockRegion region = new MockRegion();

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            behavior.Region = region;
            DependencyObject hostControl = new MockDependencyObject();
            behavior.HostControl = hostControl;

            RegionContext.GetObservableContext(hostControl).Value = "NewValue";

            Assert.IsNull(RegionManager.GetRegionContext(hostControl));
            behavior.Attach();
            Assert.AreEqual("NewValue", RegionManager.GetRegionContext(hostControl));  
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingHostControlAfterAttachThrows()
        {

            SyncRegionContextWithHostBehavior behavior = new SyncRegionContextWithHostBehavior();
            DependencyObject hostControl1 = new MockDependencyObject();
            behavior.HostControl = hostControl1;

            behavior.Attach();
            DependencyObject hostControl2 = new MockDependencyObject();
            behavior.HostControl = hostControl2;
        }
    }
}