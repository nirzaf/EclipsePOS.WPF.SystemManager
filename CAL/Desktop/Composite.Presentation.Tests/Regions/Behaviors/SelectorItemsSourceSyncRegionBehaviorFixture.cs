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
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class SelectorItemsSourceSyncRegionBehaviorFixture
    {
        [TestMethod]
        public void CanAttachToSelector()
        {
            SelectorItemsSourceSyncBehavior behavior = CreateBehavior();
            behavior.Attach();

            Assert.IsTrue(behavior.IsAttached);
        }

        [TestMethod]
        public void AttachSetsItemsSourceOfSelector()
        {
            SelectorItemsSourceSyncBehavior behavior = CreateBehavior();

            var v1 = new Button();
            var v2 = new Button();

            behavior.Region.Add(v1);
            behavior.Region.Add(v2);

            behavior.Attach();

            Assert.AreEqual(2, (behavior.HostControl as Selector).Items.Count);
        }

        [TestMethod]
        public void SelectionChangedShouldChangeActiveViews()
        {
            SelectorItemsSourceSyncBehavior behavior = CreateBehavior();

            var v1 = new Button();
            var v2 = new Button();

            behavior.Region.Add(v1);
            behavior.Region.Add(v2);

            behavior.Attach();

            (behavior.HostControl as Selector).SelectedItem = v1;
            var activeViews = behavior.Region.ActiveViews;

            Assert.AreEqual(1, activeViews.Count());
            Assert.AreEqual(v1, activeViews.First());

            (behavior.HostControl as Selector).SelectedItem = v2;

            Assert.AreEqual(1, activeViews.Count());
            Assert.AreEqual(v2, activeViews.First());
        }

        [TestMethod]
        public void ActiveViewChangedShouldChangeSelectedItem()
        {
            SelectorItemsSourceSyncBehavior behavior = CreateBehavior();

            var v1 = new Button();
            var v2 = new Button();

            behavior.Region.Add(v1);
            behavior.Region.Add(v2);

            behavior.Attach();

            behavior.Region.Activate(v1);
            Assert.AreEqual(v1, (behavior.HostControl as Selector).SelectedItem);

            behavior.Region.Activate(v2);
            Assert.AreEqual(v2, (behavior.HostControl as Selector).SelectedItem);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ItemsSourceSetThrows()
        {
            SelectorItemsSourceSyncBehavior behavior = CreateBehavior();

            (behavior.HostControl as Selector).ItemsSource = new[] {new Button()};

            behavior.Attach();
        }

        [TestMethod]
#if SILVERLIGHT
        [Ignore]
#endif
        public void ControlWithExistingBindingOnItemsSourceWithNullValueThrows()
        {
            var behavor = CreateBehavior();

            Binding binding = new Binding("Enumerable");
            binding.Source = new SimpleModel() { Enumerable = null };
            (behavor.HostControl as Selector).SetBinding(ItemsControl.ItemsSourceProperty, binding);

            try
            {
                behavor.Attach();

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                StringAssert.Contains(ex.Message, "ItemsControl's ItemsSource property is not empty.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingViewToTwoRegionsThrows()
        {
            var behavior1 = CreateBehavior();
            var behavior2 = CreateBehavior();

            behavior1.Attach();
            behavior2.Attach();
            var v1 = new Button();

            behavior1.Region.Add(v1);
            behavior2.Region.Add(v1);
        }

        [TestMethod]
        public void ReactivatingViewAddsViewToTab()
        {
            var behavior1 = CreateBehavior();
            behavior1.Attach();

            var v1 = new Button();
            var v2 = new Button();

            behavior1.Region.Add(v1);
            behavior1.Region.Add(v2);

            behavior1.Region.Activate(v1);
            Assert.IsTrue(behavior1.Region.ActiveViews.First() == v1);

            behavior1.Region.Activate(v2);
            Assert.IsTrue(behavior1.Region.ActiveViews.First() == v2);

            behavior1.Region.Activate(v1);
            Assert.IsTrue(behavior1.Region.ActiveViews.First() == v1);
        }

#if !SILVERLIGHT
        // This test can only run in WPF, because the silverlight listbox doesn't support multi selection mode.
        [TestMethod]
        public void ShouldAllowMultipleSelectedItemsForListBox()
        {
            var behavior1 = CreateBehavior();
            ListBox listBox = new ListBox();
            listBox.SelectionMode = SelectionMode.Multiple;
            behavior1.HostControl = listBox;
            behavior1.Attach();

            var v1 = new Button();
            var v2 = new Button();

            behavior1.Region.Add(v1);
            behavior1.Region.Add(v2);

            listBox.SelectedItems.Add(v1);
            listBox.SelectedItems.Add(v2);

            Assert.IsTrue(behavior1.Region.ActiveViews.Contains(v1));
            Assert.IsTrue(behavior1.Region.ActiveViews.Contains(v2));

        }

#endif
        private SelectorItemsSourceSyncBehavior CreateBehavior()
        {
            Region region = new Region();
#if SILVERLIGHT
            Selector selector = new ComboBox();
#else
            Selector selector = new TabControl();
#endif
            var behavior = new SelectorItemsSourceSyncBehavior();
            behavior.HostControl = selector;
            behavior.Region = region;
            return behavior;
        }

        private class SimpleModel
        {
            public IEnumerable Enumerable { get; set; }
        }
    }
}
