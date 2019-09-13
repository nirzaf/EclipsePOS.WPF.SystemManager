using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Employee
{
    public interface IEmployeeView
    {
        void SetEmployeeDataContext(object data);
        void SetEmployeeRoleDataContext(IEnumerable data);
        void SetOrganizationDataContext(IEnumerable data);
         
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

      
        void SetFocusToFirstElement();

        string SelectedOrganizationNo();

        void SetColumnsEnabled(bool flag);
    }
}
