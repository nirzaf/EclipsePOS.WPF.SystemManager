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
    /// Loads modules from an arbitrary location on the filesystem. This typeloader is only called if 
    /// <see cref="ModuleInfo"/> classes have a Ref parameter that starts with "file://". 
    /// This class is only used on the Desktop version of the Composite Application Library.
    /// </summary>
    public class FileModuleTypeLoader : IModuleTypeLoader
    {
        private readonly IAssemblyResolver assemblyResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileModuleTypeLoader"/> class.
        /// </summary>
        public FileModuleTypeLoader()
            : this(new AssemblyResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileModuleTypeLoader"/> class.
        /// </summary>
        /// <param name="assemblyResolver">The assembly resolver.</param>
        public FileModuleTypeLoader(IAssemblyResolver assemblyResolver)
        {
            this.assemblyResolver = assemblyResolver;
        }

        /// <summary>
        /// Evaluates the <see cref="ModuleInfo.Ref"/> property to see if the current typeloader will be able to retrieve the <paramref name="moduleInfo"/>.
        /// Returns true if the <see cref="ModuleInfo.Ref"/> property starts with "file://", because this indicates that the file
        /// is a local file. 
        /// </summary>
        /// <param name="moduleInfo">Module that should have it's type loaded.</param>
        /// <returns>
        /// 	<see langword="true"/> if the current typeloader is able to retrieve the module, otherwise <see langword="false"/>.
        /// </returns>
        public bool CanLoadModuleType(ModuleInfo moduleInfo)
        {
            return moduleInfo.Ref != null && moduleInfo.Ref.StartsWith("file://", StringComparison.Ordinal);
        }

        /// <summary>
        /// Starts retrieving the <paramref name="moduleInfo"/> and calls the <paramref name="callback"/> when it is done.
        /// </summary>
        /// <param name="moduleInfo">Module that should have it's type loaded.</param>
        /// <param name="callback">Delegate to be called when typeloading process completes or fails.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public void BeginLoadModuleType(ModuleInfo moduleInfo, ModuleTypeLoadedCallback callback)
        {
            Exception error = null;
            try
            {
                this.assemblyResolver.LoadAssemblyFrom(moduleInfo.Ref);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            callback(moduleInfo, error);
        }
    }
}
