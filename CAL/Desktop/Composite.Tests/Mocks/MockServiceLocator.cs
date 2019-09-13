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
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.Composite.Presentation.Tests.Mocks
{
    internal class MockServiceLocator : IServiceLocator
    {
        public Func<Type, object> GetInstance;
        public Func<Type, object> GetService;

        object IServiceLocator.GetInstance(Type serviceType)
        {
            if (this.GetInstance != null)
                return this.GetInstance(serviceType);

            return null;
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            if (this.GetService != null)
                return this.GetService(serviceType);

            return null;
        }

        System.Collections.Generic.IEnumerable<TService> IServiceLocator.GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IEnumerable<object> IServiceLocator.GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        TService IServiceLocator.GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        TService IServiceLocator.GetInstance<TService>()
        {
            throw new NotImplementedException();
        }

        object IServiceLocator.GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }
    }
}