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
namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// Defines the states a <see cref="ModuleInfo"/> can be in, with regards to the module loading and initialization process. 
    /// </summary>
    public enum ModuleState
    {
        /// <summary>
        /// Initial state for <see cref="ModuleInfo"/>s. The <see cref="ModuleInfo"/> is defined, 
        /// but it has not been loaded, retrieved or initialized yet. 
        /// </summary>
        NotStarted,

        /// <summary>
        /// The assembly that contains the type of the module is currently being loaded by an instance of a
        /// <see cref="IModuleTypeLoader"/>. 
        /// </summary>
        LoadingTypes,

        /// <summary>
        /// The assembly that holds the Module is present. This means the type of the <see cref="IModule"/> can be instantiated and initialized. 
        /// </summary>
        ReadyForInitialization,

        /// <summary>
        /// The module is currently Initializing, by the <see cref="IModuleInitializer"/>
        /// </summary>
        Initializing,

        /// <summary>
        /// The module is initialized and ready to be used. 
        /// </summary>
        Initialized
    }
}
