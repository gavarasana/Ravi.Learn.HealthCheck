using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravi.Learn.HealthCheck.Books.Entities
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(book => book.CreatedById).IsRequired().HasField("CreatedByKey");
            builder.Property(book => book.CreatedOn).IsRequired();
            builder.Property(book => book.CreatedById).HasField("UpdatedByKey");
            builder.Property(book => book.CreatedOn);
        }
    }
}
