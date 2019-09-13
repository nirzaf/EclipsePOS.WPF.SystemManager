using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaxGroup
{
    public interface ITaxGroupView
    {
        void SetTaxGroupDataContext(object data);
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);
        void SetOrganizationDataContext(IEnumerable data);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        string SelectedOrganizationNo();

        void SetFocusToFirstElement();
        void SetColumnsEnabled(bool flag);

         
    }
}
