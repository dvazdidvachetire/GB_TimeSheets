using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSheets.Models;

namespace TimeSheets
{
    public class Repositories
    {
        public IList<Task> Tasks { get; set; } = new List<Task>();
        public IList<Customer> Customers { get; set; } = new List<Customer>();
        public IList<Contract> Contracts { get; set; } = new List<Contract>();
        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();
        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}
