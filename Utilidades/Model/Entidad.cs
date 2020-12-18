using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Util;
using System.ComponentModel;

namespace Utilidades.Model {
    public class Entidad : INotifyPropertyChanged {
        private string nombre;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nombre {
            get => nombre;
            set {
                if (value != nombre) return;
                if (ValidacionesString.EstaVacia(value) || value.TieneLongitudMaxima(50))
                    throw new Exception("...");
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

    }
}
