using Grupo10.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Infrastructure.Data.Repositories {
    public class ExpedienteRepositoryMock : IExpedienteRepository {
        public void add(Domain.Entities.Expediente item) {
            Console.WriteLine("Soy falso");
        }

        public void delete(Domain.Entities.Expediente item) {
            throw new NotImplementedException();
        }

        public void modify(Domain.Entities.Expediente item) {
            throw new NotImplementedException();
        }
    }
}
