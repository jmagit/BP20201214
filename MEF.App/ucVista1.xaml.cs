using MEF.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MEF.App {
    [Export(typeof(IOpcion))]
    public class ucVista1Opcion : IOpcion {
        public string Menu => "Opcion 1";

        public UserControl GetUserControl() {
            return new ucVista1();
        }
    }

    /// <summary>
    /// Lógica de interacción para ucVista1.xaml
    /// </summary>
    public partial class ucVista1 : UserControl {
        public ucVista1() {
            InitializeComponent();
        }
    }
}
