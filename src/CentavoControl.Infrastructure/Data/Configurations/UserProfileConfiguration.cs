using CentavoControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentavoControl.Infrastructure.Data.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(e => e.FirebaseUid);
        builder.Property(e => e.FirebaseUid)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Email)
            .HasMaxLength(150);
        builder.Property(e => e.DisplayName)
            .HasMaxLength(100);
    }
}