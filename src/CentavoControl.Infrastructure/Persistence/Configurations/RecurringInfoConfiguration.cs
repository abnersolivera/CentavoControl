namespace CentavoControl.Infrastructure.Data.Configurations;

public class RecurringInfoConfiguration : IEntityTypeConfiguration<RecurringInfo>
{
    public void Configure(EntityTypeBuilder<RecurringInfo> builder)
    {
        builder.ToTable("RecurringInfo");

        builder.HasKey(e => e.PayableId);
        builder.Property(e => e.PayableId)
            .ValueGeneratedNever();
        builder.Property(e => e.RecurrenceType)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(e => e.RecurrenceGroupId)
            .IsRequired();

        builder
            .HasOne(p => p.Payable)
            .WithOne(p => p.RecurringInfo)
            .HasForeignKey<RecurringInfo>(r => r.PayableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}