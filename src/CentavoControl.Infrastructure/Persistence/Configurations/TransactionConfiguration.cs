namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(e => e.Date)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(e => e.Type)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(e => e.AccountId)
            .IsRequired();
        builder.Property(e => e.CategoryId)
            .IsRequired();
        builder.Property(e => e.UserId)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne<Account>()
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}