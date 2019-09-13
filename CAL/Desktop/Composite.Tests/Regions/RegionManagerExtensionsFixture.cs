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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Tests.Mocks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Regions
{
    [TestClass]
    public class RegionManagerExtensionsFixture
    {
        [TestMethod]
        public void CanAddViewToRegion()
        {
            var regionManager = new MockRegionManager();
            var view1 = new object();
            var view2 = new object();


            IRegion region = new MockRegion();
            region.Name = "RegionName";
            regionManager.Regions.Add(region);

            regionManager.AddToRegion("RegionName", view1);
            regionManager.AddToRegion("RegionName", view2);

            Assert.IsTrue(regionManager.Regions["RegionName"].Views.Contains(view1));
            Assert.IsTrue(regionManager.Regions["RegionName"].Views.Contains(view2));
        }

        [TestMethod]
        public void CanRegisterViewType()
        {
            try
            {
                var mockRegionContentRegistry = new MockRegionContentRegistry();

                string regionName = null;
                Type viewType = null;

                mockRegionContentRegistry.RegisterContentWithViewType = (name, type) =>
                                                                            {
                                                                                regionName = name;
                                                                                viewType = type;
                                                                                return null;
                                                                            };
                ServiceLocator.SetLocatorProvider(
                    () => new MockServiceLocator(
                        () => mockRegionContentRegistry));

                var regionManager = new MockRegionManager();

                regionManager.RegisterViewWithRegion("Region1", typeof (object));

                Assert.AreEqual(regionName, "Region1");
                Assert.AreEqual(viewType, typeof(object));
                

            }
            finally
            {
                ServiceLocator.SetLocatorProvider(null);
            }
        }

        [TestMethod]
        public void CanRegisterDelegate()
        {
            try
            {
                var mockRegionContentRegistry = new MockRegionContentRegistry();

                string regionName = null;
                Func<object> contentDelegate = null;

                Func<object> expectedDelegate = () => true;
                mockRegionContentRegistry.RegisterContentWithDelegate = (name, usedDelegate) =>
                {
                    regionName = name;
                    contentDelegate = usedDelegate;
                    return null;
                };
                ServiceLocator.SetLocatorProvider(
                    () => new MockServiceLocator(
                        () => mockRegionContentRegistry));

                var regionManager = new MockRegionManager();

                regionManager.RegisterViewWithRegion("Region1", expectedDelegate);

                Assert.AreEqual("Region1", regionName);
                Assert.AreEqual(expectedDelegate, contentDelegate);


            }
            finally
            {
                ServiceLocator.SetLocatorProvider(null);
            }
        }

        [TestMethod]
        public void CanAddRegionToRegionManager()
        {
            var regionManager = new MockRegionManager();
            var region = new MockRegion();

            regionManager.Regions.Add("region", region);

            Assert.AreEqual(1, regionManager.MockRegionCollection.Count);
            Assert.AreEqual("region", region.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfRegionNameArgumentIsDifferentToRegionNameProperty()
        {
            var regionManager = new MockRegionManager();
            var region = new MockRegion();

            region.Name = "region";

            regionManager.Regions.Add("another region", region);
        }
    }

    internal class MockRegionContentRegistry : IRegionViewRegistry
    {
        public Func<string, Type, object> RegisterContentWithViewType;
        public Func<string, Func<object>, object> RegisterContentWithDelegate;
        public event EventHandler<ViewRegisteredEventArgs> ContentRegistered;
        public IEnumerable<object> GetContents(string regionName)
        {
            return null;
        }

        void IRegionViewRegistry.RegisterViewWithRegion(string regionName, Type viewType)
        {
            if (RegisterContentWithViewType != null)
            {
                RegisterContentWithViewType(regionName, viewType);
            }
        }

        void IRegionViewRegistry.RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
        {
            if (RegisterContentWithDelegate != null)
            {
                RegisterContentWithDelegate(regionName, getContentDelegate);
            }

        }
    }
}
