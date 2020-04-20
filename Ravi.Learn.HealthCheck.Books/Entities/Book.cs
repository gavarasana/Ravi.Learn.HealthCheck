using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Entities
{
    public class Book : BaseEntity
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
    }
}
