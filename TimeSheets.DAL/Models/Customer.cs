using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models;

public sealed class Customer : BaseModel
{
    public string FullName { get; set; } = string.Empty;
    [JsonIgnore] public IEnumerable<Contract> Contracts { get; set; } = Enumerable.Empty<Contract>();
    [JsonIgnore] public IEnumerable<Invoice> Invoices { get; set; } = Enumerable.Empty<Invoice>();
}
