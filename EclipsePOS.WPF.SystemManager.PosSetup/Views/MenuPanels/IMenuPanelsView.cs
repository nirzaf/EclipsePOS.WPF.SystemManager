﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuPanels
{
    public interface IMenuPanelsView
    {
        void SetMenuPanelsDataContext(object data);
       // void SetConfigNoDataContext(IEnumerable data);

        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);
    }
}
