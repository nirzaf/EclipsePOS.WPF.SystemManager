using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Xps.Packaging;
using System.Collections;
using System.Windows.Documents;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesDetailByDate
{
    public interface ISalesDetailByDate
    {
        void SetOrganizationFromDataContext(IEnumerable data);
        void SetOrganizationToDataContext(IEnumerable data);

        void SetRetailStoreFromDataContext(IEnumerable data);
        void SetRetailStoreToDataContext(IEnumerable data);

        void SetRunBtnDataContext(object command);

        void StartSyncAnimation();
        void EndSyncAnimation();

        string StoreNoFrom
        {
            get;
        }
        
        string StoreNoTo
        {
            get;
        }

        string OrganizationNoFrom
        {
            get;
        }

        string OrganizationNoTo
        {
            get;
        }

        DateTime SalesDateFrom
        {
            get;
        }
        DateTime SalesDateTo
        {
            get;
        }

    }
}
