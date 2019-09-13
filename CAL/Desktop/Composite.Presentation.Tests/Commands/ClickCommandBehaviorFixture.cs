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
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Commands
{
    [TestClass]
    public class ClickCommandBehaviorFixture
    {
        [TestMethod]
        public void ShouldObserveClickEvent()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;
            Assert.IsFalse(command.ExecuteCalled);

            clickableObject.RaiseClick();

            Assert.IsTrue(command.ExecuteCalled);
        }

        [TestMethod]
        public void ShouldDisableButtonIfCanExecuteFalse()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand() { CanExecuteReturnValue = false };

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            Assert.IsTrue(clickableObject.IsEnabled);

            behavior.Command = command;
            Assert.IsFalse(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void ShouldDisableButtonIfCanExecuteChangedRaises()
        {
            var clickableObject = new MockClickableObject();
            var mockCommand = new MockCommand() { CanExecuteReturnValue = true };

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = mockCommand;
            Assert.IsTrue(clickableObject.IsEnabled);

            mockCommand.CanExecuteReturnValue = false;
            mockCommand.RaiseCanExecuteChanged();

            Assert.IsFalse(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void ShouldReEnableButtonIfCanExecuteChangedRaises()
        {
            var clickableObject = new MockClickableObject();
            var mockCommand = new MockCommand() { CanExecuteReturnValue = false };

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = mockCommand;
            Assert.IsFalse(clickableObject.IsEnabled);

            mockCommand.CanExecuteReturnValue = true;
            mockCommand.RaiseCanExecuteChanged();

            Assert.IsTrue(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void ChangingCommandsShouldExecuteOnNewCommand()
        {
            var clickableObject = new MockClickableObject();
            var originalCommand = new MockCommand() { CanExecuteReturnValue = true };
            var newCommand = new MockCommand() { CanExecuteReturnValue = true };

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = originalCommand;

            clickableObject.RaiseClick();
            Assert.IsFalse(newCommand.ExecuteCalled);

            behavior.Command = newCommand;
            clickableObject.RaiseClick();
            Assert.IsTrue(newCommand.ExecuteCalled);
        }

        [TestMethod]
        public void ChangingCommandsShouldNotExecuteOldCommand()
        {
            var clickableObject = new MockClickableObject();
            var originalCommand = new MockCommand() { CanExecuteReturnValue = true };
            var newCommand = new MockCommand() { CanExecuteReturnValue = true };

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = originalCommand;

            behavior.Command = newCommand;
            clickableObject.RaiseClick();

            Assert.IsFalse(originalCommand.ExecuteCalled);
        }

        [TestMethod]
        public void ShouldNotThrowWhenCommandSetToNull()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;

            behavior.Command = null;
            clickableObject.RaiseClick();
        }

        [TestMethod]
        public void ShouldNotMonitorCanExecuteChangedOnDisconnectedCommand()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;

            behavior.Command = null;

            Assert.IsTrue(clickableObject.IsEnabled);
            command.CanExecuteReturnValue = false;
            command.RaiseCanExecuteChanged();
            Assert.IsTrue(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void CommandShouldNotKeepButtonAlive()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;

            WeakReference controlWeakReference = new WeakReference(clickableObject);
            clickableObject = null;
            behavior = null;
            GC.Collect();

            Assert.IsFalse(controlWeakReference.IsAlive);
            GC.KeepAlive(command);
        }

        [TestMethod]
        public void DisposedControlDoesNotThrowOnCanExecuteChanged()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;

            WeakReference controlWeakReference = new WeakReference(clickableObject);
            clickableObject = null;
            behavior = null;
            GC.Collect();

            command.CanExecuteReturnValue = false;
            command.RaiseCanExecuteChanged();
        }

        [TestMethod]
        public void DisposedControlStopsMonitoringCommandAfterFirstCanExecuteChanged()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;

            clickableObject = null;
            WeakReference commandReference = new WeakReference(command);
            GC.Collect();

            command.CanExecuteReturnValue = false;
            command.RaiseCanExecuteChanged();
            command = null;

            GC.Collect();

            Assert.IsFalse(commandReference.IsAlive);
        }

        [TestMethod]
        public void ShouldExecuteWithCommandParameter()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();
            var parameter = new object();
            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;
            behavior.CommandParameter = parameter;
            Assert.IsNull(command.ExecuteParameter);

            clickableObject.RaiseClick();

            Assert.IsTrue(command.ExecuteCalled);
            Assert.IsNotNull(command.ExecuteParameter);
            Assert.AreSame(parameter, command.ExecuteParameter);
        }

        [TestMethod]
        public void ShouldCallCanExecuteOnParameterChange()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();
            var parameter = new object();
            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;
            Assert.IsNull(command.CanExecuteParameter);
            Assert.IsTrue(clickableObject.IsEnabled);

            command.CanExecuteReturnValue = false;
            behavior.CommandParameter = parameter;

            Assert.IsNotNull(command.CanExecuteParameter);
            Assert.AreSame(parameter, command.CanExecuteParameter);
            Assert.IsFalse(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void ShouldCallCanExecuteWithParameterWhenSettingCommand()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();
            var parameter = new object();
            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            command.CanExecuteReturnValue = false;
            behavior.CommandParameter = parameter;
            Assert.IsNull(command.CanExecuteParameter);
            Assert.IsTrue(clickableObject.IsEnabled);

            behavior.Command = command;

            Assert.IsNotNull(command.CanExecuteParameter);
            Assert.AreSame(parameter, command.CanExecuteParameter);
            Assert.IsFalse(clickableObject.IsEnabled);
        }

        [TestMethod]
        public void ShouldUpdateEnabledStateIfCanExecuteChangedRaisesOnDelegateCommandAfterCollect()
        {
            var clickableObject = new MockClickableObject();
            var command = new DelegateCommand<object>(delegate { }, o => true);

            var behavior = new ButtonBaseClickCommandBehavior(clickableObject);
            behavior.Command = command;
            clickableObject.IsEnabled = false;

            GC.Collect();

            command.RaiseCanExecuteChanged();
            Assert.IsTrue(clickableObject.IsEnabled);
        }


        // Should bind to any object with Click event.
        // Should call canexecute before execute? JD: I'd say no
    }
}
