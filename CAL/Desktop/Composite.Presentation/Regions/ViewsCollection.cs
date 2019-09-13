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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Practices.Composite.Regions;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    /// <summary>
    /// Implementation of <see cref="IViewsCollection"/> that takes an <see cref="ObservableCollection{T}"/> of <see cref="ItemMetadata"/>
    /// and filters it to display an <see cref="INotifyCollectionChanged"/> collection of
    /// <see cref="object"/> elements (the items which the <see cref="ItemMetadata"/> wraps).
    /// </summary>
    public partial class ViewsCollection : IViewsCollection
    {
        private readonly ObservableCollection<ItemMetadata> subjectCollection;
        private readonly Predicate<ItemMetadata> filter;

        private readonly List<object> filteredCollection = new List<object>();

        /// <summary>
        /// Initializes a new instance of <see cref="ViewsCollection"/>.
        /// </summary>
        /// <param name="list">The list to wrap and filter.</param>
        /// <param name="filter">A predicate to filter the <paramref name="list"/> collection.</param>
        public ViewsCollection(ObservableCollection<ItemMetadata> list, Predicate<ItemMetadata> filter)
        {
            this.subjectCollection = list;
            this.filter = filter;
            Initialize();
            subjectCollection.CollectionChanged += UnderlyingCollection_CollectionChanged;
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="value">The object to locate in the collection.</param>
        /// <returns><see langword="true" /> if <paramref name="value"/> is found in the collection; otherwise, <see langword="false" />.</returns>
        public bool Contains(object value)
        {
            return filteredCollection.Contains(value);
        }

        ///<summary>
        ///Returns an enumerator that iterates through the collection.
        ///</summary>
        ///<returns>
        ///A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        ///</returns>
        public IEnumerator<object> GetEnumerator()
        {
            return filteredCollection.GetEnumerator();
        }

        ///<summary>
        ///Returns an enumerator that iterates through a collection.
        ///</summary>
        ///<returns>
        ///An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        ///</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void AddAndNotify(object item)
        {
            AddAndNotify(new List<object>(1) { item });
        }

        private void RemoveAndNotify(object item)
        {
            RemoveAndNotify(new List<object>(1) { item });
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler Handler = CollectionChanged;
            if (Handler != null) Handler(this, e);
        }

        private void Reset()
        {
            foreach (ItemMetadata itemMetadata in subjectCollection)
            {
                itemMetadata.MetadataChanged -= itemMetadata_MetadataChanged;
            }
            filteredCollection.Clear();
            Initialize();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void Initialize()
        {
            foreach (ItemMetadata itemMetadata in subjectCollection)
            {
                itemMetadata.MetadataChanged += itemMetadata_MetadataChanged;
                if (filter(itemMetadata))
                {
                    filteredCollection.Add(itemMetadata.Item);
                }
            }
        }

        void UnderlyingCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            List<object> changedItems = new List<object>();
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (ItemMetadata itemMetadata in e.NewItems)
                    {
                        itemMetadata.MetadataChanged += itemMetadata_MetadataChanged;
                        if (filter(itemMetadata))
                        {
                            changedItems.Add(itemMetadata.Item);
                        }
                    }
                    AddAndNotify(changedItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (ItemMetadata itemMetadata in e.OldItems)
                    {
                        itemMetadata.MetadataChanged -= itemMetadata_MetadataChanged;
                        if (filteredCollection.Contains(itemMetadata.Item))
                        {
                            changedItems.Add(itemMetadata.Item);
                        }
                    }
                    RemoveAndNotify(changedItems);
                    break;
                default:
                    Reset();
                    break;
            }
        }

        void itemMetadata_MetadataChanged(object sender, EventArgs e)
        {
            ItemMetadata itemMetadata = (ItemMetadata)sender;
            if (filteredCollection.Contains(itemMetadata.Item))
            {
                if (filter(itemMetadata) == false)
                {
                    RemoveAndNotify(itemMetadata.Item);
                }
            }
            else
            {
                if (filter(itemMetadata) == true)
                {
                    AddAndNotify(itemMetadata.Item);
                }
            }
        }
    }
}