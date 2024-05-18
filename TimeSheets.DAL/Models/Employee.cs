using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class Employee : BaseModel
{
    public string FullName { get; set; } = string.Empty;
    [JsonIgnore] public IEnumerable<Job> Jobs { get; set; } = Enumerable.Empty<Job>();
}
