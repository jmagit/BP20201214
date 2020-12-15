using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
    public class Calculadora {
        private string Saluda(string nombre) {
            if (nombre != null && nombre.ToUpper() != null && nombre.ToUpper().Length == 0)
                return "nada";
            if(nombre?.ToUpper()?.Length == 0)
                return "nada";
            // var rslt = (nombre ?? "").Length; // nombre != null ? nombre : ""
            var rslt = (nombre ?? throw new Exception("Algo")).Length;
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
