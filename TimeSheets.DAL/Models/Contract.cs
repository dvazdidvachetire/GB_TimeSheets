using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class Contract : BaseModel
{
    public int CustomerIdC { get; set; }
    [JsonIgnore] public Customer Customer { get; set; } = null!;
    [JsonIgnore] public int JobIdC { get; set; }
    public int NumberContract { get; set; }
    [JsonIgnore] public IEnumerable<Job> Jobs { get; set; } = Enumerable.Empty<Job>();
}
