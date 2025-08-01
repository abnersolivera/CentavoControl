namespace CentavoControl.Domain.Entities;

public class UserProfile
{
    public string FirebaseUid { get; private set; }
    public string? DisplayName { get; private set; }
    public string? Email { get; private set; }

    protected UserProfile()
    {
        
    }

    public UserProfile(string firebaseUid, string? displayName = null, string? email = null)
    {
        if (string.IsNullOrWhiteSpace(firebaseUid))
            throw new ArgumentException("FirebaseUid cannot be empty.", nameof(firebaseUid));

        FirebaseUid = firebaseUid;
        DisplayName = displayName;
        Email = email;
    }
}