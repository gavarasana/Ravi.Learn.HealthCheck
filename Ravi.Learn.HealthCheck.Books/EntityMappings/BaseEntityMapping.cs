using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ravi.Learn.HealthCheck.Books.Entities;

namespace Ravi.Learn.HealthCheck.Books.EntityMappings
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(book => book.CreatedById).IsRequired().HasColumnName("CreatedByKey");
            builder.Property(book => book.CreatedOn).IsRequired();
            builder.Property(book => book.CreatedById).HasColumnName("UpdatedByKey");
            builder.Property(book => book.CreatedOn);
        }
    }
}
