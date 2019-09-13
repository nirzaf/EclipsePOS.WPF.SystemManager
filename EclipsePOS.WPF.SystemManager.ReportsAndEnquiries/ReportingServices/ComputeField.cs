using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public abstract class ComputeField
    {
        public abstract void UpdateValue(IDataReader reader);

        public abstract object Value { get; }

    }

    /// <summary>
    /// Supported aggregate types
    /// </summary>
    public enum AggegateType
    {
        None,
        Sum,
        Count,
        Min,
        Max
    }

}
