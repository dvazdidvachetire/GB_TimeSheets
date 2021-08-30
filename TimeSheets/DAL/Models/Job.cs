using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Job
    {
        [JsonIgnore] public int Id { get; set; }
        public int CustomerIdJ { get; set; }
        [JsonIgnore] public Customer Customer { get; set; }
        [JsonIgnore] public int EmployeeIdJ { get; set; }
        [JsonIgnore] public Employee Employee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore] public IList<TimeSheet> TimeSheets { get; set; }
        [JsonIgnore] public bool IsDeleted { get; set; }
    }
}
