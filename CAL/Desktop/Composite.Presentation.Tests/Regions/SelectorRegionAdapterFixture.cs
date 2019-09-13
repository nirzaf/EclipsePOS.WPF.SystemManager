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
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class SelectorRegionAdapterFixture
    {
        [TestMethod]
        public void AdapterAddsSelectorItemsSourceSyncBehavior()
        {
            var control = new ListBox();
            IRegionAdapter adapter = new TestableSelectorRegionAdapter();

            IRegion region = adapter.Initialize(control, "Region1");
            Assert.IsNotNull(region);

            Assert.IsInstanceOfType(region.Behaviors["SelectorItemsSourceSyncBehavior"], typeof(SelectorItemsSourceSyncBehavior));
            
        }


        [TestMethod]
        public void AdapterDoesNotPreventRegionFromBeingGarbageCollected()
        {
            var selector = new ListBox();
            object model = new object();
            IRegionAdapter adapter = new SelectorRegionAdapter(null);

            var region = adapter.Initialize(selector, "Region1");
            region.Add(model);

            WeakReference regionWeakReference = new WeakReference(region);
            WeakReference controlWeakReference = new WeakReference(selector);
            Assert.IsTrue(regionWeakReference.IsAlive);
            Assert.IsTrue(controlWeakReference.IsAlive);

            region = null;
            selector = null;
            GC.Collect();
            GC.Collect();

            Assert.IsFalse(regionWeakReference.IsAlive);
            Assert.IsFalse(controlWeakReference.IsAlive);
        }

        [TestMethod]
        public void ActivatingTheViewShouldUpdateTheSelectedItem()
        {
            var selector = new ListBox();
            var view1 = new object();
            var view2 = new object();

            IRegionAdapter adapter = new SelectorRegionAdapter(null);

            var region = adapter.Initialize(selector, "Region1");
            region.Add(view1);
            region.Add(view2);

            Assert.AreNotEqual(view1, selector.SelectedItem);

            region.Activate(view1);

            Assert.AreEqual(view1, selector.SelectedItem);

            region.Activate(view2);

            Assert.AreEqual(view2, selector.SelectedItem);
        }

        [TestMethod]
        public void DeactivatingTheSelectedViewShouldUpdateTheSelectedItem()
        {
            var selector = new ListBox();
            var view1 = new object();
            IRegionAdapter adapter = new SelectorRegionAdapter(null);
            var region = adapter.Initialize(selector, "Region1");
            region.Add(view1);

            region.Activate(view1);

            Assert.AreEqual(view1, selector.SelectedItem);

            region.Deactivate(view1);

            Assert.AreNotEqual(view1, selector.SelectedItem);
        }


        private class TestableSelectorRegionAdapter : SelectorRegionAdapter
        {
            public TestableSelectorRegionAdapter()
                : base(null)
            {
            }


            protected override IRegion CreateRegion()
            {
                return new Region();
            }
        }
    }
}
