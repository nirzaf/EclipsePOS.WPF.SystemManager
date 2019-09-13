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

namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// Callback to be called when module's type is loaded.
    /// </summary>
    /// <param name="moduleInfo">The retrieved module.</param>
    /// <param name="error">Exception ocurred during module group retrieval or null if no error ocurred.</param>
    public delegate void ModuleTypeLoadedCallback(ModuleInfo moduleInfo, Exception error);

    /// <summary>
    /// Defines the interface for moduleTypeLoaders
    /// </summary>
    public interface IModuleTypeLoader
    {
        /// <summary>
        /// Evaluates the <see cref="ModuleInfo.Ref"/> property to see if the current typeloader will be able to retrieve the <paramref name="moduleInfo"/>.
        /// </summary>
        /// <param name="moduleInfo">Module that should have it's type loaded.</param>
        /// <returns><see langword="true"/> if the current typeloader is able to retrieve the module, otherwise <see langword="false"/>.</returns>
        bool CanLoadModuleType(ModuleInfo moduleInfo);

        /// <summary>
        /// Starts retrieving the <paramref name="moduleInfo"/> and calls the <paramref name="callback"/> when it is done.
        /// </summary>
        /// <param name="moduleInfo">Module that should have it's type loaded.</param>
        /// <param name="callback">Delegate to be called when typeloading process completes or fails.</param>
        void BeginLoadModuleType(ModuleInfo moduleInfo, ModuleTypeLoadedCallback callback);
    }
}
