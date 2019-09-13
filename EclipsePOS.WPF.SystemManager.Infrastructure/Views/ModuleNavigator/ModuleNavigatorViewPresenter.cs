using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Controls;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.Infrastructure.Views.ModuleNavigator
{
    class ModuleNavigatorViewPresenter
    {
        
     
        public ModuleNavigatorViewPresenter(IModuleNavigatorView view)
        {
            View = view;
          
        }

        public IModuleNavigatorView View
        {
            get;
            private set;

        }
               
    }
}
