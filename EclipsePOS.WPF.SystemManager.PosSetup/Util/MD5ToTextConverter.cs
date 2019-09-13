using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Security.Cryptography;
using System.Globalization;
 


namespace EclipsePOS.WPF.SystemManager.PosSetup.Util
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class MD5ToTextConverter : IValueConverter
    {
        public static MD5ToTextConverter Instance = new MD5ToTextConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotSupportedException("Not implimented yet");

            byte[] input = ASCIIEncoding.ASCII.GetBytes(value.ToString());
            byte[] output = MD5.Create().ComputeHash(input);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output.Length; i++)
            {
                sb.Append(output[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
