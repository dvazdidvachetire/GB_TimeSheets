using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheets.DTO;
using TimeSheets.Models;

namespace TimeSheets
{
    public class Repositories
    {
        public IList<Task> Tasks { get; set; } = new List<Task>();
        public IList<TaskDto> TaskDtos { get; set; } = new List<TaskDto>();
        public IList<Customer> Customers { get; set; } = new List<Customer>();
        public IList<ContractDto> Contracts { get; set; } = new List<ContractDto>();
        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();
        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public IList<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();
    }
}
