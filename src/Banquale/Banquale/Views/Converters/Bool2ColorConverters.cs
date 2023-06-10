using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Views.Converters
{
    /// <summary>
    /// Convertisseur de type pour convertir une valeur booléenne en couleur.
    /// </summary>
    public class Bool2ColorConverters : IValueConverter
    {
        /// <summary>
        /// Convertit une valeur booléenne en couleur.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool NewValue = (bool)value;

            if (NewValue == true)
                return Colors.Red;
            return Colors.Green;
        }

        /// <summary>
        /// Convertit une couleur en valeur booléenne (non implémenté).
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
