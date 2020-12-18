using Grupo10.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Aplication.Contract {
    public interface IPDFGenerate {
        void GenerarExpediente(Expediente item, string file);
    }
}
