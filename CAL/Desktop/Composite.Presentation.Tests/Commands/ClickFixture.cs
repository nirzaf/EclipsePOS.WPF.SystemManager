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
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Presentation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Composite.Presentation.Tests.Commands
{
    [TestClass]
    public class ClickFixture
    {
        [TestMethod]
        public void ShouldHookUpClickCommandBehaviorWhenSettingProperty()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();

            Click.SetCommand(clickableObject, command);
            Assert.IsFalse(command.ExecuteCalled);

            clickableObject.RaiseClick();

            Assert.IsTrue(command.ExecuteCalled);
            Assert.AreSame(command, Click.GetCommand(clickableObject));
        }

        [TestMethod]
        public void ShouldUpdateCommandOnBehaviorWhenChangingProperty()
        {
            var clickableObject = new MockClickableObject();
            var oldCommand = new MockCommand();
            var newCommand = new MockCommand();

            Click.SetCommand(clickableObject, oldCommand);
            Click.SetCommand(clickableObject, newCommand);

            clickableObject.RaiseClick();

            Assert.IsTrue(newCommand.ExecuteCalled);
            Assert.IsFalse(oldCommand.ExecuteCalled);
        }

        [TestMethod]
        public void ShouldExecuteWithCommandParameter()
        {
            var clickableObject = new MockClickableObject();
            var command = new MockCommand();
            var parameter = new object();

            Click.SetCommand(clickableObject, command);
            Click.SetCommandParameter(clickableObject, parameter);
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
            Click.SetCommand(clickableObject, command);
            Assert.IsNull(command.CanExecuteParameter);
            Assert.IsTrue(clickableObject.IsEnabled);

            command.CanExecuteReturnValue = false;
            Click.SetCommandParameter(clickableObject, parameter);

            Assert.IsNotNull(command.CanExecuteParameter);
            Assert.AreSame(parameter, command.CanExecuteParameter);
            Assert.IsFalse(clickableObject.IsEnabled);
        }
    }
}
