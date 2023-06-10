using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Views.Converters
{
    /// <summary>
    /// Convertisseur de type pour convertir un entier en chaîne de caractères avec un signe.
    /// </summary>
    public class Int2StringConverters : IValueConverter
    {
        /// <summary>
        /// Convertit un entier en chaîne de caractères avec un signe.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res;
            Debug.WriteLine(parameter);
            bool NewParameter = (bool)parameter;
            if (NewParameter)
                res = "-" + (string)value;
            else
                res = "+" + (string)value;
            return res;
        }

        /// <summary>
        /// Convertit une chaîne de caractères en entier (non implémenté).
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
