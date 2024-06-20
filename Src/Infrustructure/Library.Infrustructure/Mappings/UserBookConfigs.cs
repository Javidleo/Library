using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrustructure.Mappings;
public class UserBookConfigs : IEntityTypeConfiguration<UserBook>
{
    public void Configure(EntityTypeBuilder<UserBook> builder)
    {
        builder.HasOne(i => i.User)
               .WithMany(i => i.UserBooks)
               .HasForeignKey(i => i.UserId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(i => i.Book)
               .WithMany(i => i.UserBooks)
               .HasForeignKey(i => i.BookId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(i => i.Id);
    }
}
