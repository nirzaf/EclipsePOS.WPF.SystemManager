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
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions.Behaviors
{
    [TestClass]
    public class BindRegionContextToDependencyObjectBehaviorFixture
    {
        [TestMethod]
        public void ShouldSetRegionContextOnAddedView()
        {
            var behavior = new BindRegionContextToDependencyObjectBehavior();
            var region = new MockRegion();
            behavior.Region = region;
            region.Context = "MyContext";
            var view = new MockDependencyObject();

            behavior.Attach();
            region.Add(view);

            var context = RegionContext.GetObservableContext(view);
            Assert.IsNotNull(context.Value);
            Assert.AreEqual("MyContext", context.Value);
        }

        [TestMethod]
        public void ShouldSetRegionContextOnAlreadyAddedViews()
        {
            var behavior = new BindRegionContextToDependencyObjectBehavior();
            var region = new MockRegion();
            var view = new MockDependencyObject();
            region.Add(view);
            behavior.Region = region;
            region.Context = "MyContext";

            behavior.Attach();

            var context = RegionContext.GetObservableContext(view);
            Assert.IsNotNull(context.Value);
            Assert.AreEqual("MyContext", context.Value);
        }

        [TestMethod]
        public void ShouldRemoveContextToViewRemovedFromRegion()
        {
            var behavior = new BindRegionContextToDependencyObjectBehavior();
            var region = new MockRegion();
            var view = new MockDependencyObject();
            region.Add(view);
            behavior.Region = region;
            region.Context = "MyContext";
            behavior.Attach();

            region.Remove(view);

            var context = RegionContext.GetObservableContext(view);
            Assert.IsNull(context.Value);
        }

        [TestMethod]
        public void ShouldSetRegionContextOnContextChange()
        {
            var behavior = new BindRegionContextToDependencyObjectBehavior();
            var region = new MockRegion();
            var view = new MockDependencyObject();
            region.Add(view);
            behavior.Region = region;
            region.Context = "MyContext";
            behavior.Attach();
            Assert.AreEqual("MyContext", RegionContext.GetObservableContext(view).Value);

            region.Context = "MyNewContext";
            region.OnPropertyChange("Context");

            Assert.AreEqual("MyNewContext", RegionContext.GetObservableContext(view).Value);
        }

        [TestMethod]
        public void ViewInRegionCanBeObject()
        {
            var behavior = new BindRegionContextToDependencyObjectBehavior();
            var region = new MockRegion();

            behavior.Region = region;
            behavior.Attach();

            region.Add(new object());
            region.Context = "new context";
        }
    }
}