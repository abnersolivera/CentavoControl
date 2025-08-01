namespace CentavoControl.Infrastructure.Data.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.ToTable("CreditCard");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Limit)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(e => e.ClosingDay)
            .IsRequired();
        builder.Property(e => e.DueDay)
            .IsRequired();
        builder.Property(e => e.UserId)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.AccountId)
            .IsRequired();
        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}