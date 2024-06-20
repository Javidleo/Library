using Library.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrustructure.Mappings;
public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasMany(x => x.Users)
               .WithOne(i => i.Admin)
               .HasForeignKey(i => i.AdminId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(i => i.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(i => i.Age)
               .HasMaxLength(2)
               .IsRequired();
    }
}
