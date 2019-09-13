using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class DecimalAggregateField : AggregateField
    {
        decimal value;
        public DecimalAggregateField(int ordinal) : base(ordinal) { }
        public override void UpdateValue(IDataReader reader)
        {
            try
            {
                decimal d = reader.GetDecimal(ordinal);
                switch (Aggregate)
                {
                    case AggegateType.Sum: value += d; break;
                    default: throw new NotImplementedException();
                }
            }
            catch (Exception e)
            {
            }
        }

        public override object Value
        {
            get { return value; }
        }

    }
}
