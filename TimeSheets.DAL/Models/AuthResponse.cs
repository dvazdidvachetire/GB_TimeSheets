namespace TimeSheets.DAL.Models;

public sealed class AuthResponse : BaseModel
{
    public string Password { get; set; } = string.Empty;
    public RefreshToken LatestRefreshToken { get; set; } = null!;
}
