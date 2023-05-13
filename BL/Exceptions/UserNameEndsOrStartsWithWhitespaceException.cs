namespace BL.Exceptions
{
    public class UserNameEndsOrStartsWithWhitespaceException : Exception
    {
        public UserNameEndsOrStartsWithWhitespaceException()
            : base("Username cannot start or end with whitespace.") { }
    }
}
