using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        builder.Property(i => i.LastName)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(i => i.UserName)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(i => i.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(i => i.NationalCode)
               .HasMaxLength(12)
               .IsRequired();
    }
}
