using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PromotionMap
{
    public interface IPromoMapView
    {

        void SetItemsDataContext(object data);
       // void SetFilterBtnDataContext(object command);
        
        void SetSelectBtnDataContext(object command);
        void SetSelectAllBtnDataContext(object command);

        void SetPromoMapDataContext(object data);
        
        void SetSelectedItemCursor();

        void SetMoveToFirstBtnDataContext(object command);
        void SetMoveToPreviousBtnDataContext(object command);
        void SetMoveToNextBtnDataContext(object command);
        void SetMoveToLastBtnDataContext(object command);

        void SetDeleteBtnDataContext(object command);
        void SetCancelBtnDataContext(object command);
        void SetRevertBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

        string Organization { get; set; }
        int PromoNumber { get; set; }
        string PromoName { get; set; }
        string ValidDateFrom { get; set; }
        string ValidDateTo { get; set; }

        //string GetFilterCriteria();
        //string GetFilterText();
              
    }
}
