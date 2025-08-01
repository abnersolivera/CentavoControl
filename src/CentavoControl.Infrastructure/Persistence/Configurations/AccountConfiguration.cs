namespace CentavoControl.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.InitialBalance)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(e => e.IsMainAccount)
            .IsRequired();
        builder.Property(e => e.UserId)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(e => e.Payables)
            .WithOne(e => e.Account)
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}