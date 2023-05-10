namespace BL.Exceptions
{
    public class UsernameAlreadyUsedException : Exception
    {
        public UsernameAlreadyUsedException(string username) : base($"Username '{username}' already exists.") { }
    }
}
