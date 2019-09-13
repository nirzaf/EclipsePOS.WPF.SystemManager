using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Collections;
using System.Data;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot
{
    [ValueConversion(typeof(DataRowView), typeof(String))]
    public class PanelIdToNameConverter:IValueConverter        
    {
                
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           // int panelID = int.Parse(value.ToString());
            return "testing";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();
            return "1";
        }



    }
}
