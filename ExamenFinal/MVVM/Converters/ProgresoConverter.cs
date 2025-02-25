using ExamenFinal.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.MVVM.Converters
{
    public class ProgresoConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var PorcentajeLeido = (int)value;

            if (PorcentajeLeido == null)
            {
                //Retorno este color por si es null
                return Colors.LightBlue;
            }

            if(PorcentajeLeido < 30)
            {
                return Colors.Red;
            }
            else if(PorcentajeLeido < 60)
            {
                return Colors.Orange;
            }
            else
            {
                return Colors.Green;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
