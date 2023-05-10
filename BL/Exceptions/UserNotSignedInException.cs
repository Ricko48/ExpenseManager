namespace BL.Exceptions
{
    public class UserNotSignedInException : Exception
    {
        public UserNotSignedInException() : base("User is not signed in.") {}
    }
}
