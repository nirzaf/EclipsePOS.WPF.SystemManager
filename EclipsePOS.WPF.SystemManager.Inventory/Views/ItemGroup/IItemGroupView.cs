using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.ItemGroup
{
    public interface IItemGroupView
    {

        void SetItemGroupDataContext(object data);
        void SetOrganizationDataContext(IEnumerable data);
        void SetSelectedItemCursor();

        void SetFocusToFirstInputField();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        string SelectedOrganizationNo();
        void SetColumnsEnabled(bool flag);

    }
}
