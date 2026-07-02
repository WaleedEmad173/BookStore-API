using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.EntityConfigurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(au => au.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(au => au.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
