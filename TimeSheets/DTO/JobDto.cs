using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.DTO
{
    public class JobDto
    {
        public string CustomerFullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public IReadOnlyList<TimeSheetDto> TimeSheets { get; set; }
    }
}
