using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot
{
    public interface IMenuRoot
    {
        void SetMenuRootDataContext(object data);
        void SetPosKeyDataContext(IEnumerable data);
        
        //void SetMenuPanelsDataContext(IEnumerable data);
        void SetPosConfigDataContext(IEnumerable data);
        
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetAddBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        void SetAddPosKeyBtnDataContext(object command);
        void SetChangePosKeyBtnDataContext(object command);
        void SetDeletePosKeyBtnDataContext(object command);

        int SelectedConfigNo();

        void SetFocusToFirstElement();
    }
}
