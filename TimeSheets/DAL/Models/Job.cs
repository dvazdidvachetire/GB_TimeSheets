using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Job
    {
        [JsonIgnore] public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore] public TimeSheet TimeSheet { get; set; }
        [JsonIgnore] public bool IsDeleted { get; set; }
    }
}
