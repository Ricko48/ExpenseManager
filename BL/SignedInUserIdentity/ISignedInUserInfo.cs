﻿namespace BL.SignedInUserIdentity
{
    public interface ISignedInUserInfo
    {
        int? UserId { get; set; }
        bool IsSignedIn { get; }
    }
}
