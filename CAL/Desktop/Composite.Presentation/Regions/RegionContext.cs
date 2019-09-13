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
using System.Windows;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    /// <summary>
    /// Class that holds methods to Set and Get the RegionContext from a DependencyObject. 
    /// 
    /// RegionContext allows sharing of contextual information between the view that's hosting a <see cref="IRegion"/>
    /// and any views that are inside the Region. 
    /// </summary>
    public static class RegionContext
    {
        private static readonly DependencyProperty ObservableRegionContextProperty =
            DependencyProperty.RegisterAttached("ObservableRegionContext", typeof(ObservableObject<object>), typeof(RegionContext), null);

        /// <summary>
        /// Returns an <see cref="ObservableObject{T}"/> wrapper around the RegionContext value. The RegionContext
        /// will be set on any views (dependency objects) that are inside the <see cref="IRegion.Views"/> collection by 
        /// the <see cref="BindRegionContextToDependencyObjectBehavior"/> Behavior.
        /// The RegionContext will also be set to the control that hosts the Region, by the <see cref="SyncRegionContextWithHostBehavior"/> Behavior.
        /// 
        /// If the <see cref="ObservableObject{T}"/> wrapper does not already exist, an empty one will be created. This way, an observer can 
        /// notify when the value is set for the first time. 
        /// </summary>
        /// <param name="view">Any view that hold the RegionContext value. </param>
        /// <returns>Wrapper around the Regioncontext value. </returns>
        public static ObservableObject<object> GetObservableContext(DependencyObject view)
        {
            ObservableObject<object> context = view.GetValue(ObservableRegionContextProperty) as ObservableObject<object>;

            if (context == null)
            {
                context = new ObservableObject<object>();
                view.SetValue(ObservableRegionContextProperty, context);
            }
           
            return context;
        }

    }
}
