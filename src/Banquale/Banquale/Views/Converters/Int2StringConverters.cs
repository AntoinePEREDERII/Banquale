using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Views.Converters
{
    public class Int2StringConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res;
            Debug.WriteLine(parameter);
            //return value.ToString();
            //if (parameter is not bool)
            //    return false;
            bool NewParameter = (bool)parameter;
            if (NewParameter)
                res = "-" + (string)value;
            else
                res = "+" + (string)value;
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
