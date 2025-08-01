namespace CentavoControl.Domain.Entities;

public class Payable
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsPaid { get; private set; }

    public Guid AccountId { get; private set; }
    public Account Account { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string UserId { get; private set; }
    
    public RecurringInfo? RecurringInfo { get; set; }
    public InstallmentInfo? InstallmentInfo { get; set; }

    protected Payable()
    {
        
    }

    public Payable(
        Guid id,
        string description,
        decimal amount,
        DateTime dueDate,
        bool isPaid,
        Guid accountId,
        Guid categoryId,
        string userId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        IsPaid = isPaid;
        AccountId = accountId;
        CategoryId = categoryId;
        UserId = userId;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
    }

    public void MarkAsUnpaid()
    {
        IsPaid = false;
    }
}
