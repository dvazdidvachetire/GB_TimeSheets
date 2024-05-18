using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class Job : BaseModel
{
    public int CustomerIdJ { get; set; }
    [JsonIgnore] public Customer Customer { get; set; } = null!;
    [JsonIgnore] public int EmployeeIdJ { get; set; }
    [JsonIgnore] public Employee Employee { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    [JsonIgnore] public IEnumerable<TimeSheet> TimeSheets { get; set; } = Enumerable.Empty<TimeSheet>();
}
