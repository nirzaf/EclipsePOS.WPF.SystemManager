using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.SalesSummaryView
{
    public class SalesSummaryViewPresenter
    {
        ISalesSummaryView _view;

        public ISalesSummaryView View
        {
            set
            {
                _view = value;
            }
            get
            {
                return _view;
            }
        }



    }
}
