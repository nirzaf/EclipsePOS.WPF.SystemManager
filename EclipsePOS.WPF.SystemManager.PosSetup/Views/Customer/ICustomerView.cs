using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Customer
{
    public interface ICustomerView
    {
       
        void SetCustomerDataContext(object data);

        void SetOrganizationDataContext(IEnumerable data);
       // void SetCustomerDataContext(IEnumerable data);

        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        string SelectedOrganizationNo();

        void SetFocusToFirstElement();
        void SetColumnsEnabled(bool flag);
        

    }
}
