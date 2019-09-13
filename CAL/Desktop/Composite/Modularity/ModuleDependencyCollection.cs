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
using System.Configuration;

namespace Microsoft.Practices.Composite.Modularity
{
    /// <summary>
    /// A collection of <see cref="ModuleDependencyConfigurationElement"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface")]
    public class ModuleDependencyCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ModuleDependencyCollection"/>.
        /// </summary>
        public ModuleDependencyCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ModuleDependencyCollection"/>.
        /// </summary>
        /// <param name="dependencies">An array of <see cref="ModuleDependencyConfigurationElement"/> with initial list of dependencies.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModuleDependencyCollection(ModuleDependencyConfigurationElement[] dependencies)
        {
            if (dependencies == null)
                throw new ArgumentNullException("dependencies");

            foreach (ModuleDependencyConfigurationElement dependency in dependencies)
            {
                BaseAdd(dependency);
            }
        }

        ///<summary>
        ///Gets the type of the <see cref="T:System.Configuration.ConfigurationElementCollection" />.
        ///</summary>
        ///<value>
        ///The <see cref="T:System.Configuration.ConfigurationElementCollectionType" /> of this collection.
        ///</value>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        ///<summary>
        ///Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.
        ///</summary>
        ///<value>
        ///The name of the collection; otherwise, an empty string.
        ///</value>
        protected override string ElementName
        {
            get { return "dependency"; }
        }

        /// <summary>
        /// Gets the <see cref="ModuleDependencyConfigurationElement"/> located at the specified index in the collection.
        /// </summary>
        /// <param name="index">The index of the element in the collection.</param>
        /// <returns>A <see cref="ModuleDependencyConfigurationElement"/>.</returns>
        public ModuleDependencyConfigurationElement this[int index]
        {
            get { return (ModuleDependencyConfigurationElement)base.BaseGet(index); }
        }

        /// <summary>
        /// Creates a new <see cref="ModuleDependencyConfigurationElement"/>.
        /// </summary>
        /// <returns>A <see cref="ModuleDependencyConfigurationElement"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleDependencyConfigurationElement();
        }

        ///<summary>
        ///Gets the element key for a specified configuration element when overridden in a derived class.
        ///</summary>
        ///<param name="element">The <see cref="T:System.Configuration.ConfigurationElement" /> to return the key for. </param>
        ///<returns>
        ///An <see cref="T:System.Object" /> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement" />.
        ///</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModuleDependencyConfigurationElement)element).ModuleName;
        }
    }
}