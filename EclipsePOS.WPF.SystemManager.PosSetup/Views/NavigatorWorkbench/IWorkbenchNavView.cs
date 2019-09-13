using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorWorkbench
{
    public interface IWorkbenchNavView
    {
        void SetPosConfigContext(ICommand command);
        void SetPosParamContext(ICommand command);
        void SetMenuRootContext(ICommand command);
        void SetStartPosContext(ICommand command);
        
    }
}
