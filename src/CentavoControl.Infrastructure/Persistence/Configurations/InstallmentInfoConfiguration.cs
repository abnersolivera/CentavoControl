namespace CentavoControl.Infrastructure.Persistence.Configurations;

public class InstallmentInfoConfiguration : IEntityTypeConfiguration<InstallmentInfo>
{
    public void Configure(EntityTypeBuilder<InstallmentInfo> builder)
    {
        builder.ToTable("InstallmentInfo");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever();
        builder.Property(e => e.InstallmentNumber)
            .IsRequired();
        builder.Property(e => e.TotalInstallments)
            .IsRequired();
        builder.Property(e => e.PayableId)
            .IsRequired();
        
        builder
            .HasOne(p => p.Payable)
            .WithMany(i => i.InstallmentInfo)
            .HasForeignKey(i => i.PayableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}