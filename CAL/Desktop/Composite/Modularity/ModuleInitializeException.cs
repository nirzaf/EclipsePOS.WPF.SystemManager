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
using System.Globalization;
using Microsoft.Practices.Composite.Properties;

namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// Exception thrown by <see cref="IModuleInitializer"/> implementations whenever 
    /// a module fails to load.
    /// </summary>
    public partial class ModuleInitializeException : ModularityException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ModuleInitializeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleInitializeException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ModuleInitializeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleInitializeException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ModuleInitializeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes the exception with a particular module and error message.
        /// </summary>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="moduleAssembly">The assembly where the module is located.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ModuleInitializeException(string moduleName, string moduleAssembly, string message)
            : this(moduleName, message, moduleAssembly, null)
        {
        }

        /// <summary>
        /// Initializes the exception with a particular module, error message and inner exception 
        /// that happened.
        /// </summary>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="moduleAssembly">The assembly where the module is located.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, 
        /// or a <see langword="null"/> reference if no inner exception is specified.</param>
        public ModuleInitializeException(string moduleName, string moduleAssembly, string message, Exception innerException)
            : base(
                moduleName,
                String.Format(CultureInfo.CurrentCulture, Resources.FailedToLoadModule, moduleName, moduleAssembly, message),
                innerException)
        {
        }

        /// <summary>
        /// Initializes the exception with a particular module, error message and inner exception that happened.
        /// </summary>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, 
        /// or a <see langword="null"/> reference if no inner exception is specified.</param>
        public ModuleInitializeException(string moduleName, string message, Exception innerException)
            : base(
                moduleName,
                String.Format(CultureInfo.CurrentCulture, Resources.FailedToLoadModuleNoAssemblyInfo, moduleName, message),
                innerException)
        {
        }
    }
}