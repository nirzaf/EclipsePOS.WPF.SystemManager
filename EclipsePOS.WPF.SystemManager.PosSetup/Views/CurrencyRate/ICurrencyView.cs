using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.CurrencyRate
{
    public interface ICurrencyView
    {
        void SetCurrencyDataContext(object data);
        void SetSourceCurrencyCodeDataContext(IEnumerable data);
        void SetHomeCurrencyCodeDataContext(IEnumerable data);
       
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

        void SetColumnsEnabled(bool flag);


  
    }
}
