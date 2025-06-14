namespace CentavoControl.Domain.Entities;

public class CreditCardInstallment
{
    public Guid Id { get; private set; }
    public int InstallmentNumber { get; private set; }
    public decimal InstallmentAmount { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool IsPaid { get; private set; }

    public Guid CreditCardExpenseId { get; private set; }

    private CreditCardInstallment()
    {
        
    }

    public CreditCardInstallment(
        Guid id,
        int installmentNumber,
        decimal installmentAmount,
        DateTime dueDate,
        bool isPaid,
        Guid creditCardExpenseId)
    {
        if (installmentNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(installmentNumber), "Installment number must be at least 1.");

        if (installmentAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(installmentAmount), "Installment amount must be greater than zero.");

        Id = id;
        InstallmentNumber = installmentNumber;
        InstallmentAmount = installmentAmount;
        DueDate = dueDate;
        IsPaid = isPaid;
        CreditCardExpenseId = creditCardExpenseId;
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
