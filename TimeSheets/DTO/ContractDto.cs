using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using Job = TimeSheets.DAL.Models.Job;

namespace TimeSheets.DTO
{
    public class ContractDto
    {
        [JsonIgnore] public int Id { get; set; }
        public int NumberContract { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Job> Tasks { get; set; }
    }
}
