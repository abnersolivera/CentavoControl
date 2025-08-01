namespace CentavoControl.Domain.Entities;

public class InstallmentInfo
{
    protected InstallmentInfo()
    {
        
    }
    
    public InstallmentInfo(Guid payableId, int installmentNumber, int totalInstallments, Guid id, Payable payable)
    {
        Id = id;
        PayableId = payableId;
        InstallmentNumber = installmentNumber;
        TotalInstallments = totalInstallments;
        Payable = payable;
    }
    
    public Guid Id { get; private set; }
    public Guid PayableId { get; private set; }
    public int InstallmentNumber { get; private set; } 
    public int TotalInstallments { get; private set; }
    public Payable Payable { get; private set; }
}