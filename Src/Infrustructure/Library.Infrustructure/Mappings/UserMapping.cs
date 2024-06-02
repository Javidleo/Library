using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Mappings;
public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(i => i.FirstName).HasMaxLength(100);
        builder.Property(i => i.LastName).HasMaxLength(100);

        builder.Property(i => i.NationalCode).HasMaxLength(10);
    }
}
