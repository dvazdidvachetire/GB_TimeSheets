using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public IList<Contract> Contracts { get; set; }
        public IList<Invoice> Invoices { get; set; }
    }
}
