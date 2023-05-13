using DAL.Entities;

namespace BL.Services.Interfaces
{
    public interface IUserService
    {
        Task SignInAsync(string userName, string password);
        Task CreateUserAsync(User user);
        void SignOut();
        Task DeleteSignedInUserAsync();
        Task UpdateSignedInUserAsync(User user);
        Task<User?> GetSignedInUserAsync();
        bool IsUserSignedIn();

        Task UpdatePasswordForSignedInUser(string newPassword, string currentPassword);
    }
}
