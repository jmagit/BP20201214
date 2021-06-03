using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace MEF.App {
    public class Entidad : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propiedad) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        private int id;

        public int Id {
            get { return id; } 
            set {
                if (id != value) {
                    id = value;
                    onPropertyChanged(nameof(Id));
                }
            }
        }
        private string nombre;

        public string Nombre {
            get { return nombre; }
            set {
                if (nombre != value) {
                    nombre = value;
                    onPropertyChanged(nameof(Nombre));
                }
            }
        }
        private string apellidos;

        public string Apellidos {
            get { return apellidos; }
            set {
                if (apellidos != value) {
                    apellidos = value;
                    onPropertyChanged(nameof(Apellidos));
                }
            }
        }
    }

    public class ViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propiedad) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        private Entidad elemento;

        public ViewModel() {
            load = new DelegateCommand(o => {
                Elemento = new Entidad { Id = 0, Nombre = "Pepito", Apellidos = "Grillo" };
                onPropertyChanged(nameof(Borra));
                load = Borra;
                onPropertyChanged(nameof(Load));
            });
        }
        public Entidad Elemento {
            get { return elemento; }
            set {
                if (elemento != value) {
                    elemento = value;
                    onPropertyChanged(nameof(Elemento));
                }
            }
        }

        private bool ver = true;
        public bool Ver { get => ver; }
        public DelegateCommand Cambia {
            get {
                return new DelegateCommand(o => {
                    ver = !ver;
                    onPropertyChanged(nameof(Ver));
                });
            }
        }

        private DelegateCommand load;
        public DelegateCommand Load {
            get {
                return load;
            }
        }
        public DelegateCommand Borra {
            get {
                return new DelegateCommand(cmdParam => {
                    this.Elemento.Nombre = "";
                    this.Elemento.Apellidos = "";
                },
                cmdParam => this.Elemento != null
                );
            }
        }
    }

}
