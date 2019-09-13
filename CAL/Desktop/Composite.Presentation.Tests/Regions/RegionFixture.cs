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
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionFixture
    {
        [TestMethod]
        public void CanAddContentToRegion()
        {
            IRegion region = new Region();

            Assert.AreEqual(0, region.Views.Cast<object>().Count());

            region.Add(new object());

            Assert.AreEqual(1, region.Views.Cast<object>().Count());
        }


        [TestMethod]
        public void CanRemoveContentFromRegion()
        {
            IRegion region = new Region();
            object view = new object();

            region.Add(view);
            region.Remove(view);

            Assert.AreEqual(0, region.Views.Cast<object>().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveInexistentViewThrows()
        {
            IRegion region = new Region();
            object view = new object();

            region.Remove(view);

            Assert.AreEqual(0, region.Views.Cast<object>().Count());
        }

        [TestMethod]
        public void RegionExposesCollectionOfContainedViews()
        {
            IRegion region = new Region();

            object view = new object();

            region.Add(view);

            var views = region.Views;

            Assert.IsNotNull(views);
            Assert.AreEqual(1, views.Cast<object>().Count());
            Assert.AreSame(view, views.Cast<object>().ElementAt(0));
        }

        [TestMethod]
        public void CanAddAndRetrieveNamedViewInstance()
        {
            IRegion region = new Region();
            object myView = new object();
            region.Add(myView, "MyView");
            object returnedView = region.GetView("MyView");

            Assert.IsNotNull(returnedView);
            Assert.AreSame(returnedView, myView);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingDuplicateNamedViewThrows()
        {
            IRegion region = new Region();

            region.Add(new object(), "MyView");
            region.Add(new object(), "MyView");
        }

        [TestMethod]
        public void AddNamedViewIsAlsoListedInViewsCollection()
        {
            IRegion region = new Region();
            object myView = new object();

            region.Add(myView, "MyView");

            Assert.AreEqual(1, region.Views.Cast<object>().Count());
            Assert.AreSame(myView, region.Views.Cast<object>().ElementAt(0));
        }

        [TestMethod]
        public void GetViewReturnsNullWhenViewDoesNotExistInRegion()
        {
            IRegion region = new Region();

            Assert.IsNull(region.GetView("InexistentView"));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetViewWithNullOrEmptyStringThrows()
        {
            IRegion region = new Region();

            region.GetView(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNamedViewWithNullOrEmptyStringNameThrows()
        {
            IRegion region = new Region();

            region.Add(new object(), string.Empty);
        }

        [TestMethod]
        public void GetViewReturnsNullAfterRemovingViewFromRegion()
        {
            IRegion region = new Region();
            object myView = new object();
            region.Add(myView, "MyView");
            region.Remove(myView);

            Assert.IsNull(region.GetView("MyView"));
        }

        [TestMethod]
        public void AddViewPassesSameScopeByDefaultToView()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new MockDependencyObject();

            region.Add(myView);

            Assert.AreSame(regionManager, myView.GetValue(RegionManager.RegionManagerProperty));
        }

        [TestMethod]
        public void AddViewPassesSameScopeByDefaultToNamedView()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new MockDependencyObject();

            region.Add(myView, "MyView");

            Assert.AreSame(regionManager, myView.GetValue(RegionManager.RegionManagerProperty));
        }

        [TestMethod]
        public void AddViewPassesDiferentScopeWhenAdding()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new MockDependencyObject();

            region.Add(myView, "MyView", true);

            Assert.AreNotSame(regionManager, myView.GetValue(RegionManager.RegionManagerProperty));
        }

        [TestMethod]
        public void CreatingNewScopesAsksTheRegionManagerForNewInstance()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new object();

            region.Add(myView, "MyView", true);

            Assert.IsTrue(regionManager.CreateRegionManagerCalled);
        }

        [TestMethod]
        public void AddViewReturnsExistingRegionManager()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new object();

            var returnedRegionManager = region.Add(myView, "MyView", false);

            Assert.AreSame(regionManager, returnedRegionManager);
        }

        [TestMethod]
        public void AddViewReturnsNewRegionManager()
        {
            var regionManager = new MockRegionManager();
            IRegion region = new Region();
            region.RegionManager = regionManager;
            var myView = new object();

            var returnedRegionManager = region.Add(myView, "MyView", true);

            Assert.AreNotSame(regionManager, returnedRegionManager);
        }

        [TestMethod]
        public void AddingNonDependencyObjectToRegionDoesNotThrow()
        {
            IRegion region = new Region();
            object model = new object();

            region.Add(model);

            Assert.AreEqual(1, region.Views.Cast<object>().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActivateNonAddedViewThrows()
        {
            IRegion region = new Region();

            object nonAddedView = new object();

            region.Activate(nonAddedView);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeactivateNonAddedViewThrows()
        {
            IRegion region = new Region();

            object nonAddedView = new object();

            region.Deactivate(nonAddedView);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ActivateNullViewThrows()
        {
            IRegion region = new Region();

            region.Activate(null);
        }

        //[TestMethod]
        //public void ShouldSelectFirstViewAdded()
        //{
        //    IRegion region = new Region();
        //    var view = new object();

        //    Assert.AreEqual(0, region.ActiveViews.Cast<object>().Count());
        //    region.Add(view);
        //    Assert.IsTrue(region.ActiveViews.Contains(view));
        //}

        //[TestMethod]
        //public void ShouldNotSelectAdditionalViewsAdded()
        //{
        //    IRegion region = new Region();
        //    var view = new object();
        //    var view2 = new object();

        //    region.Add(view);
        //    region.Add(view2);

        //    Assert.IsFalse(region.ActiveViews.Contains(view2));
        //}

        [TestMethod]
        public void AddViewRaisesCollectionViewEvent()
        {
            bool viewAddedCalled = false;

            IRegion region = new Region();
            region.Views.CollectionChanged += (sender, e) =>
                                                  {
                                                      if (e.Action == NotifyCollectionChangedAction.Add)
                                                          viewAddedCalled = true;
                                                  };

            object model = new object();
            Assert.IsFalse(viewAddedCalled);
            region.Add(model);

            Assert.IsTrue(viewAddedCalled);
        }

        [TestMethod]
        public void ViewAddedEventPassesTheViewAddedInTheEventArgs()
        {
            object viewAdded = null;

            IRegion region = new Region();
            region.Views.CollectionChanged += (sender, e) =>
                                                  {
                                                      viewAdded = e.NewItems[0];
                                                  };
            object model = new object();
            Assert.IsNull(viewAdded);
            region.Add(model);

            Assert.IsNotNull(viewAdded);
            Assert.AreSame(model, viewAdded);
        }

        [TestMethod]
        public void RemoveViewFiresViewRemovedEvent()
        {
            bool viewRemoved = false;

            IRegion region = new Region();
            object model = new object();
            region.Views.CollectionChanged += (sender, e) =>
                                                  {
                                                      if (e.Action == NotifyCollectionChangedAction.Remove)
                                                          viewRemoved = true;
                                                  };

            region.Add(model);
            Assert.IsFalse(viewRemoved);

            region.Remove(model);

            Assert.IsTrue(viewRemoved);
        }

        [TestMethod]
        public void ViewRemovedEventPassesTheViewRemovedInTheEventArgs()
        {
            object removedView = null;

            IRegion region = new Region();
            region.Views.CollectionChanged += (sender, e) =>
                                                  {
                                                      if (e.Action == NotifyCollectionChangedAction.Remove)
                                                          removedView = e.OldItems[0];
                                                  };
            object model = new object();
            region.Add(model);
            Assert.IsNull(removedView);

            region.Remove(model);

            Assert.AreSame(model, removedView);
        }

        [TestMethod]
        public void ShowViewFiresViewShowedEvent()
        {
            bool viewActivated = false;

            IRegion region = new Region();
            object model = new object();
            region.ActiveViews.CollectionChanged += (o, e) =>
                                                        {
                                                            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems.Contains(model))
                                                                viewActivated = true;
                                                        };
            region.Add(model);
            Assert.IsFalse(viewActivated);

            region.Activate(model);

            Assert.IsTrue(viewActivated);
        }

        [TestMethod]
        public void AddingSameViewTwiceThrows()
        {
            object view = new object();
            IRegion region = new Region();
            region.Add(view);

            try
            {
                region.Add(view);
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("View already exists in region.", ex.Message);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemovingViewAlsoRemovesItFromActiveViews()
        {
            IRegion region = new Region();
            object model = new object();
            region.Add(model);
            region.Activate(model);
            Assert.IsTrue(region.ActiveViews.Contains(model));

            region.Remove(model);

            Assert.IsFalse(region.ActiveViews.Contains(model));
        }

        [TestMethod]
        public void ShouldGetNotificationWhenContextChanges()
        {
            IRegion region = new Region();
            bool contextChanged = false;
            region.PropertyChanged += (s, args) => { if (args.PropertyName == "Context") contextChanged = true; };

            region.Context = "MyNewContext";

            Assert.IsTrue(contextChanged);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangingNameOnceItIsSetThrows()
        {
            var region = new Region();
            region.Name = "MyRegion";

            region.Name = "ChangedRegionName";
        }

        private class MockRegionManager : IRegionManager
        {
            public bool CreateRegionManagerCalled;

            public IRegionManager CreateRegionManager()
            {
                CreateRegionManagerCalled = true;
                return new MockRegionManager();
            }

            public IRegionCollection Regions
            {
                get { throw new NotImplementedException(); }
            }

            public IRegion AttachNewRegion(object regionTarget, string regionName)
            {
                throw new NotImplementedException();
            }
        }
    }
}
