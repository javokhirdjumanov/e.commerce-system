﻿using ecommerce.domain.Enums;

namespace ecommerce.domain.Entities;
public sealed class OtpCode
{
    private const int OTP_EXPIRATION_TIME_IN_SECONDS = 180;

    public Guid Id { get; private set; }
    public string Code { get; private set; }
    public DateTime CreateAt { get; private set; } = DateTime.Now;
    public OtpCodeStatus Status { get; private set; }

    public Guid UserId { get; }
    public User User { get; }

    public OtpCode(string code)
    {
        Code = code;
        Status = OtpCodeStatus.Unverified;
    }

    public bool IsExpired() => 
        CreateAt.AddSeconds(OTP_EXPIRATION_TIME_IN_SECONDS) < DateTime.Now;

    public bool IsValid(string otpCode) => Code.Equals(otpCode);

    public void MarkAsVerified() => Status = OtpCodeStatus.Verified;

    public void MarkAsExpired() => Status = OtpCodeStatus.Expired;
}
