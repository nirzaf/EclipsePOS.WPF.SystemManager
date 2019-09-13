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
using Microsoft.Practices.Composite.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Events
{
    [TestClass]
    public class DelegateReferenceFixture
    {
        [TestMethod]
        public void KeepAlivePreventsDelegateFromBeingCollected()
        {
            var delegates = new SomeClassHandler();
            var delegateReference = new DelegateReference((Action<string>)delegates.DoEvent, true);

            delegates = null;
            GC.Collect();

            Assert.IsNotNull(delegateReference.Target);
        }

        [TestMethod]
        public void NotKeepAliveAllowsDelegateToBeCollected()
        {
            var delegates = new SomeClassHandler();
            var delegateReference = new DelegateReference((Action<string>)delegates.DoEvent, false);

            delegates = null;
            GC.Collect();

            Assert.IsNull(delegateReference.Target);
        }

        [TestMethod]
        public void NotKeepAliveKeepsDelegateIfStillAlive()
        {
            var delegates = new SomeClassHandler();
            var delegateReference = new DelegateReference((Action<string>)delegates.DoEvent, false);

            GC.Collect();

            Assert.IsNotNull(delegateReference.Target);

            GC.KeepAlive(delegates);  //Makes delegates ineligible for garbage collection until this point (to prevent oompiler optimizations that may release the referenced object prematurely).
            delegates = null;
            GC.Collect();

            Assert.IsNull(delegateReference.Target);
        }

        [TestMethod]
        public void TargetShouldReturnAction()
        {
            var classHandler = new SomeClassHandler();
            Action<string> myAction = new Action<string>(classHandler.MyAction);

            var weakAction = new DelegateReference(myAction, false);

            ((Action<string>)weakAction.Target)("payload");
            Assert.AreEqual("payload", classHandler.MyActionArg);
        }

        [TestMethod]
        public void ShouldAllowCollectionOfOriginalDelegate()
        {
            var classHandler = new SomeClassHandler();
            Action<string> myAction = new Action<string>(classHandler.MyAction);

            var weakAction = new DelegateReference(myAction, false);

            var originalAction = new WeakReference(myAction);
            myAction = null;
            GC.Collect();
            Assert.IsFalse(originalAction.IsAlive);

            ((Action<string>)weakAction.Target)("payload");
            Assert.AreEqual("payload", classHandler.MyActionArg);
        }

        [TestMethod]
        public void ShouldReturnNullIfTargetNotAlive()
        {
            SomeClassHandler handler = new SomeClassHandler();
            var weakHandlerRef = new WeakReference(handler);

            var action = new DelegateReference((Action<string>)handler.DoEvent, false);

            handler = null;
            GC.Collect();
            Assert.IsFalse(weakHandlerRef.IsAlive);

            Assert.IsNull(action.Target);
        }

        [TestMethod]
        public void WeakDelegateWorksWithStaticMethodDelegates()
        {
            var action = new DelegateReference((Action)SomeClassHandler.StaticMethod, false);

            Assert.IsNotNull(action.Target);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullDelegateThrows()
        {
            var action = new DelegateReference(null, true);
        }

        public class SomeClassHandler
        {
            public string MyActionArg;

            public void DoEvent(string value)
            {
                string myValue = value;
            }

            public static void StaticMethod()
            {
                int i = 0;
            }

            public void MyAction(string arg)
            {
                MyActionArg = arg;
            }
        }
    }
}
