using MEF.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.ExtensionA
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Resta : IOperation {
        public int Operate(int left, int right) {
            return left - right;
        }
    }
}
