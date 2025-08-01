namespace CentavoControl.Infrastructure.Persistence.Repositories;

public class UserProfileRepository(DataContext context) : IUserProfileRepository
{
    public async Task<UserProfile?> GetByFirebaseUidAsync(string firebaseUid)
    {
        return await context.Set<UserProfile>()
            .FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid);
    }

    public async Task AddAsync(UserProfile userProfile)
    {
        await context.Set<UserProfile>().AddAsync(userProfile);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserProfile userProfile)
    {
        context.Set<UserProfile>().Update(userProfile);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string firebaseUid)
    {
        var userProfile = await GetByFirebaseUidAsync(firebaseUid);
        if (userProfile != null)
        {
            context.Set<UserProfile>().Remove(userProfile);
            await context.SaveChangesAsync();
        }
    }
}

