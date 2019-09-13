using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Wpf.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.Inventory.Views.DefaultStoreGroup
{
    public class DefaultStoreGroupViewPresenter
    {
        private EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSet storeGroupData;
        private EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.RetailStoreGroupTableAdapter taStoreGroupData;

        private IDefaultStoreGroupView _view;
        public IDefaultStoreGroupView View
        {
            set
            {
                _view = value;
            }
            get
            {
                return _view;
            }
        }

        public void OnShowDefaultStoreGroup()
        {
            storeGroupData = new EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSet();
            taStoreGroupData = new EclipsePOS.WPF.SystemManager.Data.StoreGroupDataSetTableAdapters.RetailStoreGroupTableAdapter();
            taStoreGroupData.Fill(storeGroupData.RetailStoreGroup);
            View.SetStoreGroupDataContext(storeGroupData.RetailStoreGroup);
        }


        
    }
}
