using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EclipsePOS.WPF.SystemManager.Inventory.Views.ItemList
{
    public interface IItemListView
    {

        void SetItemsDataContext(object data);
        void SetOrganizationDataContext(IEnumerable data);
       

        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object data);
        void SetMoveToPreviousBtnDataContext(object data);
        void SetMoveToNextBtnDataContext(object data);
        void SetMoveToLastBtnDataContext(object data);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        void SetDepartmentDataContext(IEnumerable data);
        void SetItemGroupDataContext(IEnumerable data);
        void SetTaxGroupDataContext(IEnumerable data);

        string SelectedOrganizationNo();

       
        void SetFocusToFirstInputField();
        void SetColumnsEnabled(bool flag);

    }

}
