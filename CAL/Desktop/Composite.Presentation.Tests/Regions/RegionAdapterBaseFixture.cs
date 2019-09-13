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
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionAdapterBaseFixture
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IncorrectTypeThrows()
        {
            IRegionAdapter adapter = new TestableRegionAdapterBase();
            adapter.Initialize(new MockDependencyObject(), "Region1");
        }

        [TestMethod]
        public void InitializeSetsRegionName()
        {
            IRegionAdapter adapter = new TestableRegionAdapterBase();
            var region = adapter.Initialize(new MockRegionTarget(), "Region1");
            Assert.AreEqual("Region1", region.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRegionNameThrows()
        {
            IRegionAdapter adapter = new TestableRegionAdapterBase();
            var region = adapter.Initialize(new MockRegionTarget(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullObjectThrows()
        {
            IRegionAdapter adapter = new TestableRegionAdapterBase();
            adapter.Initialize(null, "Region1");
        }


        [TestMethod]
        public void CreateRegionReturnValueIsPassedToAdapt()
        {
            var regionTarget = new MockRegionTarget();
            var adapter = new TestableRegionAdapterBase();

            adapter.Initialize(regionTarget, "Region1");

            Assert.AreSame(adapter.CreateRegionReturnValue, adapter.AdaptArgumentRegion);
            Assert.AreSame(regionTarget, adapter.adaptArgumentRegionTarget);
        }

        [TestMethod]
        public void CreateRegionReturnValueIsPassedToAttachBehaviors()
        {
            var regionTarget = new MockRegionTarget();
            var adapter = new TestableRegionAdapterBase();

            var region = adapter.Initialize(regionTarget, "Region1");

            Assert.AreSame(adapter.CreateRegionReturnValue, adapter.AttachBehaviorsArgumentRegion);
            Assert.AreSame(regionTarget, adapter.attachBehaviorsArgumentTargetToAdapt);
        }

        class TestableRegionAdapterBase : RegionAdapterBase<MockRegionTarget>
        {
            public IRegion CreateRegionReturnValue = new MockRegion();
            public IRegion AdaptArgumentRegion;
            public MockRegionTarget adaptArgumentRegionTarget;
            public IRegion AttachBehaviorsArgumentRegion;
            public MockRegionTarget attachBehaviorsArgumentTargetToAdapt;

            public TestableRegionAdapterBase() :base(null)
            {
                
            }

            protected override void Adapt(IRegion region, MockRegionTarget regionTarget)
            {
                AdaptArgumentRegion = region;
                adaptArgumentRegionTarget = regionTarget;
            }

            protected override IRegion CreateRegion()
            {
                return CreateRegionReturnValue;
            }

            protected override void AttachBehaviors(IRegion region, MockRegionTarget regionTarget)
            {
                AttachBehaviorsArgumentRegion = region;
                attachBehaviorsArgumentTargetToAdapt = regionTarget;
                base.AttachBehaviors(region, regionTarget);
            }
        }

        class MockRegionTarget
        {
        }
    }
}
