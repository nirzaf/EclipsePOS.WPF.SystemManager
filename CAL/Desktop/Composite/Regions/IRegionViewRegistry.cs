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
using System.Collections.Generic;

namespace Microsoft.Practices.Composite.Regions
{
    /// <summary>
    /// Defines the interface for the registry of region's content.
    /// </summary>
    public interface IRegionViewRegistry
    {
        /// <summary>
        /// Event triggered when a content is registered to a region name.
        /// </summary>
        /// <remarks>
        /// This event uses weak references to the event handler to prevent this service (typically a singleton) of keeping the
        /// target element longer than expected. For security reasons, to use weak delegates in Silverlight you must provide
        /// a delegate that is available in the public API of the class (no private or anonymous delegates allowed).
        /// </remarks>
        event EventHandler<ViewRegisteredEventArgs> ContentRegistered;

        /// <summary>
        /// Returns the contents associated with a region name.
        /// </summary>
        /// <param name="regionName">Region name for which contents are requested.</param>
        /// <returns>Collection of contents associated with the <paramref name="regionName"/>.</returns>
        IEnumerable<object> GetContents(string regionName);

        /// <summary>
        /// Registers a content type with a region name.
        /// </summary>
        /// <param name="regionName">Region name to which the <paramref name="viewType"/> will be registered.</param>
        /// <param name="viewType">Content type to be registered for the <paramref name="regionName"/>.</param>
        void RegisterViewWithRegion(string regionName, Type viewType);

        /// <summary>
        /// Registers a delegate that can be used to retrieve the content associated with a region name. 
        /// </summary>
        /// <param name="regionName">Region name to which the <paramref name="getContentDelegate"/> will be registered.</param>
        /// <param name="getContentDelegate">Delegate used to retrieve the content associated with the <paramref name="regionName"/>.</param>
        void RegisterViewWithRegion(string regionName, Func<object> getContentDelegate);
    }
}
