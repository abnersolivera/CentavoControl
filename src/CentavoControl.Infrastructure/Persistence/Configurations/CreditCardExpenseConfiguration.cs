namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class CreditCardExpenseConfiguration : IEntityTypeConfiguration<CreditCardExpense>
{
    public void Configure(EntityTypeBuilder<CreditCardExpense> builder)
    {
        builder.ToTable("CreditCardExpense");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(e => e.Description)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(e => e.Installments)
            .IsRequired();
        builder.Property(e => e.PurchaseDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(e => e.UserId)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.CreditCardId)
            .IsRequired();
        builder.Property(e => e.CategoryId)
            .IsRequired();
        builder.HasOne<CreditCard>()
            .WithMany()
            .HasForeignKey(e => e.CreditCardId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}