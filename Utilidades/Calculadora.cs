using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
    public interface MeVale { }
    public interface ICalculadoraBasica {
        double Resta(double a, double b);
        double Suma(double a, double b);
        double Divide(double a, double b);
        double Multiplica(double a, double b);
        event Action<object, EventArgs> Notifica;
    }
    public interface IExponenciacion<T> {
        T Cuadrado(T a);
        T Raiz(T a);
    }

    public interface ICalculadora : ICalculadoraBasica, IExponenciacion<double> {
        double Otra(double a);
    }

    public class Calculadora : MeVale, ICalculadora {
        private string Saluda(string nombre) {
            if (nombre != null && nombre.ToUpper() != null && nombre.ToUpper().Length == 0)
                return "nada";
            if (nombre?.ToUpper()?.Length == 0)
                return "nada";
            // var rslt = (nombre ?? "").Length; // nombre != null ? nombre : ""
            var rslt = (nombre ?? throw new Exception("Algo")).Length;
            return $"Hola {nombre}";
            bool? b = true;
            //...
            if (b == true) { // Es nullable
                // TODO: Pendiente de hacer
                b = false;
            }
            string cliente = "234"; // "," + cliente + ","
            if (",1234,2345,234,4333,".IndexOf($",{cliente},") == -1) { // no encontrado

            }
            if ((new string[] { "1234", "2345", "334", "4333" }).Contains(cliente)) { // no encontrado

            }
        }
        private double resultado;

        public event Action<object, EventArgs> Notifica;

        protected void OnNotifica(EventArgs e) {
            if (Notifica != null) {
                Notifica(this, e);
            }

        }

        [Obsolete]
        public double Suma(double a, double b) {
            var e = new CancelEventArgs();
            OnNotifica(e);
            if (e.Cancel) {
                return 0;
            }
            return a + b;
        }
        public double Resta(double a, double b) {
            return a - b;
        }
        public virtual double Multiplica(double a, double b) {
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
        public virtual double Cuadrado(double a) {
            return Multiplica(a, a);
        }
        public virtual double Otra(double a) {
            return Cuadrado(a);
        }


    }

    public class CalculadoraCientifica : Calculadora {
        public override double Multiplica(double a, double b) {
            return base.Multiplica(a, b);
        }
        public new double Cuadrado(double a) {

            return Multiplica(a, a);
        }

    }

    public class CalculadoraAjena {
        public double Plus(double a, double b) {
            return a + b;
        }

    }

    public class OtraCalculadora : CalculadoraAjena, ICalculadora {
        public event Action<object, EventArgs> Notifica;

        public double Cuadrado(double a) {
            throw new NotImplementedException();
        }

        public double Divide(double a, double b) {
            throw new NotImplementedException();
        }

        public double Multiplica(double a, double b) {
            throw new NotImplementedException();
        }

        public double Otra(double a) {
            throw new NotImplementedException();
        }

        public double Raiz(double a) {
            throw new NotImplementedException();
        }

        public double Resta(double a, double b) {
            throw new NotImplementedException();
        }

        public double Suma(double a, double b) {
            return base.Plus(a, b);
        }
    }
}
