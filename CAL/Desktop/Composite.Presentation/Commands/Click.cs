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
    /// Static Class that holds all Dependency Properties and Static methods to allow 
    /// the Click event of the ButtonBase class to be attached to a Command. 
    /// </summary>
    /// <remarks>
    /// This class is required, because Silverlight doesn't have native support for Commands. 
    /// </remarks>
    public static class Click
    {
        private static readonly DependencyProperty ClickCommandBehaviorProperty = DependencyProperty.RegisterAttached(
            "ClickCommandBehavior",
            typeof(ButtonBaseClickCommandBehavior),
            typeof(Click),
            null);


        /// <summary>
        /// Command to execute on click event.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(Click),
            new PropertyMetadata(OnSetCommandCallback));

        /// <summary>
        /// Command parameter to supply on command execution.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter",
            typeof(object),
            typeof(Click),
            new PropertyMetadata(OnSetCommandParameterCallback));


        /// <summary>
        /// Sets the <see cref="ICommand"/> to execute on the click event.
        /// </summary>
        /// <param name="buttonBase">ButtonBase dependency object to attach command</param>
        /// <param name="command">Command to attach</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommand(ButtonBase buttonBase, ICommand command)
        {
            buttonBase.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// Retrieves the <see cref="ICommand"/> attached to the <see cref="ButtonBase"/>.
        /// </summary>
        /// <param name="buttonBase">ButtonBase containing the Command dependency property</param>
        /// <returns>The value of the command attached</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static ICommand GetCommand(ButtonBase buttonBase)
        {
            return buttonBase.GetValue(CommandProperty) as ICommand;
        }

        /// <summary>
        /// Sets the value for the CommandParameter attached property on the provided <see cref="ButtonBase"/>.
        /// </summary>
        /// <param name="buttonBase">ButtonBase to attach CommandParameter</param>
        /// <param name="parameter">Parameter value to attach</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommandParameter(ButtonBase buttonBase, object parameter)
        {
            buttonBase.SetValue(CommandParameterProperty, parameter);
        }

        /// <summary>
        /// Gets the value in CommandParameter attached property on the provided <see cref="ButtonBase"/>
        /// </summary>
        /// <param name="buttonBase">ButtonBase that has the CommandParameter</param>
        /// <returns>The value of the property</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static object GetCommandParameter(ButtonBase buttonBase)
        {
            return buttonBase.GetValue(CommandParameterProperty);
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ButtonBase buttonBase = dependencyObject as ButtonBase;
            if (buttonBase != null)
            {
                ButtonBaseClickCommandBehavior behavior = GetOrCreateBehavior(buttonBase);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ButtonBase buttonBase = dependencyObject as ButtonBase;
            if (buttonBase != null)
            {
                ButtonBaseClickCommandBehavior behavior = GetOrCreateBehavior(buttonBase);
                behavior.CommandParameter = e.NewValue;
            }
        }

        private static ButtonBaseClickCommandBehavior GetOrCreateBehavior(ButtonBase buttonBase)
        {
            ButtonBaseClickCommandBehavior behavior = buttonBase.GetValue(ClickCommandBehaviorProperty) as ButtonBaseClickCommandBehavior;
            if (behavior == null)
            {
                behavior = new ButtonBaseClickCommandBehavior(buttonBase);
                buttonBase.SetValue(ClickCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}
