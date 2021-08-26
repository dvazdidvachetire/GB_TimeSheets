using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.DTO
{
    public class ContractDto
    {
        public int Id { get; set; }
        [JsonIgnore] public int CustomerIdC { get; set; }
        public int NumberContract { get; set; }
        public string CustomerFullName { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}
