using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class TimeSheet : BaseModel
{
    [JsonIgnore] public int JobIdT { get; set; }
    [JsonIgnore] public Job Job { get; set; } = null!;
    public int EmployeeIdT { get; set; }
    [JsonIgnore] public Employee Employee { get; set; } = null!;
    public DateTimeOffset FromTime { get; set; }
    public DateTimeOffset ToTime { get; set; }
}
