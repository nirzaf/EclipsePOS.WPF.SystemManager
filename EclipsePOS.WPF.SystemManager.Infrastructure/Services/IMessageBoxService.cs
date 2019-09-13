using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
 

namespace EclipsePOS.WPF.SystemManager.Infrastructure.Services
{
    interface IMessageBoxService
    {   
        MessageBoxResult Show(string text);
        MessageBoxResult Show(string text, string caption);
        MessageBoxResult Show(string text, string caption, MessageBoxButton buttons);
        MessageBoxResult Show(string text, string caption, MessageBoxButton buttons, MessageBoxImage icon);
    }
}
