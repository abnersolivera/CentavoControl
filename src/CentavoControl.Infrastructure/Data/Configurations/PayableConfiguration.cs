using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentavoControl.Domain.Entities;

namespace CentavoControl.Infrastructure.Data.Configurations;

public class PayableConfiguration : IEntityTypeConfiguration<Payable>
{
    public void Configure(EntityTypeBuilder<Payable> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(p => p.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(p => p.DueDate)
            .IsRequired();
        builder.Property(p => p.IsPaid)
            .IsRequired();
        builder.Property(p => p.AccountId)
            .IsRequired();
        builder.Property(p => p.CategoryId)
            .IsRequired();
        builder.Property(p => p.UserId)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(p => p.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}