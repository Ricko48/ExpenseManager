using BL.Exceptions;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BL.Services
{
    public class UserService : IUserService
    {
        private readonly ITransactionService _transactionService;
        private readonly EmDbContext _dbContext;
        private readonly ISignedInUserInfo _signInUserInfo;

        public UserService(ITransactionService transactionService, EmDbContext dbContext, ISignedInUserInfo signInUserInfo)
        {
            _transactionService = transactionService;
            _dbContext = dbContext;
            _signInUserInfo = signInUserInfo;
        }

        public async Task SignInAsync(string userName, string password)
        {
            var user = await GetUserForUserNameAsync(userName);

            if (user == null)
            {
                throw new UserWithGivenUserNameDoesNotExist(userName);
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new InvalidPasswordException();
            }

            _signInUserInfo.UserId = user.Id;
        }

        public async Task CreateUserAsync(User user)
        {
            if (await CheckIfUsernameAlreadyExistsAsync(user.UserName))
            {
                throw new UsernameAlreadyUsedException(user.UserName);
            }

            if (!CheckPasswordComplexity(user.Password))
            {
                throw new PasswordNotComplexEnoughException();
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public void SignOut()
        {
            _signInUserInfo.UserId = null;
        }

        public async Task DeleteSignedInUserAsync()
        {
            await DeleteUserForIdAsync(_signInUserInfo.UserId.Value);
            _signInUserInfo.UserId = null;
        }

        public async Task UpdateUserAsync(User user)
        {
            var originalUser = await _dbContext.Users.FindAsync(user.Id);

            if (originalUser == null)
            {
                throw new EntityWithGivenIdDoesNotExistException<User>();
            }

            if (originalUser.UserName != user.UserName && await CheckIfUsernameAlreadyExistsAsync(user.UserName))
            {
                throw new UsernameAlreadyUsedException(user.UserName);
            }

            await Task.Run(() =>
            {
                _dbContext.Users.Remove(originalUser);
            });
            
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetSignedInUserAsync()
        {
            if (!IsUserSignedIn())
            {
                throw new UserNotSignedInException();
            }

            return await GetUserForIdAsync(_signInUserInfo.UserId.Value);
        }

        public bool IsUserSignedIn()
        {
            return _signInUserInfo.UserId != null;
        }

        public async Task<User?> GetUserForIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        private async Task DeleteUserForIdAsync(int userId)
        {
            var user = await GetUserForIdAsync(userId);

            if (user == null)
            {
                throw new EntityWithGivenIdDoesNotExistException<User>();
            }

            await _transactionService.DeleteTransactionsForUserIdAsync(_signInUserInfo.UserId.Value);

            await Task.Run(() =>
            {
                _dbContext.Users.Remove(user);
            });

            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> CheckIfUsernameAlreadyExistsAsync(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName == username);
        }

        private bool CheckPasswordComplexity(string password)
        {
            if (password.Length < 6 || 
                !password.Any(char.IsDigit) && 
                !password.Any(char.IsUpper) &&
                !password.Any(char.IsLower))
            {
                return false;
            }

            return true;
        }

        private async Task<User?> GetUserForUserNameAsync(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
