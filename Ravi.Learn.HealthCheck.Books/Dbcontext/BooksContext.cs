using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.EntityMappings;

namespace Ravi.Learn.HealthCheck.Books.Dbcontext
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions options) : base(options)
        {

        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapping());
        }
    }
}
