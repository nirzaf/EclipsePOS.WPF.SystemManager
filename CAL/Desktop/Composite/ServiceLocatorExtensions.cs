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

namespace Microsoft.Practices.Composite
{
    /// <summary>
    /// Defines extension methods for the <see cref="ServiceLocator"/> class.
    /// </summary>
    public static class ServiceLocatorExtensions
    {
        /// <summary>
        /// Attempts to resolve specified type from the underlying <see cref="IServiceLocator"/>.
        /// </summary>
        /// <remarks>
        /// This will return null on any <see cref="ActivationException"/>.</remarks>
        /// <param name="locator">Locator to use in resolving.</param>
        /// <param name="type">Type to resolve.</param>
        /// <returns>T or null</returns>
        public static object TryResolve(this IServiceLocator locator, Type type)
        {
            try
            {
                return locator.GetInstance(type);
            }
            catch (ActivationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to resolve specified type from the underlying <see cref="IServiceLocator"/>.
        /// </summary>
        /// <remarks>
        /// This will return null on any <see cref="ActivationException"/>.</remarks>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <param name="locator">Locator to use in resolving.</param>
        /// <returns>T or null</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T TryResolve<T>(this IServiceLocator locator) where T: class
        {
            return locator.TryResolve(typeof(T)) as T;
        }
    }
}
