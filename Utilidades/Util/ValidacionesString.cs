using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Util {
    public static class ValidacionesString {
        public static bool EstaVacia(this string cadena) {
            return String.IsNullOrWhiteSpace(cadena);
        }
        public static bool NoEstaVacia(this string cadena) {
            return !EstaVacia(cadena);
        }
        public static bool TieneLongitudMaxima(this string cadena, int maxlen) {
            return EstaVacia(cadena) || cadena.Length <= maxlen;
        }


    }
}
