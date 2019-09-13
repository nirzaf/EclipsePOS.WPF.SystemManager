using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;


[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class ReportData
    {
        DataTable rows;

        /// <summary>
        /// Represents the raw underlying data
        /// </summary>
        public DataTable Rows
        {
            get { return rows; }
        }

        List<GroupData> groups;

        /// <summary>
        /// Contains calculated values for each groupl level
        /// </summary>
        public List<GroupData> Groups
        {
            get { return groups; }
        }

        public ReportData(DataTable rows, List<GroupData> groups, GroupData reportGroup)
        {
            this.rows = rows;
            this.groups = groups;
            this.reportGroup = reportGroup;
        }

        private GroupData reportGroup;

        /// <summary>
        /// Contains calculated values for whole report
        /// </summary>
        public GroupData ReportGroup
        {
            get { return reportGroup; }

        }

    }
}
