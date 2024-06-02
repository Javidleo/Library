using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Mappings;

public class AdminMapping : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.Property(i => i.FirstName).HasMaxLength(100);
        builder.Property(i => i.LastName).HasMaxLength(100);

        builder.Property(i => i.NationalCode).HasMaxLength(10);
        builder.Property(i => i.UserName).HasMaxLength(50);
        builder.Property(i => i.Password).HasMaxLength(50);
    }
}
