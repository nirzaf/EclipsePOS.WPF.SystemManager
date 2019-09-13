using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using EclipsePOS.WPF.SystemManager.Data;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Table
{
    [ValueConversion(typeof(int), typeof(int))]
    public class TableDisplayConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           // tableDetailsDataSet.table_detailsRow dataRow = value as tableDetailsDataSet.table_detailsRow;
           int index = int.Parse(value.ToString())/8;
            return index;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
