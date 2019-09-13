using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorOperations
{
    public interface IOperationsNavView
    {
        void SetEmployeeRolesContext(ICommand command);
        void SetEmployeeContext(ICommand command);
        void SetPromotionContext(ICommand command);
        void SetTableGroupContext(ICommand command);
        void SetTableContext(ICommand command);
        void SetTaxGroupContext(ICommand command);
        void SetTaxContext(ICommand command);
        void SetCurrencyCodeContext(ICommand command);
        void SetCurrencyRateContext(ICommand command);
        void SetCustomerContext(ICommand command);
        void SetUsersContext(ICommand command);
        void SetSurchargesContext(ICommand command);
        void SetCardMediaContext(ICommand command);
    }
}
