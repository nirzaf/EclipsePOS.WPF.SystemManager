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
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.Composite.Tests.Mocks
{
    internal class MockContainerAdapter : ServiceLocatorImplBase
    {
        public Dictionary<Type, object> ResolvedInstances = new Dictionary<Type, object>();

        protected override object DoGetInstance(Type serviceType, string key)
        {
            object resolvedInstance;
            if (!this.ResolvedInstances.ContainsKey(serviceType))
            {
                resolvedInstance = Activator.CreateInstance(serviceType);
                this.ResolvedInstances.Add(serviceType, resolvedInstance);
            }
            else
            {
                resolvedInstance = this.ResolvedInstances[serviceType];
            }

            return resolvedInstance;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new System.NotImplementedException();
        }
    }
}