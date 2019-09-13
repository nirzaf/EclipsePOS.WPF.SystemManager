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
using Microsoft.Practices.Composite.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Events
{
    [TestClass]
    public class SubscriptionTokenFixture
    {
        [TestMethod]
        public void EqualsShouldReturnFalseIfSubscriptionTokenPassedIsNull()
        {
            SubscriptionToken token = new SubscriptionToken();
            Assert.IsFalse(token.Equals(null));
        }

        [TestMethod]
        public void EqualsShouldReturnTrueWhenTokenIsTheSame()
        {
            SubscriptionToken token = new SubscriptionToken();
            Assert.IsTrue(token.Equals(token));
        }

        [TestMethod]
        public void EqualsShouldReturnTrueWhenComparingSameObjectInstances()
        {
            SubscriptionToken token = new SubscriptionToken();

            object tokenObject = token;

            Assert.IsTrue(token.Equals(tokenObject));
        }

        [TestMethod]
        public void EqualsShouldReturnFalseWhenComparingDifferentObjectInstances()
        {
            SubscriptionToken token = new SubscriptionToken();

            object tokenObject = new SubscriptionToken();

            Assert.IsFalse(token.Equals(tokenObject));
        }

        [TestMethod]
        public void HashCodeIsTheSameForSameToken()
        {
            SubscriptionToken token = new SubscriptionToken();
            int hashCode = token.GetHashCode();

            Assert.AreNotEqual(0, hashCode);
            Assert.AreEqual(hashCode, token.GetHashCode());
        }

    }
}