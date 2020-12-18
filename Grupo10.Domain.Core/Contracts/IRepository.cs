using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo10.Domain.Core.Contracts {
    public interface IRepository<TEntity> where TEntity : IEntity {
        void add(TEntity item);
        void modify(TEntity item);
        void delete(TEntity item);
    }
}
