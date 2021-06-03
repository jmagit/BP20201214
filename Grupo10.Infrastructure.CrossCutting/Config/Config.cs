using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Infrastructure.CrossCutting.Config {
    public class Config {
        public void Load(string idCliente) {
            this.Calcula = (i) => true;
            (new Config()).Calcula(4);
            typeof(Config).GetMethod("algo");

            if ((new String[] { "123", "1123", "2343" }).Contains(idCliente)) { }
            if (Compara(idCliente, "123", "1123", "2343" )) { }
            if("|123|1123|2343|".Contains($"|{idCliente}|")) {

            }
            if(idCliente == "123" || idCliente == "1123" || idCliente == "2343") {

            }

        }

        bool Compara(string id, params string[] codigos) {
            return codigos.Contains(id);
        }
        public bool TieneAlgo(string idCliente) { 
            return Compara(idCliente, "123", "1123", "2343"); 
        }

        public bool TieneFacturacion { get; set; } = true;

        public Func<int, bool> Calcula { get; set; }
    }
}
