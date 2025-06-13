namespace CentavoControl.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Type)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(e => e.UserId)
            .HasMaxLength(100)
            .IsRequired();
    }
}