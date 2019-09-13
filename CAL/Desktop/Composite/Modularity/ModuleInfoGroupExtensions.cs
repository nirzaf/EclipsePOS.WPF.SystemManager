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
    /// Defines extension methods for the <see cref="ModuleInfoGroup"/> class.
    /// </summary>
    public static class ModuleInfoGroupExtensions
    {
        /// <summary>
        /// Adds a new module that is statically referenced to the specified module info group.
        /// </summary>
        /// <param name="moduleInfoGroup">The group where to add the module info in.</param>
        /// <param name="moduleName">The name for the module.</param>
        /// <param name="moduleType">The type for the module. This type should be a descendant of <see cref="IModule"/>.</param>
        /// <param name="dependsOn">The names for the modules that this module depends on.</param>
        /// <returns>Returns the instance of the passed in module info group, to provide a fluid interface.</returns>
        public static ModuleInfoGroup AddModule(
                    this ModuleInfoGroup moduleInfoGroup,
                    string moduleName,
                    Type moduleType,
                    params string[] dependsOn)
        {
            if (moduleType == null)
            {
                throw new ArgumentNullException("moduleType");
            }

            ModuleInfo moduleInfo = new ModuleInfo(moduleName, moduleType.AssemblyQualifiedName);
            moduleInfo.DependsOn.AddRange(dependsOn);
            moduleInfoGroup.Add(moduleInfo);
            return moduleInfoGroup;
        }

        /// <summary>
        /// Adds a new module that is statically referenced to the specified module info group.
        /// </summary>
        /// <param name="moduleInfoGroup">The group where to add the module info in.</param>
        /// <param name="moduleType">The type for the module. This type should be a descendant of <see cref="IModule"/>.</param>
        /// <param name="dependsOn">The names for the modules that this module depends on.</param>
        /// <returns>Returns the instance of the passed in module info group, to provide a fluid interface.</returns>
        /// <remarks>The name of the module will be the type name.</remarks>
        public static ModuleInfoGroup AddModule(
                    this ModuleInfoGroup moduleInfoGroup,
                    Type moduleType,
                    params string[] dependsOn)
        {
            return AddModule(moduleInfoGroup, moduleType.Name, moduleType, dependsOn);
        }
    }
}
