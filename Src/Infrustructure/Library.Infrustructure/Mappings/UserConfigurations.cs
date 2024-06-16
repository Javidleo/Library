using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrustructure.Mappings;


public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasOne(x => x.Admin)
               .WithMany(i => i.Users)
               .HasForeignKey(i => i.AdminId);

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property<int>(i => i.Age)
               .HasMaxLength(2)
               .IsRequired();
    }
}

