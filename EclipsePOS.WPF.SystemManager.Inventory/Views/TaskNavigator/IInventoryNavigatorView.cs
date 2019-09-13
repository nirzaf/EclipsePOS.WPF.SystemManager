using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.TaskNavigator
{
    public interface IInventoryNavigatorView
    {
        void SetDataContextDeptView(ICommand command);
        void SetDataContextItemGroupView(ICommand command);
        void SetDataContextItemListView(ICommand command);
        void SetDataContextStockDiaryView(ICommand command);
        //void SetDataContextStoreGroupView(ICommand command);
    }
}
