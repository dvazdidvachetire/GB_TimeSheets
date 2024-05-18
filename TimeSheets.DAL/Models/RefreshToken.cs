namespace TimeSheets.DAL.Models;

public sealed class RefreshToken : BaseModel
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
}
