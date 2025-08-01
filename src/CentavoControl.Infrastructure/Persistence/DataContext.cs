namespace CentavoControl.Infrastructure.Persistence;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CreditCardExpense> CreditCardExpenses { get; set; }
    public DbSet<CreditCardInstallment> CreditCardInstallments { get; set; }
    public DbSet<Payable> Payables { get; set; }
    public DbSet<InstallmentInfo> InstallmentInfos { get; set; }
    public DbSet<RecurringInfo> RecurringInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}