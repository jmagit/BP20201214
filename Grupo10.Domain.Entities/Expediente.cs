using Grupo10.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo10.Domain.Entities {
    public partial class Expediente : IEntity {
        [Required]
        private int id;
        [Obsolete]
        public bool IsValid() {
            return true;
        }
    }
}
