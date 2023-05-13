namespace BL.SignedInUserIdentity
{
    public class SignedInUserInfo : ISignedInUserInfo
    {
        public int? UserId { get; set; } = null;
        public bool IsSignedIn => UserId != null;
    }
}
