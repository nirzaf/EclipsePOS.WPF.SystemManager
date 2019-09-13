using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Xps.Packaging;
using System.Windows.Controls;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.XPSDoc
{
    public interface IXPSDocView
    {
        void DisplayDoc(XpsDocument doc);
        void SetSaveToDiskBtnDataContext(object command);

        DocumentViewer GetDocument { get; }
    }
}
