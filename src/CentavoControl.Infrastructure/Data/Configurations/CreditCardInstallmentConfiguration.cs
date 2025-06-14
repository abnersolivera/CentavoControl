using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentavoControl.Domain.Entities;

namespace CentavoControl.Infrastructure.Data.Configurations;

public class CreditCardInstallmentConfiguration : IEntityTypeConfiguration<CreditCardInstallment>
{
    public void Configure(EntityTypeBuilder<CreditCardInstallment> builder)
    {
        builder.ToTable("CreditCardInstallment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        builder.Property(x => x.InstallmentNumber)
            .IsRequired();
        builder.Property(x => x.InstallmentAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(x => x.DueDate)
            .IsRequired();
        builder.Property(x => x.IsPaid)
            .IsRequired();
        builder.Property(x => x.CreditCardExpenseId)
            .IsRequired();
        builder.HasOne<CreditCardExpense>()
            .WithMany()
            .HasForeignKey(x => x.CreditCardExpenseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}