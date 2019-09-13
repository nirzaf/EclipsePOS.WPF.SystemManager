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
using System.Text;
using Microsoft.Practices.Composite.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Logging
{
    [TestClass]
    public class TextLoggerFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTextWriterThrows()
        {
            ILoggerFacade logger = new TextLogger(null);
        }

        [TestMethod]
        public void ShouldWriteToTextWriter()
        {
            TextWriter writer = new StringWriter();
            ILoggerFacade logger = new TextLogger(writer);

            logger.Log("Test", Category.Debug, Priority.Low);
            StringAssert.Contains(writer.ToString(), "Test");
            StringAssert.Contains(writer.ToString(), "DEBUG");
            StringAssert.Contains(writer.ToString(), "Low");
        }

        [TestMethod]
        public void ShouldDisposeWriterOnDispose()
        {
            MockWriter writer = new MockWriter();
            IDisposable logger = new TextLogger(writer);

            Assert.IsFalse(writer.DisposeCalled);
            logger.Dispose();
            Assert.IsTrue(writer.DisposeCalled);
        }
    }

    internal class MockWriter : TextWriter
    {
        public bool DisposeCalled;
        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }

        protected override void Dispose(bool disposing)
        {
            DisposeCalled = true;
            base.Dispose(disposing);
        }
    }
}