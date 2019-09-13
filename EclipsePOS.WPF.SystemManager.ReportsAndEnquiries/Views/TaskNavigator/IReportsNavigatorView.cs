using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.TaskNavigator
{
    public interface IReportsNavigatorView
    {
        void SetDataContextSalesSummaryReportView(ICommand command);
        void SetDataContextSalesDetailsByDate(ICommand command);
        void SetDataContextSalesBySalesPerson(ICommand command);
        void SetDataContextPaymentDetailsByDate(ICommand command);
        void SetDataContextPaymentSummary(ICommand command);
        void SetDataContextTaxDetails(ICommand command);
        void SetDataContextItemLabels(ICommand command);

        void SetDataContextInventory(ICommand command);
        void SetDataContextInventoryDetails(ICommand command);
        void SetDataContextStockDiary(ICommand command);
        void SetDataContextStockDiaryDetails(ICommand command);
    }
}
