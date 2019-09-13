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

namespace Microsoft.Practices.Composite.Regions
{
    /// <summary>
    /// Argument class used by the <see cref="IRegionViewRegistry.ContentRegistered"/> event when a new content is registered.
    /// </summary>
    public class ViewRegisteredEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes the ViewRegisteredEventArgs class.
        /// </summary>
        /// <param name="regionName">The region name to which the content was registered.</param>
        /// <param name="getViewDelegate">The content which was registered.</param>
        public ViewRegisteredEventArgs(string regionName, Func<object> getViewDelegate)
        {
            this.GetView = getViewDelegate;
            this.RegionName = regionName;
        }

        /// <summary>
        /// Gets the region name to which the content was registered.
        /// </summary>
        public string RegionName { get; private set; }

        /// <summary>
        /// Gets the content which was registered.
        /// </summary>
        public Func<object> GetView { get; private set; }
    }
}
