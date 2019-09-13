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
    /// Specifies that the current module has a dependency on another module. This attribute should be used on classes that implement <see cref="IModule"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ModuleDependencyAttribute : Attribute
    {
        private readonly string _moduleName;

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleDependencyAttribute"/>.
        /// </summary>
        /// <param name="moduleName">The name of the module that this module is dependant upon.</param>
        public ModuleDependencyAttribute(string moduleName)
        {
            _moduleName = moduleName;
        }

        /// <summary>
        /// Gets the name of the module that this module is dependant upon.
        /// </summary>
        /// <value>The name of the module that this module is dependant upon.</value>
        public string ModuleName
        {
            get { return _moduleName; }
        }
    }
}
