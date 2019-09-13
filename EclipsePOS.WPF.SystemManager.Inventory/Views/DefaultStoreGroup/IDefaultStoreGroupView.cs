using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.DefaultStoreGroup
{
    public interface IDefaultStoreGroupView
    {
        void SetStoreGroupDataContext(IEnumerable data);
    }
}
