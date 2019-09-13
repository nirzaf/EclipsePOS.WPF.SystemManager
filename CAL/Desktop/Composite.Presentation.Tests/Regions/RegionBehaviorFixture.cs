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
using System.Text;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionBehaviorFixture
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotChangeRegionAfterAttach()
        {
            TestableRegionBehavior regionBehavior = new TestableRegionBehavior();

            regionBehavior.Region = new MockRegion();

            regionBehavior.Attach();
            regionBehavior.Region = new MockRegion();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldFailWhenAttachedWithoutRegion()
        {
            TestableRegionBehavior regionBehavior = new TestableRegionBehavior();
            regionBehavior.Attach();
        }

        [TestMethod]
        public void ShouldCallOnAttachWhenAttachMethodIsInvoked()
        {
            TestableRegionBehavior regionBehavior = new TestableRegionBehavior();

            regionBehavior.Region = new MockRegion();

            regionBehavior.Attach();

            Assert.IsTrue(regionBehavior.onAttachCalled);
        }

        private class TestableRegionBehavior : RegionBehavior
        {
            public bool onAttachCalled;

            protected override void OnAttach()
            {
                onAttachCalled = true;
            }
        }
    }

    
}
