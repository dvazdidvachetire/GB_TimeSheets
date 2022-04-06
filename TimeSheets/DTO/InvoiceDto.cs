using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.Models;
using Task = TimeSheets.Models.Task;

namespace TimeSheets.DTO
{
    public class InvoiceDto
    {
        [JsonIgnore] public int Id { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }
        public decimal TotalSum { get; set; }
    }
}
