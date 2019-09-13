using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaskNavigator
{
    class PosSetupTaskNavigatorViewPresenter
    {
        public PosSetupTaskNavigatorViewPresenter(IPosSetupTaskNavigatorView postSetupNavigator)
        {
            View = postSetupNavigator;
           // Commands.ShowPosSetupTaskView.RegisterCommand(Commands.ShowPosSetupTaskView);

        }

        public IPosSetupTaskNavigatorView View
        {
            get;
            private set;
        }

        public void ShowView()
        {
            
        }

    }
}
