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
using System.Configuration;

namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// A <see cref="ConfigurationSection"/> for module configuration.
    /// </summary>
    public class ModulesConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the collection of modules configuration.
        /// </summary>
        /// <value>A <seealso cref="ModuleConfigurationElementCollection"/> of <seealso cref="ModuleConfigurationElement"/>.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false)]
        public ModuleConfigurationElementCollection Modules
        {
            get { return (ModuleConfigurationElementCollection)base[""]; }
            set { base[""] = value; }
        }
    }
}