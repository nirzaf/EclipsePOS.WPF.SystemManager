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
    /// Exception thrown when a module is declared twice in the same catalog.
    /// </summary>
    public partial class DuplicateModuleException : ModularityException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateModuleException"/> class.
        /// </summary>
        public DuplicateModuleException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateModuleException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DuplicateModuleException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateModuleException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DuplicateModuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateModuleException" /> class with a specified error message.
        /// </summary>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="message">The message that describes the error.</param>
        public DuplicateModuleException(string moduleName, string message)
            : base(moduleName, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateModuleException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="moduleName">The name of the module.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DuplicateModuleException(string moduleName, string message, Exception innerException)
            : base(moduleName, message, innerException)
        {
        }
    }
}
