using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig
{
    public interface IPosConfigurationsView
    {
        void SetPosConfigDataContext(object data);
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

    }
}
