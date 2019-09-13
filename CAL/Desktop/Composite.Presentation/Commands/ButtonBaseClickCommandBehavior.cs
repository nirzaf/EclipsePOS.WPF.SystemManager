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
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Microsoft.Practices.Composite.Presentation.Commands
{
    /// <summary>
    /// Behavior that allows controls that derrive from <see cref="ButtonBase"/> to hook up with <see cref="ICommand"/> objects. 
    /// </summary>
    /// <remarks>
    /// This Behavior is required in Silverlight, because Silverlight does not have Commanding support.  
    /// </remarks>
    public class ButtonBaseClickCommandBehavior : CommandBehaviorBase<ButtonBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonBaseClickCommandBehavior"/> class and hooks up the Click event of 
        /// <paramref name="clickableObject"/> to the ExecuteCommand() method. 
        /// </summary>
        /// <param name="clickableObject">The clickable object.</param>
        public ButtonBaseClickCommandBehavior(ButtonBase clickableObject) : base(clickableObject)
        {
            clickableObject.Click += OnClick;
        }
      
        private void OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ExecuteCommand();
        }
    }
}