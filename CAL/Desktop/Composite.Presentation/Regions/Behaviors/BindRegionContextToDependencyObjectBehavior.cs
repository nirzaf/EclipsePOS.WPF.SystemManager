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
using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Composite.Regions;

namespace Microsoft.Practices.Composite.Presentation.Regions.Behaviors
{
    /// <summary>
    /// Defines a behavior that forwards the <see cref="RegionManager.RegionContextProperty"/> 
    /// to the views in the region.
    /// </summary>
    public class BindRegionContextToDependencyObjectBehavior : IRegionBehavior
    {
        /// <summary>
        /// The key of this behavior.
        /// </summary>
        public const string BehaviorKey = "ContextToDependencyObject";

        /// <summary>
        /// Behavior's attached region.
        /// </summary>
        public IRegion Region { get; set; }

        /// <summary>
        /// Attaches the behavior to the specified region.
        /// </summary>
        public void Attach()
        {
            this.Region.Views.CollectionChanged += this.Views_CollectionChanged;
            this.Region.PropertyChanged += this.Region_PropertyChanged;
            SetContextToViews(this.Region.Views, this.Region.Context);
            this.AttachNotifyChangeEvent(this.Region.Views);
        }

        private static void SetContextToViews(IEnumerable views, object context)
        {
            foreach (var view in views)
            {
                DependencyObject dependencyObjectView = view as DependencyObject;
                if (dependencyObjectView != null)
                {
                    ObservableObject<object> contextWrapper = RegionContext.GetObservableContext(dependencyObjectView);
                    contextWrapper.Value = context;
                }
            }
        }

        private void AttachNotifyChangeEvent(IEnumerable views)
        {
            foreach (var view in views)
            {
                var dependencyObject = view as DependencyObject;
                if (dependencyObject != null)
                {
                    ObservableObject<object> viewRegionContext = RegionContext.GetObservableContext(dependencyObject);
                    viewRegionContext.PropertyChanged += this.ViewRegionContext_OnPropertyChangedEvent;
                }
            }
        }

        private void DetachNotifyChangeEvent(IEnumerable views)
        {
            foreach (var view in views)
            {
                var dependencyObject = view as DependencyObject;
                if (dependencyObject != null)
                {
                    ObservableObject<object> viewRegionContext = RegionContext.GetObservableContext(dependencyObject);
                    viewRegionContext.PropertyChanged -= this.ViewRegionContext_OnPropertyChangedEvent;
                }
            }
        }

        private void ViewRegionContext_OnPropertyChangedEvent(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Value")
            {
                var context = (ObservableObject<object>) sender;
                this.Region.Context = context.Value;
            }
        }

        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                SetContextToViews(e.NewItems, this.Region.Context);
                this.AttachNotifyChangeEvent(e.NewItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove && this.Region.Context != null)
            {
                SetContextToViews(e.OldItems, null);
                this.DetachNotifyChangeEvent(e.OldItems);
            }
        }

        private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Context")
            {
                SetContextToViews(this.Region.Views, this.Region.Context);
            }
        }
    }
}