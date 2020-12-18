using Aplication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.ViewModel {

    public class CalculadoraVM : ObservableBase {
        private double acumulado = 0;
        private char operacion = '+';
        private bool limpia = false;

        private string pantalla = "0";
        [DataMember]
        public string Pantalla {
            get => pantalla;
            set {
                if (pantalla != value) {
                    pantalla = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string resumen;
        [DataMember]
        public string Resumen {
            get => resumen;
            set {
                if (resumen != value) {
                    resumen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand Inicializar => new DelegateCommand(
            cmdArg => {
                acumulado = 0;
                operacion = '+';
                limpia = false;
                Pantalla = "0";
                Resumen = "";
            }
            );
        public DelegateCommand AñadirDigito => new DelegateCommand(
            cmdArg => {
                string dig = cmdArg.ToString();
                if (limpia || Pantalla == "0") {
                    Pantalla = dig;
                    limpia = false;
                } else
                    Pantalla += dig;
            }
            );
        public DelegateCommand AñadirComaDecimal => new DelegateCommand(
            cmdArg => {
                if (limpia || Pantalla == "0") {
                    Pantalla = "0,";
                    limpia = false;
                } else
                    if (!Pantalla.Contains(","))
                    Pantalla += ",";
            }
            );
        public DelegateCommand Borrar => new DelegateCommand(
            cmdArg => {
                if (limpia || Pantalla.Length < 2) {
                    Pantalla = "0";
                    limpia = false;
                } else
                    Pantalla = Pantalla.Remove(Pantalla.Length - 1);
            }
            );

        private void Calcula(string nuevaOp) {
            if (!"+-*/=".Contains(nuevaOp)) { return; }

            double operando = double.Parse(Pantalla);
            switch (operacion) {
                case '+':
                    acumulado += operando;
                    break;
                case '-':
                    acumulado -= operando;
                    break;
                case '*':
                    acumulado *= operando;
                    break;
                case '/':
                    acumulado /= operando;
                    break;
                case '=':
                    acumulado = operando;
                    break;
            }
            Resumen = operacion == '=' ? "" : $"{Resumen} {Pantalla} {nuevaOp}";
            Pantalla = acumulado.ToString();
            operacion = nuevaOp[0];
            limpia = true;
        }
        public DelegateCommand Operar => new DelegateCommand(
            cmdArg => {
                Calcula(cmdArg.ToString());
            }
            );
        public DelegateCommand CambiarSigno => new DelegateCommand(
            cmdArg => {
                double operando = double.Parse(Pantalla);
                operando = -operando;
                if (limpia) acumulado = -acumulado;
                Pantalla = operando.ToString();
            }
            );
    }

}
