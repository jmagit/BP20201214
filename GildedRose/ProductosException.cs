using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose {
    public class ProductosException : Exception {
        public ProductosException(string message) : base(message) {
        }

        public ProductosException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
