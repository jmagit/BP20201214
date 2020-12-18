using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo10.Domain.Core.Contracts;

namespace Grupo10.Domain.Core.Services {
    public abstract class DomainService<TEntity> : IDomainService<TEntity> where TEntity : IEntity {
        protected IRepository<TEntity> Repository { get; private set; }
        public DomainService(IRepository<TEntity> repository) {
            this.Repository = repository; 
        }

        public void add(TEntity item) {
            if(item.IsValid())
                Repository.add(item);
        }

        public void modify(TEntity item) {
            if (item.IsValid())
                Repository.modify(item);
        }

        public void delete(TEntity item) {
            if (item.IsValid())
                Repository.delete(item);
        }
    }
}
