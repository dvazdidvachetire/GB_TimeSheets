using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TimeSheets.DAL.Models
{
    public class Invoice
    {
        [JsonIgnore] public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
