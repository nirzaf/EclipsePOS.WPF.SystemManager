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
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class ViewsCollectionFixture
    {
        [TestMethod]
        public void CanWrapCollectionCollection()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => true);

            Assert.AreEqual(0, viewsCollection.Count());

            var item = new object();
            originalCollection.Add(new ItemMetadata(item));
            Assert.AreEqual(1, viewsCollection.Count());
            Assert.AreSame(item, viewsCollection.First());
        }

        [TestMethod]
        public void CanFilterCollection()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => x.Name == "Posible");

            originalCollection.Add(new ItemMetadata(new object()));

            Assert.AreEqual(0, viewsCollection.Count());

            var item = new object();
            originalCollection.Add(new ItemMetadata(item) { Name = "Posible" });
            Assert.AreEqual(1, viewsCollection.Count());

            Assert.AreSame(item, viewsCollection.First());
        }

        [TestMethod]
        public void RaisesCollectionChangedWhenFilteredCollectionChanges()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => x.IsActive);
            bool collectionChanged = false;
            viewsCollection.CollectionChanged += (s, e) => collectionChanged = true;

            originalCollection.Add(new ItemMetadata(new object()) { IsActive = true });

            Assert.IsTrue(collectionChanged);
        }

        [TestMethod]
        public void RaisesCollectionChangedWithAddAndRemoveWhenFilteredCollectionChanges()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => x.IsActive);
            bool addedToCollection = false;
            bool removedFromCollection = false;
            viewsCollection.CollectionChanged += (s, e) =>
                                                     {
                                                         if (e.Action == NotifyCollectionChangedAction.Add)
                                                         {
                                                             addedToCollection = true;
                                                         }
                                                         else if (e.Action == NotifyCollectionChangedAction.Remove)
                                                         {
                                                             removedFromCollection = true;
                                                         }
                                                     };
            var filteredInObject = new ItemMetadata(new object()) { IsActive = true };

            originalCollection.Add(filteredInObject);

            Assert.IsTrue(addedToCollection);
            Assert.IsFalse(removedFromCollection);

            originalCollection.Remove(filteredInObject);

            Assert.IsTrue(removedFromCollection);
        }

        [TestMethod]
        public void DoesNotRaiseCollectionChangedWhenAddingOrRemovingFilteredOutObject()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => x.IsActive);
            bool collectionChanged = false;
            viewsCollection.CollectionChanged += (s, e) => collectionChanged = true;
            var filteredOutObject = new ItemMetadata(new object()) { IsActive = false };

            originalCollection.Add(filteredOutObject);
            originalCollection.Remove(filteredOutObject);

            Assert.IsFalse(collectionChanged);
        }

        [TestMethod]
        public void CollectionChangedPassesWrappedItemInArgumentsWhenAdding()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            var filteredInObject = new ItemMetadata(new object());
            originalCollection.Add(filteredInObject);

            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => true);
            IList oldItemsPassed = null;
            viewsCollection.CollectionChanged += (s, e) =>
                                                     {
                                                         oldItemsPassed = e.OldItems;
                                                     };
            originalCollection.Remove(filteredInObject);

            Assert.IsNotNull(oldItemsPassed);
            Assert.AreEqual(1, oldItemsPassed.Count);
            Assert.AreSame(filteredInObject.Item, oldItemsPassed[0]);
        }

        [TestMethod]
        public void CollectionChangedPassesWrappedItemInArgumentsWhenRemoving()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => true);
            IList newItemsPassed = null;
            viewsCollection.CollectionChanged += (s, e) =>
            {
                newItemsPassed = e.NewItems;
            };
            var filteredInObject = new ItemMetadata(new object());

            originalCollection.Add(filteredInObject);

            Assert.IsNotNull(newItemsPassed);
            Assert.AreEqual(1, newItemsPassed.Count);
            Assert.AreSame(filteredInObject.Item, newItemsPassed[0]);
        }

        [TestMethod]
        public void EnumeratesWrappedItems()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>()
                                         {
                                             new ItemMetadata(new object()),
                                             new ItemMetadata(new object())
                                         };
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => true);
            Assert.AreEqual(2, viewsCollection.Count());

            Assert.AreSame(originalCollection[0].Item, viewsCollection.ElementAt(0));
            Assert.AreSame(originalCollection[1].Item, viewsCollection.ElementAt(1));
        }

        [TestMethod]
        public void ChangingMetadataOnItemAddsOrRemovesItFromTheFilteredCollection()
        {
            var originalCollection = new ObservableCollection<ItemMetadata>();
            IViewsCollection viewsCollection = new ViewsCollection(originalCollection, x => x.IsActive);
            bool addedToCollection = false;
            bool removedFromCollection = false;
            viewsCollection.CollectionChanged += (s, e) =>
                                                     {
                                                         if (e.Action == NotifyCollectionChangedAction.Add)
                                                         {
                                                             addedToCollection = true;
                                                         }
                                                         else if (e.Action == NotifyCollectionChangedAction.Remove)
                                                         {
                                                             removedFromCollection = true;
                                                         }
                                                     };

            originalCollection.Add(new ItemMetadata(new object()) { IsActive = true });
            Assert.IsFalse(removedFromCollection);

            originalCollection[0].IsActive = false;

            Assert.AreEqual(0, viewsCollection.Count());
            Assert.IsTrue(removedFromCollection);
            Assert.IsTrue(addedToCollection);
            Assert.AreEqual(0, viewsCollection.Count());

            addedToCollection = false;
            removedFromCollection = false;

            originalCollection[0].IsActive = true;

            Assert.AreEqual(1, viewsCollection.Count());
            Assert.IsTrue(addedToCollection);
            Assert.IsFalse(removedFromCollection);
        }
    }
}