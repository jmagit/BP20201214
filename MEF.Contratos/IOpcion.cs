using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MEF.Contratos {
    public interface IOpcion {
        string Menu { get; }
        UserControl GetUserControl();
    }
}
