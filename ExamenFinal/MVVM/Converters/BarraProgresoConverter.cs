using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.MVVM.Converters
{
    public class BarraProgresoConverter : IValueConverter
    {
        //Sirve para pasar de los porcentajes a valores de 0 a 1
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0;
            }

            var valor = (int)value;

            double convertido = valor / 100.0;

            return convertido ;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
