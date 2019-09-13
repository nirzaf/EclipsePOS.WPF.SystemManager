using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.NewDataSourcePrompt
{
    public interface INewDataSource
    {
        bool IncludeSampleData{get; set;}
        CreateMode Mode{  get;  set; }
        void SetOKBtnDataContext(object command);
        bool FieldEmpty();
        string ServerInstance { set; get; }
        string DatabaseName { set; get; }
        string UserName { set; get; }
        string Password { set; get; }
        int Authentication { set; get; }
        void StartSyncAnimation();
        void EndSyncAnimation();
        void SetDataSourcePath();

    }

    public enum CreateMode
    {
        
        NewEmptyDatabase = 2,
        ExistingDatabase = 3
    }

    

}
