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
using System.Globalization;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Properties;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    /// <summary>
    /// This class maps <see cref="Type"/> with <see cref="IRegionAdapter"/>.
    /// </summary>
    public class RegionAdapterMappings
    {
        private readonly Dictionary<Type, IRegionAdapter> mappings = new Dictionary<Type, IRegionAdapter>();

        /// <summary>
        /// Registers the mapping between a type and an adapter.
        /// </summary>
        /// <param name="controlType">The type of the control.</param>
        /// <param name="adapter">The adapter to use with the <paramref name="controlType"/> type.</param>
        /// <exception cref="ArgumentNullException">When any of <paramref name="controlType"/> or <paramref name="adapter"/> are <see langword="null" />.</exception>
        /// <exception cref="InvalidOperationException">If a mapping for <paramref name="controlType"/> already exists.</exception>
        public void RegisterMapping(Type controlType, IRegionAdapter adapter)
        {
            if (controlType == null)
            {
                throw new ArgumentNullException("controlType");
            }

            if (adapter == null)
            {
                throw new ArgumentNullException("adapter");
            }

            if (mappings.ContainsKey(controlType))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                                                                  Resources.MappingExistsException, controlType.Name));
            }

            mappings.Add(controlType, adapter);
        }

        /// <summary>
        /// Returns the adapter associated with the type provided.
        /// </summary>
        /// <param name="controlType">The type to obtain the <seealso cref="IRegionAdapter"/> mapped.</param>
        /// <returns>The <seealso cref="IRegionAdapter"/> mapped to the <paramref name="controlType"/>.</returns>
        /// <remarks>This class will look for a registered type for <paramref name="controlType"/> and if there is not any,
        /// it will look for a registered type for any of its ancestors in the class hierarchy.
        /// If there is no registered type for <paramref name="controlType"/> or any of its ancestors,
        /// an exception will be thrown.</remarks>
        /// <exception cref="KeyNotFoundException">When there is no registered type for <paramref name="controlType"/> or any of its ancestors.</exception>
        public IRegionAdapter GetMapping(Type controlType)
        {
            Type currentType = controlType;

            while (currentType != null)
            {
                if (mappings.ContainsKey(currentType))
                {
                    return mappings[currentType];
                }
                currentType = currentType.BaseType;
            }
            throw new KeyNotFoundException("controlType");
        }
    }
}