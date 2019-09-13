using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummaryBySalesperson
{
    public interface ISalesPersonView
    {

        void SetOrganizationFromDataContext(IEnumerable data);
        void SetOrganizationToDataContext(IEnumerable data);

        void SetEmployeeFromDataContext(IEnumerable data);
        void SetEmployeeToDataContext(IEnumerable data);


        void SetRetailStoreFromDataContext(IEnumerable data);
        void SetRetailStoreToDataContext(IEnumerable data);

        void SetRunBtnDataContext(object command);
        void SetSaveBtnDataContext(object command);

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

        string EmployeeFrom
        {
            get;
        }

        string EmployeeTo
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
