using BL.Services.Interfaces;
using DAL.Entities;

namespace BL.Services
{
    public class UserService
    {
        private readonly ITransactionService _transactionService;

        public UserService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public bool SignIn(string username, string password)
        {
            // GlobalUserInfo.UserId = userId;
            return true;
        }

        public void CreateUser(User user)
        {

        }

        public void SignOut()
        {
            GlobalUserInfo.UserId = null;
        }

        public void DeleteUser()
        {
            // delete
            // _transactionService.DeleteTransactionForUserId(GlobalUserInfo.UserId);
            GlobalUserInfo.UserId = null;
        }

        public void UpdateUser(User user)
        {

        }

        public User GetUser()
        {
            return new User();
        }
    }
}
