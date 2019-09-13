using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class GroupDefinition
    {
        string headerTemplate;

        public string HeaderTemplate
        {
            get { return headerTemplate; }
            set { headerTemplate = value; }
        }


        string footerTemplate;

        public string FooterTemplate
        {
            get { return footerTemplate; }
            set { footerTemplate = value; }
        }

        bool newPageOnGroupBreak;

        public bool NewPageOnGroupBreak
        {
            get { return newPageOnGroupBreak; }
            set { newPageOnGroupBreak = value; }
        }

        bool resetPageNumberOnGroupBreak;

        public bool ResetPageNumberOnGroupBreak
        {
            get { return resetPageNumberOnGroupBreak; }
            set { resetPageNumberOnGroupBreak = value; }
        }

    }

}
