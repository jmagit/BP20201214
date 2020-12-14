using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
    public class Calculadora {
        private string Saluda(string nombre) {
            return $"Hola {nombre}";
        }

        public double Suma(double a, double b) {
            return a + b;
        }
        public double Resta(double a, double b) {
            return a - b;
        }
        public double Multiplica(double a, double b) {
            return a * b;
        }
        public double Divide(double a, double b) {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

        public double Raiz(double a) {
            return Math.Sqrt(a);
        }
    }
}
