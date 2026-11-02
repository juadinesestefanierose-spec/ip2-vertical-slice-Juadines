namespace Domain.Entities;

using Domain.Common;

public sealed class RevokedToken : BaseEntity
{
    public string Jti { get; set; } = default!;
    public DateTime ExpiresAtUtc { get; set; }
}