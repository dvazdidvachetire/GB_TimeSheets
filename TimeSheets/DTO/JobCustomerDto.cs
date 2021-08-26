using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DTO
{
    public class JobCustomerDto
    {
        public int Id { get; set; }
        [JsonIgnore] public int CustomerIdJ { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public IList<TimeSheetDto> TimeSheets { get; set; }
    }
}
