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
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Regions
{
    [TestClass]
    public class RegionBehaviorCollectionFixture
    {
        [TestMethod]
        public void CanAttachRegionBehaviors()
        {
            RegionBehaviorCollection behaviorCollection = new RegionBehaviorCollection(new MockRegion());

            var mock1 = new MockRegionBehavior();
            bool mock1Attached = false;
            mock1.OnAttach = () => mock1Attached = true;
            behaviorCollection.Add("Mock1", mock1);

            var mock2 = new MockRegionBehavior();
            bool mock2Attached = false;
            mock2.OnAttach = () => mock2Attached = true;
            behaviorCollection.Add("Mock2", mock2);

            Assert.IsTrue(mock1Attached);
            Assert.IsTrue(mock2Attached);
        }

        [TestMethod]
        public void ShouldAddRegionWhenAddingBehavior()
        {
            var region = new MockRegion();
            RegionBehaviorCollection behaviorCollection = new RegionBehaviorCollection(region);
            var behavior = new MockRegionBehavior();

            behaviorCollection.Add("Mock", behavior);

            Assert.IsNotNull(behavior.Region);
            Assert.AreSame(region, behavior.Region);
        }

    }
}
