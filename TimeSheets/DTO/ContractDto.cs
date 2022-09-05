using System.Collections.Generic;
using System.Text.Json.Serialization;
using TimeSheets.Infrastructure.Models;

namespace TimeSheets.DTO
{
    public class ContractDto
    {
        [JsonIgnore] public int Id { get; set; }
        public int NumberContract { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}
