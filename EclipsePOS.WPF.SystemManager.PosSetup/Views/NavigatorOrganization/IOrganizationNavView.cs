using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOrganization
{
    public interface IOrganizationNavView
    {
        void SetOrganizationContext(ICommand command);
        void SetStoreContext(ICommand command);
        void SetStationContext(ICommand command);
        void SetStartupSettingsContext(ICommand command);
    }
}
