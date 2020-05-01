using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Models.Response
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }        
    }
}
