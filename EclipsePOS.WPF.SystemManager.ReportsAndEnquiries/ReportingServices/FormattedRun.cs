using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;


[assembly: XmlnsDefinition("http://www.eclipse_software.com.sg/WPF", "EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices")]
namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices
{
    public class FormattedRun:Run
    {

        object data;

        public object Data
        {
            get { return data; }
            set { data = value; formatText(); } 
        }       
        string format;

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        string propertyName;

        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value;  }
        }
        

      
        void formatText()
        {
            if (data != null )
            {
                if (format != null)      {
                    if (data.GetType() == typeof(DateTime))
                    {
                        DateTime dt = Convert.ToDateTime(data);
                        this.Text = dt.ToString(format);
                        return;
                    }
                    else if (data.GetType() == typeof(Decimal))
                    {
                        Decimal dt = Convert.ToDecimal(data);
                        this.Text = dt.ToString(format);
                        
                        return;
                    }
                }
                else
                    this.Text = data.ToString();
            }
            else
                Text = "";
        }

    }
}
