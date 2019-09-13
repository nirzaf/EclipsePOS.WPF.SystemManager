using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels
{
    public class PageDefinition
    {

        Size margin;

        public Size Margin
        {
            get { return margin; }
            set { margin = value; }
        }

        string headerTemplate;

        public string HeaderTemplate
        {
            get { return headerTemplate; }
            set { headerTemplate = value; }
        }

        double headerHeight;

        public double HeaderHeight
        {
            get
            {
                if (headerHeight < 0)
                    return 0;
                return headerHeight;
            }
            set { headerHeight = value; }
        }

        double footerHeight;

        public double FooterHeight
        {
            get
            {
                if (footerHeight < 0)
                    return 0;
                return footerHeight;
            }
            set { footerHeight = value; }
        }


        string footerTemplate;

        public string FooterTemplate
        {
            get { return footerTemplate; }
            set { footerTemplate = value; }
        }

    }
}
