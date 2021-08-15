using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Models;
using Task = TimeSheets.Models.Task;

namespace TimeSheets.DTO
{
    public class ContractDto
    {
        public int NumberContract { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
