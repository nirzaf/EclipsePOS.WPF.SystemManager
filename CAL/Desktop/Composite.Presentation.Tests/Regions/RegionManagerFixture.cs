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
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.Practices.Composite.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionManagerFixture
    {
        [TestMethod]
        public void CanAddRegion()
        {
            IRegion region1 = new MockRegion();
            region1.Name = "MainRegion";

            RegionManager regionManager = new RegionManager();
            regionManager.Regions.Add(region1);

            IRegion region2 = regionManager.Regions["MainRegion"];
            Assert.AreSame(region1, region2);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ShouldFailIfRegionDoesntExists()
        {
            RegionManager regionManager = new RegionManager();
            IRegion region = regionManager.Regions["nonExistentRegion"];
        }

        [TestMethod]
        public void CanCheckTheExistenceOfARegion()
        {
            RegionManager regionManager = new RegionManager();
            bool result = regionManager.Regions.ContainsRegionWithName("noRegion");

            Assert.IsFalse(result);

            IRegion region = new MockRegion();
            region.Name = "noRegion";
            regionManager.Regions.Add(region);

            result = regionManager.Regions.ContainsRegionWithName("noRegion");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingMultipleRegionsWithSameNameThrowsArgumentException()
        {
            var regionManager = new RegionManager();
            regionManager.Regions.Add(new MockRegion { Name = "region name" });
            regionManager.Regions.Add(new MockRegion { Name = "region name" });
        }

        [TestMethod]
        public void AddPassesItselfAsTheRegionManagerOfTheRegion()
        {
            var regionManager = new RegionManager();
            var region = new MockRegion();
            region.Name = "region";
            regionManager.Regions.Add(region);

            Assert.AreSame(regionManager, region.RegionManager);
        }

        [TestMethod]
        public void CreateRegionManagerCreatesANewInstance()
        {
            var regionManager = new RegionManager();
            var createdRegionManager = regionManager.CreateRegionManager();
            Assert.IsNotNull(createdRegionManager);
            Assert.IsInstanceOfType(createdRegionManager, typeof(RegionManager));
            Assert.AreNotSame(regionManager, createdRegionManager);
        }

        [TestMethod]
        public void CanRemoveRegion()
        {
            var regionManager = new RegionManager();
            IRegion region = new MockRegion();
            region.Name = "TestRegion";
            regionManager.Regions.Add(region);

            regionManager.Regions.Remove("TestRegion");

            Assert.IsFalse(regionManager.Regions.ContainsRegionWithName("TestRegion"));
        }

        [TestMethod]
        public void ShouldRemoveRegionManagerWhenRemoving()
        {
            var regionManager = new RegionManager();
            var region = new MockRegion();
            region.Name = "TestRegion";
            regionManager.Regions.Add(region);

            regionManager.Regions.Remove("TestRegion");

            Assert.IsNull(region.RegionManager);
        }

        [TestMethod]
        public void UpdatingRegionsGetsCalledWhenAccessingRegionMembers()
        {
            var listener = new MySubscriberClass();

            try
            {
                RegionManager.UpdatingRegions += listener.OnUpdatingRegions;
                RegionManager regionManager = new RegionManager();
                regionManager.Regions.ContainsRegionWithName("TestRegion");
                Assert.IsTrue(listener.OnUpdatingRegionsCalled);

                listener.OnUpdatingRegionsCalled = false;
                regionManager.Regions.Add(new MockRegion() { Name = "TestRegion" });
                Assert.IsTrue(listener.OnUpdatingRegionsCalled);

                listener.OnUpdatingRegionsCalled = false;
                var region = regionManager.Regions["TestRegion"];
                Assert.IsTrue(listener.OnUpdatingRegionsCalled);

                listener.OnUpdatingRegionsCalled = false;
                regionManager.Regions.Remove("TestRegion");
                Assert.IsTrue(listener.OnUpdatingRegionsCalled);

                listener.OnUpdatingRegionsCalled = false;
                regionManager.Regions.GetEnumerator();
                Assert.IsTrue(listener.OnUpdatingRegionsCalled);
            }
            finally
            {
                RegionManager.UpdatingRegions -= listener.OnUpdatingRegions;
            }
        }


        [TestMethod]
        public void ShouldSetObservableRegionContextWhenRegionContextChanges()
        {
            var region = new MockRegion();
            var view = new MockDependencyObject();

            var observableObject = RegionContext.GetObservableContext(view);

            bool propertyChangedCalled = false;
            observableObject.PropertyChanged += (sender, args) => propertyChangedCalled = true;

            Assert.IsNull(observableObject.Value);
            RegionManager.SetRegionContext(view, "MyContext");
            Assert.IsTrue(propertyChangedCalled);
            Assert.AreEqual("MyContext", observableObject.Value);
        }

        [TestMethod]
        public void ShouldNotPreventSubscribersToStaticEventFromBeingGarbageCollected()
        {
            var subscriber = new MySubscriberClass();
            RegionManager.UpdatingRegions += subscriber.OnUpdatingRegions;
            RegionManager.UpdateRegions();
            Assert.IsTrue(subscriber.OnUpdatingRegionsCalled);
            WeakReference subscriberWeakReference = new WeakReference(subscriber);

            subscriber = null;
            GC.Collect();

            Assert.IsFalse(subscriberWeakReference.IsAlive);
        }

        [TestMethod]
        public void ExceptionMessageWhenCallingUpdateRegionsShouldBeClear()
        {
            try
            {

                ExceptionExtensions.RegisterFrameworkExceptionType(typeof(FrameworkException));
                RegionManager.UpdatingRegions += new EventHandler(RegionManager_UpdatingRegions);

                try
                {
                    RegionManager.UpdateRegions();
                    Assert.Fail();
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex.Message.Contains("Abcde"));
                }
            }
            finally
            {
                RegionManager.UpdatingRegions -= new EventHandler(RegionManager_UpdatingRegions);
            }
        }

        public void RegionManager_UpdatingRegions(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Abcde");
            }
            catch (Exception ex)
            {
                throw new FrameworkException(ex);
            }
        }


        public class MySubscriberClass
        {
            public bool OnUpdatingRegionsCalled;

            public void OnUpdatingRegions(object sender, EventArgs e)
            {
                OnUpdatingRegionsCalled = true;
            }
        }

    }

    internal class FrameworkException : Exception
    {
        public FrameworkException(Exception inner) : base(string.Empty, inner)
        {
            
        }
    }
}