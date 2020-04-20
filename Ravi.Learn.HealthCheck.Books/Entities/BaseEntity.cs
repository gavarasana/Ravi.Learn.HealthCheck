using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Entities
{
    public abstract class BaseEntity
    {
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
