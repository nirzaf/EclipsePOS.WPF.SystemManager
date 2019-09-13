using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Wpf.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig
{
    public class PosConfigViewPresenter
    {
        private IPosConfigView _view;
        private CollectionView _colView;

        //private EclipsePOS.WPF.SystemManager.Data.DepartmentDataSet deptData;


        //private EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.DepartmentDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public IPosConfigView View
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

    }
}
