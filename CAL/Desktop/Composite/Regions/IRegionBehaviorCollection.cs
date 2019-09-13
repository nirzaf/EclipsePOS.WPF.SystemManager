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
using System.Collections.Generic;

namespace Microsoft.Practices.Composite.Regions
{
    /// <summary>
    /// Defines the interface for a collection of <see cref="IRegionBehavior"/> classes on a Region.
    /// </summary>
    public interface IRegionBehaviorCollection : IEnumerable<KeyValuePair<string, IRegionBehavior>>
    {

        /// <summary>
        /// Adds a <see cref="IRegionBehavior"/> to the collection, using the specified key as an indexer. 
        /// </summary>
        /// <param name="key">
        /// The key that specifies the type of <see cref="IRegionBehavior"/> that's added. 
        /// </param>
        /// <param name="regionBehavior">The <see cref="IRegionBehavior"/> to add.</param>
        void Add(string key, IRegionBehavior regionBehavior);

        /// <summary>
        /// Checks if a <see cref="IRegionBehavior"/> with the specified key is already present. 
        /// </summary>
        /// <param name="key">The key to use to find a particular <see cref="IRegionBehavior"/>.</param>
        /// <returns></returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Gets the <see cref="IRegionBehavior"/> with the specified key.
        /// </summary>
        /// <value>The registered <see cref="IRegionBehavior"/></value>
        IRegionBehavior this[string key]{ get;}
    }
}
