namespace CentavoControl.Domain.Entities;

public class Payable
{
    protected Payable()
    {
        
    }

    public Payable(
        Guid id,
        string description,
        decimal amount,
        DateTime dueDate,
        Guid accountId,
        Guid categoryId,
        string userId,
        Account? account = null,
        Category? category = null,
        RecurringInfo? recurringInfo = null,
        ICollection<InstallmentInfo>? installmentInfo = null)
    {
        Id = id;
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        IsPaid = false;
        AccountId = accountId;
        CategoryId = categoryId;
        UserId = userId;
        Account = account;
        Category = category;
        RecurringInfo = recurringInfo;
        InstallmentInfo = installmentInfo ?? new List<InstallmentInfo>();
    }
    
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsPaid { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string UserId { get; private set; }
    
    public Account? Account { get; private set; }
    public Category? Category { get; private set; }
    public RecurringInfo? RecurringInfo { get; private set; }
    public ICollection<InstallmentInfo>? InstallmentInfo { get; private set; }

    public void MarkAsPaid()
    {
        IsPaid = true;
    }
    
    public void UpdateDetails(string description, decimal amount, DateTime dueDate, Guid accountId, Guid categoryId)
    {
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        AccountId = accountId;
        CategoryId = categoryId;
    }
    
}
