namespace CentavoControl.Domain.Entities;

public class CreditCardExpense
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public decimal TotalAmount { get; private set; }
    public int Installments { get; private set; }
    public DateTime PurchaseDate { get; private set; }

    public Guid CreditCardId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string UserId { get; private set; }

    private CreditCardExpense()
    {
        
    }

    public CreditCardExpense(
        Guid id,
        string description,
        decimal totalAmount,
        int installments,
        DateTime purchaseDate,
        Guid creditCardId,
        Guid categoryId,
        string userId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (totalAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(totalAmount), "Total amount must be greater than zero.");

        if (installments < 1)
            throw new ArgumentOutOfRangeException(nameof(installments), "Installments must be at least 1.");

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));

        Id = id;
        Description = description;
        TotalAmount = totalAmount;
        Installments = installments;
        PurchaseDate = purchaseDate;
        CreditCardId = creditCardId;
        CategoryId = categoryId;
        UserId = userId;
    }
}
