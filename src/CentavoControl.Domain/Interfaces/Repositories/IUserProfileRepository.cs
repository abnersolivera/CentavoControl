using CentavoControl.Domain.Entities;

namespace CentavoControl.Domain.Interfaces.Repositories;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByFirebaseUidAsync(string firebaseUid);
    Task AddAsync(UserProfile userProfile);
    Task UpdateAsync(UserProfile userProfile);
    Task DeleteAsync(string firebaseUid);
}