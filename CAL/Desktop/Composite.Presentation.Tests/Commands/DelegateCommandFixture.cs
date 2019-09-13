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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Commands
{
    /// <summary>
    /// Summary description for DelegateCommandFixture
    /// </summary>
    [TestClass]
    public class DelegateCommandFixture
    {
        [TestMethod]
        public void ExecuteCallsPassedInExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new DelegateCommand<object>(handlers.Execute, null);
            object parameter = new object();

            command.Execute(parameter);

            Assert.AreSame(parameter, handlers.ExecuteParameter);
        }

        [TestMethod]
        public void CanExecuteCallsPassedInCanExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new DelegateCommand<object>(handlers.Execute, handlers.CanExecute);
            object parameter = new object();

            handlers.CanExecuteReturnValue = true;
            bool retVal = command.CanExecute(parameter);

            Assert.AreSame(parameter, handlers.CanExecuteParameter);
            Assert.AreEqual(handlers.CanExecuteReturnValue, retVal);
        }

        [TestMethod]
        public void CanExecuteReturnsTrueWithouthCanExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new DelegateCommand<object>(handlers.Execute);

            bool retVal = command.CanExecute(null);

            Assert.AreEqual(true, retVal);
        }


        [TestMethod]
        public void RaiseCanExecuteChangedRaisesCanExecuteChanged()
        {
            var handlers = new DelegateHandlers();
            var command = new DelegateCommand<object>(handlers.Execute);
            bool canExecuteChangedRaised = false;
            command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

            command.RaiseCanExecuteChanged();

            Assert.IsTrue(canExecuteChangedRaised);
        }

        [TestMethod]
        public void ShouldAllowOnlyCanExecuteDelegate()
        {
            bool canExecuteCalled = false;
            var command = new DelegateCommand<int>(null, delegate
                                                             {
                                                                 canExecuteCalled = true;
                                                                 return true;
                                                             });
            command.CanExecute(0);
            Assert.IsTrue(canExecuteCalled);
        }

        [TestMethod]
        public void ShouldPassParameterInstanceOnExecute()
        {
            bool executeCalled = false;
            MyClass testClass = new MyClass();
            ICommand command = new DelegateCommand<MyClass>(delegate(MyClass parameter)
                                                                {
                                                                    Assert.AreSame(testClass, parameter);
                                                                    executeCalled = true;
                                                                });

            command.Execute(testClass);
            Assert.IsTrue(executeCalled);
        }

        [TestMethod]
        public void ShouldPassParameterInstanceOnCanExecute()
        {
            bool canExecuteCalled = false;
            MyClass testClass = new MyClass();
            ICommand command = new DelegateCommand<MyClass>(null, delegate(MyClass parameter)
                                                                      {
                                                                          Assert.AreSame(testClass, parameter);
                                                                          canExecuteCalled = true;
                                                                          return true;
                                                                      });

            command.CanExecute(testClass);
            Assert.IsTrue(canExecuteCalled);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowIfAllDelegatesAreNull()
        {
            var command = new DelegateCommand<int>(null, null);
        }


        [TestMethod]
        public void IsActivePropertyChangeFiresEvent()
        {
            bool fired = false;
            var command = new DelegateCommand<object>(DoNothing);
            command.IsActiveChanged += delegate { fired = true; };
            command.IsActive = true;

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldKeepWeakReferenceToOnCanExecuteChangedHandlers()
        {
            var command = new DelegateCommand<MyClass>((MyClass c) => { });

            var handlers = new CanExecutChangeHandler();
            var weakHandlerRef = new WeakReference(handlers);
            command.CanExecuteChanged += handlers.CanExecuteChangeHandler;
            handlers = null;

            GC.Collect();
            command.RaiseCanExecuteChanged();
            
            Assert.IsFalse(weakHandlerRef.IsAlive);
        }

        class CanExecutChangeHandler
        {
            public bool CanExeucteChangedHandlerCalled;
            public void CanExecuteChangeHandler(object sender, EventArgs e)
            {
                CanExeucteChangedHandlerCalled = true;
            }
        }
        public void DoNothing(object param)
        { }


        class DelegateHandlers
        {
            public bool CanExecuteReturnValue = true;
            public object CanExecuteParameter;
            public object ExecuteParameter;

            public bool CanExecute(object parameter)
            {
                CanExecuteParameter = parameter;
                return CanExecuteReturnValue;
            }

            public void Execute(object parameter)
            {
                ExecuteParameter = parameter;
            }
        }
    }

    internal class MyClass
    {
    }
}