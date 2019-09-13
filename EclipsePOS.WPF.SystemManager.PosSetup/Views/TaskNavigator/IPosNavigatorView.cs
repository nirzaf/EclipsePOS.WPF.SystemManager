using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaskNavigator
{
    public interface IPosNavigatorView
    {
        void SetOrganizationContext(ICommand command);
        void SetPosConfigContext(ICommand command);
        void SetUsersContext(ICommand command);
        void SetStoreContext(ICommand command);
        void SetStationContext(ICommand command);
        void SetPosParamContext(ICommand command);
        void SetEmployeeRolesContext(ICommand command);
        void SetEmployeeContext(ICommand command);
        void SetPromotionContext(ICommand command);
        void SetMenuRootContext(ICommand command);
        void SetPosWorkbenchContext(ICommand command);
        void SetStartupSettingsContext(ICommand command);
        void SetTableGroupContext(ICommand command);
        void SetTableContext(ICommand command);
        void SetTaxGroupContext(ICommand command);
        void SetTaxContext(ICommand command);
        void SetCurrencyCodeContext(ICommand command);
        void SetCurrencyRateContext(ICommand command);
        void SetDataSourceContext(ICommand command);
        void SetCustomerContext(ICommand command);
    }
}
