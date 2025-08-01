namespace CentavoControl.Infrastructure.Data.Configurations;

public class InstallmentInfoConfiguration : IEntityTypeConfiguration<InstallmentInfo>
{
    public void Configure(EntityTypeBuilder<InstallmentInfo> builder)
    {
        builder.ToTable("InstallmentInfo");

        builder.HasKey(e => e.PayableId);
        builder.Property(e => e.PayableId)
            .ValueGeneratedNever();
        builder.Property(e => e.InstallmentNumber)
            .IsRequired();
        builder.Property(e => e.TotalInstallments)
            .IsRequired();
        builder.Property(e => e.GroupId)
            .IsRequired();
        
        builder
            .HasOne(p => p.Payable)
            .WithOne(i => i.InstallmentInfo)
            .HasForeignKey<InstallmentInfo>(i => i.PayableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}