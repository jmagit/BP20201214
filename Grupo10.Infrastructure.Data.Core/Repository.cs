using Grupo10.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Infrastructure.Data.Core {
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity {
        private IUnitOfWork dbContext;

        public Repository(IUnitOfWork dbContext) {
            this.dbContext = dbContext;  
        }

        public virtual void add(TEntity item) {
            throw new NotImplementedException();
        }

        public virtual void delete(TEntity item) {
            throw new NotImplementedException();
        }

        public virtual void modify(TEntity item) {
            throw new NotImplementedException();
        }
    }
}
