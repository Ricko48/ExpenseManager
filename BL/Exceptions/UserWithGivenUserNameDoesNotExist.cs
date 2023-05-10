namespace BL.Exceptions
{
    public class UserWithGivenUserNameDoesNotExist : Exception
    {
        public UserWithGivenUserNameDoesNotExist(string userName)
            : base($"User with username {userName} does not exist.") { }
    }
}
