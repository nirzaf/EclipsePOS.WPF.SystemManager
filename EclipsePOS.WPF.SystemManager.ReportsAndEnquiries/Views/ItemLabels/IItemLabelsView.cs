using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels
{
    public interface IItemLabelsView
    {
        void SetItemsDataContext(object data);
        void SetOrganizationDataContext(IEnumerable data);
        void SetFilterBtnDataContext(object command);
        void SetSelectBtnDataContext(object command);
        void SetSelectAllBtnDataContext(object command);
        void SetRunBtnDataContext(object command);
        void AddSelectedItemLabel();
        void AddAllItemLabels();
        int NumberOfBarcodesToPrint();
        List<WPFBarcode> LabelData();
        int NumberAcross{get;}
        int NumberDown{get;}
        double TopMargin { get; }
        double SideMargin{get;}

        string GetFilterCriteria();
        string GetFilterText();

        void SetSelectedItemCursor();

        void StartSyncAnimation();
        void EndSyncAnimation();

        void SaveSelections();


    }
}
