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
using Microsoft.Practices.Composite.UnityExtensions.Tests.Mocks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.UnityExtensions.Tests
{
    [TestClass]
    public class UnityServiceLocatorAdapterFixture
    {
        [TestMethod]
        public void ShouldForwardResolveToInnerContainer()
        {
            object myInstance = new object();

            IUnityContainer container = new MockUnityContainer()
                                            {
                                                ResolveMethod = delegate
                                                                    {
                                                                        return myInstance;
                                                                    }
                                            };

            IServiceLocator containerAdapter = new UnityServiceLocatorAdapter(container);

            Assert.AreSame(myInstance, containerAdapter.GetInstance(typeof (object)));

        }

        [TestMethod]
        public void ShouldForwardResolveAllToInnerContainer()
        {
            IEnumerable<object> list = new List<object> {new object(), new object()};

            IUnityContainer container = new MockUnityContainer()
            {
                ResolveAllMethod = delegate
                {
                    return list;
                }
            };

            IServiceLocator containerAdapter = new UnityServiceLocatorAdapter(container);

            Assert.AreSame(list, containerAdapter.GetAllInstances(typeof (object)));
        }

        private class MockUnityContainer : IUnityContainer
        {

            public Func<object> ResolveMethod { get; set; }

            #region Implementation of IDisposable

            public void Dispose()
            {

            }

            #endregion

            #region Implementation of IUnityContainer

            public IUnityContainer RegisterType<T>(params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<TFrom, TTo>(params InjectionMember[] injectionMembers) where TTo : TFrom
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<TFrom, TTo>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TTo : TFrom
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<TFrom, TTo>(string name, params InjectionMember[] injectionMembers) where TTo : TFrom
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<TFrom, TTo>(string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TTo : TFrom
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<T>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<T>(string name, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType<T>(string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type t, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type from, Type to, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type from, Type to, string name, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type from, Type to, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type t, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type t, string name, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type t, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterType(Type from, Type to, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance<TInterface>(TInterface instance)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance<TInterface>(TInterface instance, LifetimeManager lifetimeManager)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance<TInterface>(string name, TInterface instance)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance<TInterface>(string name, TInterface instance, LifetimeManager lifetimeManager)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance(Type t, object instance)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance(Type t, object instance, LifetimeManager lifetimeManager)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance(Type t, string name, object instance)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RegisterInstance(Type t, string name, object instance, LifetimeManager lifetime)
            {
                throw new System.NotImplementedException();
            }

            public T Resolve<T>()
            {
                return (T)Resolve(typeof(T));
            }

            public T Resolve<T>(string name)
            {
                return (T)Resolve(typeof(T));
            }

            public object Resolve(Type t)
            {
                return Resolve(t, null);
            }

            public object Resolve(Type t, string name)
            {
                return ResolveMethod();
            }

            public IEnumerable<T> ResolveAll<T>()
            {
                return (IEnumerable<T>)ResolveAll(typeof (T));
            }

            public IEnumerable<object> ResolveAll(Type t)
            {
                return ResolveAllMethod();
            }

            public T BuildUp<T>(T existing)
            {
                throw new System.NotImplementedException();
            }

            public T BuildUp<T>(T existing, string name)
            {
                throw new System.NotImplementedException();
            }

            public object BuildUp(Type t, object existing)
            {
                throw new System.NotImplementedException();
            }

            public object BuildUp(Type t, object existing, string name)
            {
                throw new System.NotImplementedException();
            }

            public void Teardown(object o)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer AddExtension(UnityContainerExtension extension)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer AddNewExtension<TExtension>() where TExtension : UnityContainerExtension, new()
            {
                throw new System.NotImplementedException();
            }

            public TConfigurator Configure<TConfigurator>() where TConfigurator : IUnityContainerExtensionConfigurator
            {
                throw new System.NotImplementedException();
            }

            public object Configure(Type configurationInterface)
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer RemoveAllExtensions()
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer CreateChildContainer()
            {
                throw new System.NotImplementedException();
            }

            public IUnityContainer Parent
            {
                get { throw new System.NotImplementedException(); }
            }

            public Func<IEnumerable<object>> ResolveAllMethod { get; set; }

            #endregion
        }
    }
}