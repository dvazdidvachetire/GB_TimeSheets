using System.Collections.Generic;
using System.Text.Json.Serialization;
using TimeSheets.Infrastructure.Models;
using Task = TimeSheets.Infrastructure.Models.Job;

namespace TimeSheets.DTO
{
    public class InvoiceDto
    {
        [JsonIgnore] public int Id { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<JobDto> Jobs { get; set; }
        public decimal TotalSum { get; set; }
    }
}
