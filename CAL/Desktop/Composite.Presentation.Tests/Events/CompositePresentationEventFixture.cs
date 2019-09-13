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
using System.Linq;
using System.Threading;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Events
{
    [TestClass]
    public class CompositePresentationEventFixture
    {
        [TestMethod]
        public void CanSubscribeAndRaiseEvent()
        {
            TestableCompositePresentationEvent<string> compositePresentationEvent = new TestableCompositePresentationEvent<string>();
            bool published = false;
            compositePresentationEvent.Subscribe(delegate { published = true; }, ThreadOption.PublisherThread, true, delegate { return true; });
            compositePresentationEvent.Publish(null);

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void CanSubscribeAndRaiseCustomEvent()
        {
            var customEvent = new TestableCompositePresentationEvent<Payload>();
            Payload payload = new Payload();
            var action = new ActionHelper();
            customEvent.Subscribe(action.Action);

            customEvent.Publish(payload);

            Assert.AreSame(action.ActionArg<Payload>(), payload);
        }

        [TestMethod]
        public void CanHaveMultipleSubscribersAndRaiseCustomEvent()
        {
            var customEvent = new TestableCompositePresentationEvent<Payload>();
            Payload payload = new Payload();
            var action1 = new ActionHelper();
            var action2 = new ActionHelper();
            customEvent.Subscribe(action1.Action);
            customEvent.Subscribe(action2.Action);

            customEvent.Publish(payload);

            Assert.AreSame(action1.ActionArg<Payload>(), payload);
            Assert.AreSame(action2.ActionArg<Payload>(), payload);
        }

        [TestMethod]
        public void SubscribeTakesExecuteDelegateThreadOptionAndFilter()
        {
            TestableCompositePresentationEvent<string> compositePresentationEvent = new TestableCompositePresentationEvent<string>();
            var action = new ActionHelper();
            compositePresentationEvent.Subscribe(action.Action);

            compositePresentationEvent.Publish("test");

            Assert.AreEqual("test", action.ActionArg<string>());

        }

        [TestMethod]
        public void FilterEnablesActionTarget()
        {
            TestableCompositePresentationEvent<string> compositePresentationEvent = new TestableCompositePresentationEvent<string>();
            var goodFilter = new MockFilter {FilterReturnValue = true};
            var actionGoodFilter = new ActionHelper();
            var badFilter = new MockFilter { FilterReturnValue = false };
            var actionBadFilter = new ActionHelper();
            compositePresentationEvent.Subscribe(actionGoodFilter.Action, ThreadOption.PublisherThread, true, goodFilter.FilterString);
            compositePresentationEvent.Subscribe(actionBadFilter.Action, ThreadOption.PublisherThread, true, badFilter.FilterString);

            compositePresentationEvent.Publish("test");

            Assert.IsTrue(actionGoodFilter.ActionCalled);
            Assert.IsFalse(actionBadFilter.ActionCalled);

        }

        [TestMethod]
        public void SubscribeDefaultsThreadOptionAndNoFilter()
        {
            TestableCompositePresentationEvent<string> compositePresentationEvent = new TestableCompositePresentationEvent<string>();
            int calledThreadID = -1;
            var myAction = new ActionHelper()
                               {
                                   ActionToExecute =
                                       () => calledThreadID = Thread.CurrentThread.ManagedThreadId
                               };
            compositePresentationEvent.Subscribe(myAction.Action);

            compositePresentationEvent.Publish("test");

            Assert.AreEqual(Thread.CurrentThread.ManagedThreadId, calledThreadID);
        }

        [TestMethod]
        public void ShouldUnsubscribeFromPublisherThread()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            var actionEvent = new ActionHelper();
            CompositePresentationEvent.Subscribe(
                actionEvent.Action,
                ThreadOption.PublisherThread);

            Assert.IsTrue(CompositePresentationEvent.Contains(actionEvent.Action));
            CompositePresentationEvent.Unsubscribe(actionEvent.Action);
            Assert.IsFalse(CompositePresentationEvent.Contains(actionEvent.Action));
        }

        [TestMethod]
        public void UnsubscribeShouldNotFailWithNonSubscriber()
        {
            TestableCompositePresentationEvent<string> compositePresentationEvent = new TestableCompositePresentationEvent<string>();

            Action<string> subscriber = delegate { };
            compositePresentationEvent.Unsubscribe(subscriber);
        }

        [TestMethod]
        public void ShouldUnsubscribeFromBackgroundThread()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            var actionEvent = new ActionHelper();
            CompositePresentationEvent.Subscribe(
                actionEvent.Action,
                ThreadOption.BackgroundThread);

            Assert.IsTrue(CompositePresentationEvent.Contains(actionEvent.Action));
            CompositePresentationEvent.Unsubscribe(actionEvent.Action);
            Assert.IsFalse(CompositePresentationEvent.Contains(actionEvent.Action));
        }

        [TestMethod]
        public void ShouldUnsubscribeFromUIThread()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            var actionEvent = new ActionHelper();
            CompositePresentationEvent.Subscribe(
                actionEvent.Action,
                ThreadOption.UIThread);

            Assert.IsTrue(CompositePresentationEvent.Contains(actionEvent.Action));
            CompositePresentationEvent.Unsubscribe(actionEvent.Action);
            Assert.IsFalse(CompositePresentationEvent.Contains(actionEvent.Action));
        }

        [TestMethod]
        public void ShouldUnsubscribeASingleDelegate()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            int callCount = 0;

            var actionEvent = new ActionHelper() {ActionToExecute = () => callCount++};
            CompositePresentationEvent.Subscribe(actionEvent.Action);
            CompositePresentationEvent.Subscribe(actionEvent.Action);

            CompositePresentationEvent.Publish(null);
            Assert.AreEqual<int>(2, callCount);

            callCount = 0;
            CompositePresentationEvent.Unsubscribe(actionEvent.Action);
            CompositePresentationEvent.Publish(null);
            Assert.AreEqual<int>(1, callCount);
        }

        [TestMethod]
        public void ShouldNotExecuteOnGarbageCollectedDelegateReferenceWhenNotKeepAlive()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            ExternalAction externalAction = new ExternalAction();
            CompositePresentationEvent.Subscribe(externalAction.ExecuteAction);

            CompositePresentationEvent.Publish("testPayload");
            Assert.AreEqual("testPayload", externalAction.PassedValue);

            WeakReference actionEventReference = new WeakReference(externalAction);
            externalAction = null;
            GC.Collect();
            Assert.IsFalse(actionEventReference.IsAlive);

            CompositePresentationEvent.Publish("testPayload");
        }

        [TestMethod]
        public void ShouldNotExecuteOnGarbageCollectedFilterReferenceWhenNotKeepAlive()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            bool wasCalled = false;
            var actionEvent = new ActionHelper() {ActionToExecute = () => wasCalled = true};

            ExternalFilter filter = new ExternalFilter();
            CompositePresentationEvent.Subscribe(actionEvent.Action, ThreadOption.PublisherThread, false, filter.AlwaysTrueFilter);

            CompositePresentationEvent.Publish("testPayload");
            Assert.IsTrue(wasCalled);

            wasCalled = false;
            WeakReference filterReference = new WeakReference(filter);
            filter = null;
            GC.Collect();
            Assert.IsFalse(filterReference.IsAlive);

            CompositePresentationEvent.Publish("testPayload");
            Assert.IsFalse(wasCalled);
        }

        [TestMethod]
        public void CanAddSubscriptionWhileEventIsFiring()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            var emptyAction = new ActionHelper();
            var subscriptionAction = new ActionHelper
                                         { ActionToExecute = (() =>
                                                                             CompositePresentationEvent.Subscribe(
                                                                                 emptyAction.Action)) };

            CompositePresentationEvent.Subscribe(subscriptionAction.Action);

            Assert.IsFalse(CompositePresentationEvent.Contains(emptyAction.Action));

            CompositePresentationEvent.Publish(null);

            Assert.IsTrue((CompositePresentationEvent.Contains(emptyAction.Action)));
        }

        [TestMethod]
#if SILVERLIGHT
        [Ignore]
#endif
        public void InlineDelegateDeclarationsDoesNotGetCollectedIncorrectlyWithWeakReferences()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();
            bool published = false;
            CompositePresentationEvent.Subscribe(delegate { published = true; }, ThreadOption.PublisherThread, false, delegate { return true; });
            GC.Collect();
            CompositePresentationEvent.Publish(null);

            Assert.IsTrue(published);
        }

        [TestMethod]
        public void ShouldNotGarbageCollectDelegateReferenceWhenUsingKeepAlive()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();

            var externalAction = new ExternalAction();
            CompositePresentationEvent.Subscribe(externalAction.ExecuteAction, ThreadOption.PublisherThread, true);

            WeakReference actionEventReference = new WeakReference(externalAction);
            externalAction = null;
            GC.Collect();
            GC.Collect();
            Assert.IsTrue(actionEventReference.IsAlive);

            CompositePresentationEvent.Publish("testPayload");

            Assert.AreEqual("testPayload", ((ExternalAction)actionEventReference.Target).PassedValue);
        }

        [TestMethod]
        public void RegisterReturnsTokenThatCanBeUsedToUnsubscribe()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();
            var emptyAction = new ActionHelper();

            var token = CompositePresentationEvent.Subscribe(emptyAction.Action);
            CompositePresentationEvent.Unsubscribe(token);

            Assert.IsFalse(CompositePresentationEvent.Contains(emptyAction.Action));
        }

        [TestMethod]
        public void ContainsShouldSearchByToken()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();
            var emptyAction = new ActionHelper();
            var token = CompositePresentationEvent.Subscribe(emptyAction.Action);

            Assert.IsTrue(CompositePresentationEvent.Contains(token));

            CompositePresentationEvent.Unsubscribe(emptyAction.Action);
            Assert.IsFalse(CompositePresentationEvent.Contains(token));
        }

        [TestMethod]
        public void SubscribeDefaultsToPublisherThread()
        {
            var CompositePresentationEvent = new TestableCompositePresentationEvent<string>();
            Action<string> action = delegate { };
            var token = CompositePresentationEvent.Subscribe(action, true);

            Assert.AreEqual(1, CompositePresentationEvent.BaseSubscriptions.Count);
            Assert.AreEqual(typeof(EventSubscription<string>), CompositePresentationEvent.BaseSubscriptions.ElementAt(0).GetType());
        }

        public class ExternalFilter
        {
            public bool AlwaysTrueFilter(string value)
            {
                return true;
            }
        }

        public class ExternalAction
        {
            public string PassedValue;
            public void ExecuteAction(string value)
            {
                PassedValue = value;
            }
        }

        class TestableCompositePresentationEvent<TPayload> : CompositePresentationEvent<TPayload>
        {
            public ICollection<IEventSubscription> BaseSubscriptions
            {
                get { return base.Subscriptions; }
            }
        }

        public class Payload { }
    }

    public class ActionHelper
    {
        public bool ActionCalled;
        public Action ActionToExecute = null;
        private object actionArg;

        public T ActionArg<T>()
        {
            return (T)actionArg;
        }

        public void Action(CompositePresentationEventFixture.Payload arg)
        {
            Action((object)arg);
        }

        public void Action(string arg)
        {
            Action((object)arg);
        }

        public void Action(object arg)
        {
            actionArg = arg;
            ActionCalled = true;
            if (ActionToExecute != null)
            {
                ActionToExecute.Invoke();
            }
        }
    }

    public class MockFilter
    {
        public bool FilterReturnValue;

        public bool FilterString(string arg)
        {
            return FilterReturnValue;
        }
    }
}