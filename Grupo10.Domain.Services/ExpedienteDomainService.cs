using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo10.Domain.Contracts.Services;
using Grupo10.Domain.Contracts.Repositories;
using Grupo10.Domain.Core.Services;
using Grupo10.Domain.Entities;

namespace Grupo10.Domain.Services {
    public class ExpedienteDomainService: DomainService<Expediente>, IExpedienteDomainService {
        IExpedienteRepository repository;

        public ExpedienteDomainService(IExpedienteRepository repository):base(repository) { }
        
    }
}
