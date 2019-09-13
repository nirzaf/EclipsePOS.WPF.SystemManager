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
using Microsoft.Practices.Composite.Modularity;

namespace Microsoft.Practices.Composite.Tests.Mocks
{
    public class MockModuleTypeLoader : IModuleTypeLoader
    {
        private readonly Dictionary<ModuleInfo, ModuleTypeLoadedCallback> callbacks = new Dictionary<ModuleInfo, ModuleTypeLoadedCallback>();
        public List<ModuleInfo> beginLoadModuleTypeCalls = new List<ModuleInfo>();
        public bool canLoadModuleTypeReturnValue = true;

        public void BeginLoadModuleType(ModuleInfo moduleInfo, ModuleTypeLoadedCallback callback)
        {
            beginLoadModuleTypeCalls.Add(moduleInfo);
            this.callbacks[moduleInfo] = callback;
        }

        public void RaiseCallbackForModule(ModuleInfo moduleInfo)
        {
            this.callbacks[moduleInfo](moduleInfo, null);
        }

        public void RaiseCallbackForModule(ModuleInfo moduleInfo, Exception error)
        {
            this.callbacks[moduleInfo](moduleInfo, error);
        }

        public bool CanLoadModuleType(ModuleInfo moduleInfo)
        {
            return canLoadModuleTypeReturnValue;
        }
    }
}
