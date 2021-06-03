using MEF.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MEF.App {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        [Import("simple", typeof(ICalculator))]
        public Lazy<ICalculator> calculator;

        [ImportMany]
        IEnumerable<IOpcion> opciones;


        public MainWindow() {
            InitializeComponent();
            Importar();
            GenerarMenu();
            Console.WriteLine(calculator.IsValueCreated ? "Creado" : "Sin crear");
            Console.WriteLine($"Suma: {calculator.Value.Calculate("1+1")}");
            Console.WriteLine($"Resta: {calculator.Value.Calculate("1-1")}");
            Console.WriteLine($"Multiplica: {calculator.Value.Calculate("1*1")}");
            Console.WriteLine(calculator.IsValueCreated ? "Creado" : "Sin crear");
        }

        private void GenerarMenu() {
            foreach(var op in opciones) {
                Button btn = new Button();
                btn.Content = op.Menu;
                btn.Click += (s, e) => pnHost.Content = op.GetUserControl();
                pnMenu.Children.Add(btn);
            }
            // pnHost.Content = XamlReader.Parse("<Button Content=\"Algo\" Width=\"75\"/>");
        }

        private void Importar() {
            var catalog = new AggregateCatalog();
            var container = new CompositionContainer(new ApplicationCatalog());
            try {
                container.ComposeParts(this);
            } catch (CompositionException compositionException) {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
