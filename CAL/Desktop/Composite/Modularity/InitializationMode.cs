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
    /// Specifies on which stage the Module group will be initialized.
    /// </summary>
    public enum InitializationMode
    {
        /// <summary>
        /// The module will be initialized when it is available on application start-up.
        /// </summary>
        WhenAvailable,

        /// <summary>
        /// The module will be initialized when requested, and not automatically on application start-up.
        /// </summary>
        OnDemand
    }
}
