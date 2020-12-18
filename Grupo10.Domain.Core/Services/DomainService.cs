using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo10.Domain.Core.Contracts;

namespace Grupo10.Domain.Core.Services {
    public abstract class DomainService<TEntity> : IDomainService<TEntity> where TEntity : IEntity {
        IRepository<TEntity> repository;
        public DomainService(IRepository<TEntity> repository) {
            this.repository = repository; 
        }

        public void add(TEntity item) {
            repository.add(item);
        }

        public void modify(TEntity item) {
            repository.modify(item);
        }

        public void delete(TEntity item) {
            repository.delete(item);
        }
    }
}
