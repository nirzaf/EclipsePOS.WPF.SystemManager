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
using System.Collections.Generic;
using Microsoft.Practices.Composite.Regions;

namespace Microsoft.Practices.Composite.Tests.Mocks
{
    internal class MockRegionManager : IRegionManager
    {
        private IRegionCollection regions = new MockRegionCollection();
        internal MockRegionCollection MockRegionCollection
        {
            get
            {
                return regions as MockRegionCollection;
            }
        }

        public IRegionCollection Regions
        {
            get { return regions; }
        }

        public IRegionManager CreateRegionManager()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class MockRegionCollection : List<IRegion>, IRegionCollection
    {
        IEnumerator<IRegion> IEnumerable<IRegion>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IRegion this[string regionName]
        {
            get { return this[0]; }
        }

        void IRegionCollection.Add(IRegion region)
        {
            this.Add(region);
        }

        public bool Remove(string regionName)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsRegionWithName(string regionName)
        {
            return true;
        }
    }
}
