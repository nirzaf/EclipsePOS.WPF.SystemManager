using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data;
using EclipsePOS.WPF.SystemManager.Data;
using System.Collections;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization
{
    public interface IOrganizationView
    {
        void SetOrganizationDataContext(object data);
        void SetCurrencyDataContext(IEnumerable data);
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

      //  void NotifySchemaChanges();
      //  void StartSyncAnimation();
      //  void EndSyncAnimation();
        void SetFocusToFirstElement();
        void SetColumnsEnabled(bool flag);
        
    }
}
