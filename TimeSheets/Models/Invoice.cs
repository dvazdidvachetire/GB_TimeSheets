using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheets.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public DateTimeOffset Date { get; set; }
        public IList<Task> Tasks { get; set; }

        public decimal Cost() => Tasks.Select(s => s.Amount).Sum();
    }
}
