using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Domain.Core.Contracts {
    public interface IDomainService<TEntity> where TEntity : IEntity {
        void add(TEntity item);
        void modify(TEntity item);
        void delete(TEntity item);
    }
}
