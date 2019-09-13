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
using System.Threading;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Modularity
{
    [TestClass]
    public class FileModuleRetrieverFixture
    {
        [TestMethod]
        public void CanRetrieveModule()
        {
            var assemblyResolver = new MockAssemblyResolver();
            var retriever = new FileModuleTypeLoader(assemblyResolver);
            string assembly = CompilerHelper.GenerateDynamicModule("FileModuleA", null);
            var fileModuleInfo = CreateModuleInfo(assembly, "TestModules.FileModuleAClass", "ModuleA", true, null);

            ManualResetEvent callbackEvent = new ManualResetEvent(false);

            retriever.BeginLoadModuleType(fileModuleInfo, delegate
            {
                callbackEvent.Set();
            });

            callbackEvent.WaitOne(500);

            Assert.AreEqual(assembly, assemblyResolver.LoadAssemblyFromArgument);
        }

        [TestMethod]
        public void ShouldReturnErrorToCallback()
        {
            var assemblyResolver = new MockAssemblyResolver();
            var retriever = new FileModuleTypeLoader(assemblyResolver);
            var fileModuleInfo = CreateModuleInfo("NonExistentFile.dll", "NonExistentModule", "NonExistent", true, null);

            ManualResetEvent callbackEvent = new ManualResetEvent(false);

            assemblyResolver.ThrowOnLoadAssemblyFrom = true;
            Exception resultException = null;
            retriever.BeginLoadModuleType(fileModuleInfo, delegate(ModuleInfo moduleInfo, Exception error)
                                                        {
                                                            resultException = error;
                                                            callbackEvent.Set();
                                                        });

            callbackEvent.WaitOne(500);

            Assert.IsNotNull(resultException);
        }

        [TestMethod]
        public void CanRetrieveWithCorrectRef()
        {
            var retriever = new FileModuleTypeLoader();
            var moduleInfo = new ModuleInfo() { Ref = "file://somefile" };

            Assert.IsTrue(retriever.CanLoadModuleType(moduleInfo));
        }

        [TestMethod]
        public void CannotRetrieveWithIncorrectRef()
        {
            var retriever = new FileModuleTypeLoader();
            var moduleInfo = new ModuleInfo() { Ref = "NotForLocalRetrieval" };

            Assert.IsFalse(retriever.CanLoadModuleType(moduleInfo));
        }

        private static ModuleInfo CreateModuleInfo(string assemblyFile, string moduleType, string moduleName, bool startupLoaded, params string[] dependsOn)
        {
            ModuleInfo moduleInfo = new ModuleInfo(moduleName, moduleType)
            {
                InitializationMode = startupLoaded ? InitializationMode.WhenAvailable : InitializationMode.OnDemand,
                Ref = assemblyFile,
            };
            if (dependsOn != null)
            {
                moduleInfo.DependsOn.AddRange(dependsOn);
            }

            return moduleInfo;
        }
    }

    internal class MockAssemblyResolver : IAssemblyResolver
    {
        public string LoadAssemblyFromArgument;
        public bool ThrowOnLoadAssemblyFrom;

        public void LoadAssemblyFrom(string assemblyFilePath)
        {
            LoadAssemblyFromArgument = assemblyFilePath;
            if (ThrowOnLoadAssemblyFrom)
                throw new Exception();
        }
    }
}
