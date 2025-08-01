namespace CentavoControl.Domain.Entities;

public class InstallmentInfo
{
    protected InstallmentInfo()
    {
        
    }
    
    public InstallmentInfo(Guid payableId, int installmentNumber, int totalInstallments, Guid groupId, Payable payable)
    {
        PayableId = payableId;
        InstallmentNumber = installmentNumber;
        TotalInstallments = totalInstallments;
        GroupId = groupId;
        Payable = payable;
    }
    
    public Guid PayableId { get; private set; }
    public int InstallmentNumber { get; private set; } 
    public int TotalInstallments { get; private set; }
    public Guid GroupId { get; private set; }
    public Payable Payable { get; private set; }
}