using MEF.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.ExtensionB {
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    class Multiplica : IOperation {
        public int Operate(int left, int right) {
            return left * right;
        }
    }
}
