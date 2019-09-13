using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Stock
{
    public interface IStockDiaryView
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

        string SelectedOrganizationNo();
        void SetFocusToFirstInputField();

        DateTime GetSelectedDate();
        string GetSKU();
        string GetReference();
        double GetQuantity();
        int GetTransactionType();

        void InitInput();



    }
}
