using System.Text.Json.Serialization;

namespace TimeSheets.Infrastructure.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore] public TimeSheet TimeSheet { get; set; }
    }
}
