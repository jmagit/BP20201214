using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
    public class ElementosNumerico {
        public int clave { get; set; }
        public string literal { get; set; }
    }
    public class ElementosCaracter {
        public char clave { get; set; }
        public string literal { get; set; }
    }

    public class ElementosCadena {
        public string clave { get; set; }
        public string literal { get; set; }
    }

    public class CualquierElementos {
        public object clave { get; set; }
        public string literal { get; set; }
    }

    public class Elementos<T> {
        public T Clave { get; private set; }
        public string Literal { get; private set; }
        public Elementos(T clave, string literal) {
            Clave = clave;
            Literal = literal;
        }
    }

}
