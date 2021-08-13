using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }

        [JsonIgnore]
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}
