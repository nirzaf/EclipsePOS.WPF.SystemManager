using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class ReportDefinition
    {
        string headerTemplate;

        public string HeaderTemplate
        {
            get { return headerTemplate; }
            set { headerTemplate = value; }
        }

        PageDefinition page;

        public PageDefinition Page
        {
            get
            {
                if (page == null)
                    page = new PageDefinition();

                return page;
            }
            set { page = value; }
        }

        string footerTemplate;

        public string FooterTemplate
        {
            get { return footerTemplate; }
            set { footerTemplate = value; }
        }


        string itemTemplate;

        public string ItemTemplate
        {
            get { return itemTemplate; }
            set { itemTemplate = value; }
        }


        string tableDefinition;

        public string TableDefinition
        {
            get { return tableDefinition; }
            set { tableDefinition = value; }
        }



        List<GroupDefinition> groups;

        public List<GroupDefinition> Groups
        {
            get
            {
              //  if (groups == null)
              //      groups = new List<GroupDefinition>();

                return groups;
            }
            set
            {
                groups = value;
            }


        }

        private string name;

        public string ReportName
        {
            get { return name; }
            set { name = value; }
        }
    }

    
    
}
