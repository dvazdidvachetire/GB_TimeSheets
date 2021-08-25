using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.DTO
{
    public class TimeSheetDto
    {
        [JsonIgnore] public int Id { get; set; }
        [JsonIgnore] public int JobIdT { get; set; }
        public string EmployeeName { get; set; }
        [JsonIgnore] public int EmployeeIdT { get; set; }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
    }
}
