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
using System.Collections.Specialized;
using System.Linq;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    public partial class ViewsCollection
    {
        private void AddAndNotify(IList items)
        {
            if (items.Count > 0)
            {
                filteredCollection.AddRange(items.Cast<object>());
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items));
            }
        }

        private void RemoveAndNotify(IList items)
        {
            if (items.Count > 0)
            {
                int index = -1;
                if (items.Count == 1)
                {
                    index = filteredCollection.IndexOf(items[0]);
                }
                foreach (object item in items)
                {
                    filteredCollection.Remove(item);
                }
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items, index));
            }
        }
    }
}
