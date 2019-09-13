using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.TaskNavigator
{
    class InventoryTaskNavigatorViewPresenter
    {

        public InventoryTaskNavigatorViewPresenter(IInventoryTaskNavigatorView inventoryTaskNavigator)
        {
            View = inventoryTaskNavigator;
        }

        public IInventoryTaskNavigatorView View
        {
            get;
            private set;
        }

    }
}
