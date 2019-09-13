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
using System.IO;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Modularity
{
    [TestClass]
    public class AssemblyResolverFixture
    {
        private const string ModulesDirectory1 = @".\DynamicModules\MocksModulesAssemblyResolve";

        [TestInitialize]
        [TestCleanup]
        public void CleanUpDirectories()
        {
            CompilerHelper.CleanUpDirectory(ModulesDirectory1);
        }

        [TestMethod]
        public void ShouldThrowOnInvalidAssemblyFilePath()
        {
            bool exceptionThrown = false;
            using (var resolver = new AssemblyResolver())
            {
                try
                {
                    resolver.LoadAssemblyFrom(null);
                }
                catch (ArgumentException)
                {
                    exceptionThrown = true;
                }

                Assert.IsTrue(exceptionThrown);


                try
                {
                    resolver.LoadAssemblyFrom("file://InexistentFile.dll");
                    exceptionThrown = false;
                }
                catch (FileNotFoundException)
                {
                    exceptionThrown = true;
                }

                Assert.IsTrue(exceptionThrown);


                try
                {
                    resolver.LoadAssemblyFrom("InvalidUri.dll");
                    exceptionThrown = false;
                }
                catch (ArgumentException)
                {
                    exceptionThrown = true;
                }

                Assert.IsTrue(exceptionThrown);
            }
        }

        [TestMethod]
        public void ShouldResolveTypeFromAbsoluteUriToAssembly()
        {
            string assemblyPath = CompilerHelper.GenerateDynamicModule("ModuleInLoadedFromContext1", "Module", ModulesDirectory1 + @"\ModuleInLoadedFromContext1.dll");
            var uriBuilder = new UriBuilder
                                 {
                                     Host = String.Empty,
                                     Scheme = Uri.UriSchemeFile,
                                     Path = Path.GetFullPath(assemblyPath)
                                 };
            var assemblyUri = uriBuilder.Uri;
            using (var resolver = new AssemblyResolver())
            {
                Type resolvedType =
                    Type.GetType(
                        "TestModules.ModuleInLoadedFromContext1Class, ModuleInLoadedFromContext1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
                Assert.IsNull(resolvedType);

                resolver.LoadAssemblyFrom(assemblyUri.ToString());

                resolvedType =
                    Type.GetType(
                        "TestModules.ModuleInLoadedFromContext1Class, ModuleInLoadedFromContext1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
                Assert.IsNotNull(resolvedType);
            }
        }

        [TestMethod]
        public void ShouldResolvePartialAssemblyName()
        {
            string assemblyPath = CompilerHelper.GenerateDynamicModule("ModuleInLoadedFromContext2", "Module", ModulesDirectory1 + @"\ModuleInLoadedFromContext2.dll");
            var uriBuilder = new UriBuilder
                                 {
                                     Host = String.Empty,
                                     Scheme = Uri.UriSchemeFile,
                                     Path = Path.GetFullPath(assemblyPath)
                                 };
            var assemblyUri = uriBuilder.Uri;
            using (var resolver = new AssemblyResolver())
            {
                resolver.LoadAssemblyFrom(assemblyUri.ToString());

                Type resolvedType =
                    Type.GetType("TestModules.ModuleInLoadedFromContext2Class, ModuleInLoadedFromContext2");

                Assert.IsNotNull(resolvedType);

                resolvedType =
                    Type.GetType("TestModules.ModuleInLoadedFromContext2Class, ModuleInLoadedFromContext2, Version=0.0.0.0");
                
                Assert.IsNotNull(resolvedType);

                resolvedType =
                    Type.GetType("TestModules.ModuleInLoadedFromContext2Class, ModuleInLoadedFromContext2, Version=0.0.0.0, Culture=neutral");

                Assert.IsNotNull(resolvedType);
            }
        }
    }
}
