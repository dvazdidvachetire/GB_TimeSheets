using System.Text.Json.Serialization;
using TimeSheets.Infrastructure.Models;

namespace TimeSheets.DTO
{
    public class JobDto
    {
        [JsonIgnore] public int Id { get; set; }
        [JsonIgnore] public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TimeSheet TimeSheet { get; set; }
    }
}
