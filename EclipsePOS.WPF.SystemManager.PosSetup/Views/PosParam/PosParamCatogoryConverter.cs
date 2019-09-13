using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam
{
    [ValueConversion(typeof(int), typeof(String))]
    public class PosParamCatogoryConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int catogory = (int)value;
            switch (catogory)
            {
                case 1:
                    return "Line display";
                case 2:
                        return "Receipt print";
                case 3:
                        return "POS Workbench display texts";
                case 4:
                        return "POS Workbench operator prompts";
                case 5:
                        return "Terminal report";
                case 6:
                        return "Miscellaneous";
                default:
                        return "Unclassified";
            }
                        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();


            if (strValue.CompareTo("Line display") == 1)
            {
                return 1;
            }

            if (strValue.CompareTo("Receipt print") == 1)
            {
                return 2;
            }

            if (strValue.CompareTo("POS Workbench display texts") == 1)
            {
                return 3;
            }
            if (strValue.CompareTo("POS Workbench operator prompts") == 1)
            {
                return 4;
            }
            if (strValue.CompareTo("Terminal report") == 1)
            {
                return 5;
            }
            if (strValue.CompareTo("Miscellaneous") == 1)
            {
                return 6;
            }
            if (strValue.CompareTo("Unclassified")==1)
            {
                return 0;
            }

            return 0;
        }


    }
}
