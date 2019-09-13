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
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class AutoPopulateRegionBehaviorFixture
    {
        [TestMethod]
        public void ShouldGetViewsFromRegistryOnAttach()
        {
            var region = new MockRegion() { Name = "MyRegion" };
            var viewFactory = new MockRegionContentRegistry();
            var view = new object();
            viewFactory.GetContentsReturnValue.Add(view);
            var behavior = new AutoPopulateRegionBehavior(viewFactory)
                               {
                                   Region = region
                               };

            behavior.Attach();

            Assert.AreEqual("MyRegion", viewFactory.GetContentsArgumentRegionName);
            Assert.AreEqual(1, region.MockViews.Items.Count);
            Assert.AreEqual(view, region.MockViews.Items[0]);
        }

        [TestMethod]
        public void ShouldGetViewsFromRegistryWhenRegisteringItAfterAttach()
        {
            var region = new MockRegion() { Name = "MyRegion" };
            var viewFactory = new MockRegionContentRegistry();
            var behavior = new AutoPopulateRegionBehavior(viewFactory)
                               {
                                   Region = region
                               };
            var view = new object();

            behavior.Attach();
            viewFactory.GetContentsReturnValue.Add(view);
            viewFactory.RaiseContentRegistered("MyRegion", view);

            Assert.AreEqual("MyRegion", viewFactory.GetContentsArgumentRegionName);
            Assert.AreEqual(1, region.MockViews.Items.Count);
            Assert.AreEqual(view, region.MockViews.Items[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NullRegionThrows()
        {
            var behavior = new AutoPopulateRegionBehavior(new MockRegionContentRegistry());

            behavior.Attach();
        }

        [TestMethod]
        public void CanAttachBeforeSettingName()
        {
            var region = new MockRegion() { Name = null };
            var viewFactory = new MockRegionContentRegistry();
            var view = new object();
            viewFactory.GetContentsReturnValue.Add(view);
            var behavior = new AutoPopulateRegionBehavior(viewFactory)
            {
                Region = region
            };

            behavior.Attach();
            Assert.IsFalse(viewFactory.GetContentsCalled);

            region.Name = "MyRegion";

            Assert.IsTrue(viewFactory.GetContentsCalled);
            Assert.AreEqual("MyRegion", viewFactory.GetContentsArgumentRegionName);
            Assert.AreEqual(1, region.MockViews.Items.Count);
            Assert.AreEqual(view, region.MockViews.Items[0]);
        }

        private class MockRegionContentRegistry : IRegionViewRegistry
        {
            public readonly List<object> GetContentsReturnValue = new List<object>();
            public string GetContentsArgumentRegionName;
            public bool GetContentsCalled;

            public event EventHandler<ViewRegisteredEventArgs> ContentRegistered;

            public IEnumerable<object> GetContents(string regionName)
            {
                GetContentsCalled = true;
                this.GetContentsArgumentRegionName = regionName;
                return this.GetContentsReturnValue;
            }

            public void RaiseContentRegistered(string regionName, object view)
            {
                this.ContentRegistered(this, new ViewRegisteredEventArgs(regionName, () => view));
            }

            public void RegisterViewWithRegion(string regionName, Type viewType)
            {
                throw new NotImplementedException();
            }

            public void RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
            {
                throw new NotImplementedException();
            }
        }
    }
}