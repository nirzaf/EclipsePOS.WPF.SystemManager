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
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class ItemsControlRegionAdapterFixture
    {
        [TestMethod]
        public void AdapterAssociatesItemsControlWithRegion()
        {
            var control = new ItemsControl();
            IRegionAdapter adapter = new TestableItemsControlRegionAdapter();

            IRegion region = adapter.Initialize(control, "Region1");
            Assert.IsNotNull(region);

            Assert.AreSame(control.ItemsSource, region.Views);
        }

        [TestMethod]
        public void AdapterAssignsARegionThatHasAllViewsActive()
        {
            var control = new ItemsControl();
            IRegionAdapter adapter = new ItemsControlRegionAdapter(null);

            IRegion region = adapter.Initialize(control, "Region1");
            Assert.IsNotNull(region);
            Assert.IsInstanceOfType(region, typeof(AllActiveRegion));
        }


        [TestMethod]
        public void ShouldMoveAlreadyExistingContentInControlToRegion()
        {
            var control = new ItemsControl();
            var view = new object();
            control.Items.Add(view);
            IRegionAdapter adapter = new TestableItemsControlRegionAdapter();

            var region = (MockRegion)adapter.Initialize(control, "Region1");

            Assert.AreEqual(1, region.MockViews.Count());
            Assert.AreSame(view, region.MockViews.ElementAt(0));
            Assert.AreSame(view, control.Items[0]);
        }

        [TestMethod]
        public void ControlWithExistingItemSourceThrows()
        {
            var control = new ItemsControl() { ItemsSource = new List<string>() };

            IRegionAdapter adapter = new TestableItemsControlRegionAdapter();

            try
            {
                var region = (MockRegion)adapter.Initialize(control, "Region1");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                StringAssert.Contains(ex.Message, "ItemsControl's ItemsSource property is not empty.");
            }
        }

        [TestMethod]
#if SILVERLIGHT
        [Ignore]
#endif
        public void ControlWithExistingBindingOnItemsSourceWithNullValueThrows()
        {
            var control = new ItemsControl();
            Binding binding = new Binding("Enumerable");
            binding.Source = new SimpleModel() { Enumerable = null };
            control.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            IRegionAdapter adapter = new TestableItemsControlRegionAdapter();

            try
            {
                var region = (MockRegion)adapter.Initialize(control, "Region1");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                StringAssert.Contains(ex.Message, "ItemsControl's ItemsSource property is not empty.");
            }
        }

        class SimpleModel
        {
            public IEnumerable Enumerable { get; set; }
        }

        private class TestableItemsControlRegionAdapter : ItemsControlRegionAdapter
        {
            public TestableItemsControlRegionAdapter() : base (null)
            {
            }

            private MockRegion region = new MockRegion();

            protected override IRegion CreateRegion()
            {
                return region;
            }
        }
    }
}