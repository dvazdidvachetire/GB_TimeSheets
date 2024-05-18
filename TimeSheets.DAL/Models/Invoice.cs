using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class Invoice : BaseModel
{
    public int CustomerIdI { get; set; }
    [JsonIgnore] public Customer Customer { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    [JsonIgnore] public IEnumerable<Job> Jobs { get; set; } = Enumerable.Empty<Job>();
}
