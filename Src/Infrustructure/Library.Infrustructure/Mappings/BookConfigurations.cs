using Library.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrustructure.Mappings;
public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(i => i.UserBooks)
               .WithOne(i => i.Book)
               .HasForeignKey(i => i.BookId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Title)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(i => i.Publisher)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(i => i.Price)
               .IsRequired();
    }
}

