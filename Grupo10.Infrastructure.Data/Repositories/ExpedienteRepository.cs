using Grupo10.Domain.Contracts.Repositories;
using Grupo10.Domain.Core.Contracts;
using Grupo10.Domain.Entities;
using Grupo10.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Infrastructure.Data.Repositories {
    public class ExpedienteRepository : Repository<Expediente>, IExpedienteRepository {
        public ExpedienteRepository(IUnitOfWork dbContext) : base(dbContext) { }
    }
}
