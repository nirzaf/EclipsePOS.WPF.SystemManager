using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NavigatorDataSource
{
    public interface IDataSourceNavView
    {
         void SetNewDataBaseBtnDataContext(object command);
         void SetExistingDataBaseBtnDataContext(object command);
         void SetBackupDataBaseBtnDataContext(object command);
         void SetExportDataBtnDataContext(object command);
         void SetImportDataBtnDataContext(object command);
    }
}
