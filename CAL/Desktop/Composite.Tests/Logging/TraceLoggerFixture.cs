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
using System.Diagnostics;
using Microsoft.Practices.Composite.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Tests.Logging
{
    [TestClass]
    public class TraceLoggerFixture
    {
        TraceListener[] existingListeners;

        [TestInitialize]
        public void RemoveExisitingListeners()
        {
            existingListeners = new TraceListener[Trace.Listeners.Count];
            Trace.Listeners.CopyTo(existingListeners, 0);
            Trace.Listeners.Clear();
        }

        [TestCleanup]
        public void ReAttachExistingListeners()
        {
            Trace.Listeners.AddRange(existingListeners);
        }

        [TestMethod]
        public void ShouldWriteToTraceWriter()
        {
            var listener = new MockTraceListener();
            Trace.Listeners.Add(listener);

            var traceLogger = new TraceLogger();
            traceLogger.Log("Test debug message", Category.Debug, Priority.Low);

            Assert.AreEqual<string>("Test debug message", listener.LogMessage);

            Trace.Listeners.Remove(listener);
        }


        [TestMethod]
        public void ShouldTraceErrorException()
        {
            var listener = new MockTraceListener();
            Trace.Listeners.Add(listener);

            var traceLogger = new TraceLogger();
            traceLogger.Log("Test exception message", Category.Exception, Priority.Low);

            Assert.AreEqual<string>("Test exception message", listener.ErrorMessage);

            Trace.Listeners.Remove(listener);
        }
    }

    class MockTraceListener : TraceListener
    {
        public string LogMessage { get; set; }
        public string ErrorMessage { get; set; }

        public override void Write(string message)
        {
            LogMessage = message;
        }

        public override void WriteLine(string message)
        {
            LogMessage = message;
        }

        public override void WriteLine(string message, string category)
        {
            LogMessage = message;
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            if (eventType == TraceEventType.Error)
            {
                ErrorMessage = message;
            }
            else
            {
                LogMessage = message;
            }
        }
    }
}