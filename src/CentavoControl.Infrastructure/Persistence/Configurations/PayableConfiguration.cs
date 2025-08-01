namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class PayableConfiguration : IEntityTypeConfiguration<Payable>
{
    public void Configure(EntityTypeBuilder<Payable> builder)
    {
        builder.ToTable("Payable");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
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
        
        builder
            .HasOne(a => a.Account)
            .WithMany(p => p.Payables)
            .HasForeignKey(p => p.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(c => c.Category)
            .WithMany(p => p.Payables)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(p => p.RecurringInfo)
            .WithOne(r => r.Payable)
            .HasForeignKey<RecurringInfo>(r => r.PayableId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(i => i.InstallmentInfo)
            .WithOne(i => i.Payable)
            .HasForeignKey(r => r.PayableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}