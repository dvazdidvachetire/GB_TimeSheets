namespace TimeSheets.DAL.Models;

public sealed class TokenResponse : BaseModel
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
