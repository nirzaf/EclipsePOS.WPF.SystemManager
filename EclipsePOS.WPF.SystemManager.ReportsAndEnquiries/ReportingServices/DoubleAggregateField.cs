using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]


namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class DoubleAggregateField : AggregateField
    {

        double value;
        public DoubleAggregateField(int ordinal) : base(ordinal) { }

        public override void UpdateValue(IDataReader reader)
        {
            try
            {
                double d = reader.GetDouble(ordinal);
                switch (Aggregate)
                {
                    case AggegateType.Sum: value += d; break;
                    default: throw new NotImplementedException();
                }
            }
            catch
            {
            }

            
        }

        public override object Value
        {
            get { return value; }
        }

    }
}
