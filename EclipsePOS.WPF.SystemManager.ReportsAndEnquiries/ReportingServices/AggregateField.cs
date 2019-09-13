using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

[assembly:XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public abstract class AggregateField : ComputeField

    {
        /// <summary>
        /// the ordinal position in the datasource
        /// </summary>
        protected int ordinal;

        public AggregateField(int ordinal)
        {
            this.ordinal = ordinal;
        }

        AggegateType aggregate = AggegateType.Sum;

        public AggegateType Aggregate
        {
            get { return aggregate; }
            set { aggregate = value; }
        }
    
    }
}
