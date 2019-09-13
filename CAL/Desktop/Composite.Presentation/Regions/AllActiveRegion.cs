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
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Properties;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    /// <summary>
    /// Region that keeps all the views in it as active. Deactivation of views is not allowed.
    /// </summary>
    public class AllActiveRegion : Region
    {
        /// <summary>
        /// Gets a readonly view of the collection of all the active views in the region. These are all the added views.
        /// </summary>
        /// <value>An <see cref="IViewsCollection"/> of all the active views.</value>
        public override IViewsCollection ActiveViews
        {
            get { return Views; }
        }

        /// <summary>
        /// Deactive is not valid in this Region. This method will always throw <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="view">The view to deactivate.</param>
        /// <exception cref="InvalidOperationException">Every time this method is called.</exception>
        public override void Deactivate(object view)
        {
            throw new InvalidOperationException(Resources.DeactiveNotPossibleException);
        }
    }
}