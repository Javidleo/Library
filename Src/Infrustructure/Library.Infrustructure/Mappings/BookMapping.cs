using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Mappings;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(i => i.Name).HasMaxLength(200);
        builder.Property(i => i.Writer).HasMaxLength(150);

        builder.Property(i => i.Publisher).HasMaxLength(150);

        builder.Property(i => i.BarCode).HasMaxLength(50);
    }

}