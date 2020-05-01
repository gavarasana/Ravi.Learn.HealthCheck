using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ravi.Learn.HealthCheck.Books.Entities;


namespace Ravi.Learn.HealthCheck.Books.EntityMappings
{
    public class BookMapping : BaseEntityMapping<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id).IsUnique(true);
            builder.Property(book => book.Id).HasColumnName("Key").IsRequired().ValueGeneratedOnAdd();
            builder.Property(book => book.Name).HasMaxLength(250).IsRequired();
            builder.Property(book => book.AuthorId).HasColumnName("AuthorKey");
            base.Configure(builder);
        }
    }
}
