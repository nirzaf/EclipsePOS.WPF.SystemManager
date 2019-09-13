using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.EmployeeRoles
{
    public interface IEmployeeRolesView
    {
        void SetEmployeeRolesDataContext(object data);
        void SetEmployeeRoleEventDataContext(IEnumerable data);
        void SetOrganizationDataContext(IEnumerable data);
        void SetManagedPosEventDataContext(IEnumerable data);
       
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        void SetAddEventDataContext(object command);
        void SetRemoveEventDataContext(object command);

        string SelectedRoleEvent();
        string SelectedOrganizationId();

        void SetFocusToRoleName();

        void MoveToNextManagedEvent();
        void RemoveSelectedRoleEvent();

        void SetColumnsEnabled(bool flag);

    }
}
