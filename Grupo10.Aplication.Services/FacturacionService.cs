using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo10.Aplication.Contract;
using Grupo10.Domain.Contracts;
using Grupo10.Domain.Contracts.Services;

namespace Grupo10.Aplication.Services {
    public class FacturacionService : IFacturacionService {
        private IExpedienteDomainService srvExpediente;
        private IPDFGenerate genDoc;

        public void FacturarPendiete() {
            // srvExpediente.
            // genDoc.GenerarExpediente(...);
        }

    }
}
