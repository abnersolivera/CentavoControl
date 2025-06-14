namespace CentavoControl.Domain.Entities;

public class CreditCard
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Limit { get; private set; }
    public int ClosingDay { get; private set; }
    public int DueDay { get; private set; }

    public Guid AccountId { get; private set; }
    public string UserId { get; private set; }

    private CreditCard()
    {
        
    }

    public CreditCard(Guid id, string name, decimal limit, int closingDay, int dueDay, Guid accountId, string userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (closingDay < 1 || closingDay > 31)
            throw new ArgumentOutOfRangeException(nameof(closingDay), "Closing day must be between 1 and 31.");

        if (dueDay < 1 || dueDay > 31)
            throw new ArgumentOutOfRangeException(nameof(dueDay), "Due day must be between 1 and 31.");

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Name = name;
        Limit = limit;
        ClosingDay = closingDay;
        DueDay = dueDay;
        AccountId = accountId;
        UserId = userId;
    }
}
