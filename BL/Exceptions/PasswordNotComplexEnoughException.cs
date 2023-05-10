namespace BL.Exceptions
{
    public class PasswordNotComplexEnoughException : Exception
    {
        public PasswordNotComplexEnoughException()
            : base("Password must contain at least 6 characters, 1 uppercase letter, 1 lowercase letter and 1 number.")
        {
        }
    }
}
