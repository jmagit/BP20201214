using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
    public class CalculadoraException : Exception {
        public CalculadoraException(string message) : base(message) {
        }

        public CalculadoraException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
