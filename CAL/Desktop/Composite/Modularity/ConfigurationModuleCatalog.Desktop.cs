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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Practices.Composite.Properties;

namespace Microsoft.Practices.Composite.Modularity
{

    /// <summary>
    /// A catalog built from a configuration file.
    /// </summary>
    public class ConfigurationModuleCatalog : ModuleCatalog
    {
        /// <summary>
        /// Builds an instance of ConfigurationModuleCatalog with a <see cref="ConfigurationStore"/> as the default store.
        /// </summary>
        public ConfigurationModuleCatalog()
        {
            this.Store = new ConfigurationStore();
        }

        /// <summary>
        /// Gets or sets the store where the configuration is kept.
        /// </summary>
        public IConfigurationStore Store { get; set; }

        /// <summary>
        /// Loads the catalog from the configuration.
        /// </summary>
        protected override void InnerLoad()
        {
            if (this.Store == null)
            {
                throw new InvalidOperationException(Resources.ConfigurationStoreCannotBeNull);
            }

            this.EnsureModulesDiscovered();
        }

        private static string GetFileAbsoluteUri(string filePath)
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Host = String.Empty;
            uriBuilder.Scheme = Uri.UriSchemeFile;
            uriBuilder.Path = Path.GetFullPath(filePath);
            Uri fileUri = uriBuilder.Uri;

            return fileUri.ToString();
        }

        private void EnsureModulesDiscovered()
        {
            ModulesConfigurationSection section = this.Store.RetrieveModuleConfigurationSection();

            if (section != null)
            {
                foreach (ModuleConfigurationElement element in section.Modules)
                {
                    IList<string> dependencies = new List<string>();

                    if (element.Dependencies.Count > 0)
                    {
                        foreach (ModuleDependencyConfigurationElement dependency in element.Dependencies)
                        {
                            dependencies.Add(dependency.ModuleName);
                        }
                    }

                    ModuleInfo moduleInfo = new ModuleInfo(element.ModuleName, element.ModuleType)
                    {
                        Ref = GetFileAbsoluteUri(element.AssemblyFile),
                        InitializationMode = element.StartupLoaded ? InitializationMode.WhenAvailable : InitializationMode.OnDemand
                    };
                    moduleInfo.DependsOn.AddRange(dependencies.ToArray());
                    AddModule(moduleInfo);
                }
            }
        }
    }
}
