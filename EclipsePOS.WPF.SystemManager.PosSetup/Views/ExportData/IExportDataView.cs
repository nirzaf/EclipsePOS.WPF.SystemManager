using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.ExportData
{
    public interface IExportDataView
    {
        int ShowInputDialog();

        void SetOKBtnDataContext(object command);
        void SetFolderPickerBtnDataContext(object command);
        void CloseDialog();
        void StartBusyIndicator();
        void EndBusyIndicator();
        string OutputFolderPath();
        void SetPath(string path);
        
    }
}
