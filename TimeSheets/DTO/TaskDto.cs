using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.DTO
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TimeSheet TimeSheet { get; set; }
    }
}
