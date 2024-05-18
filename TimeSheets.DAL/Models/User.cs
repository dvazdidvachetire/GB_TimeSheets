namespace TimeSheets.DAL.Models;

public sealed class User : BaseModel
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
