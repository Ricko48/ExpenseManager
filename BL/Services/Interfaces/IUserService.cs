using DAL.Entities;

namespace BL.Services.Interfaces
{
    public interface IUserService
    {
        Task SignInAsync(string userName, string password);
        Task CreateUserAsync(User user);
        void SignOut();
        Task DeleteSignedInUserAsync();
        Task UpdateUserAsync(User user);
        Task<User?> GetSignedInUserAsync();
        bool IsUserSignedIn();
        Task<User?> GetUserForIdAsync(int userId);
    }
}
