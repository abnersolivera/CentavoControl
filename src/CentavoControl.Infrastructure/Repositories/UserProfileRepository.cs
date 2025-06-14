namespace CentavoControl.Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly DataContext _context;

    public UserProfileRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<UserProfile?> GetByFirebaseUidAsync(string firebaseUid)
    {
        return await _context.Set<UserProfile>()
            .FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid);
    }

    public async Task AddAsync(UserProfile userProfile)
    {
        await _context.Set<UserProfile>().AddAsync(userProfile);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserProfile userProfile)
    {
        _context.Set<UserProfile>().Update(userProfile);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string firebaseUid)
    {
        var userProfile = await GetByFirebaseUidAsync(firebaseUid);
        if (userProfile != null)
        {
            _context.Set<UserProfile>().Remove(userProfile);
            await _context.SaveChangesAsync();
        }
    }
}

