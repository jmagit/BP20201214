using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace MEF.App {
    /// <summary>
    /// Muestra el parámetro si el valor es nulo
    /// </summary>
    public class NullToStringConverter : IValueConverter {
        #region Miembros de IValueConverter

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null)
                return parameter.ToString();
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
