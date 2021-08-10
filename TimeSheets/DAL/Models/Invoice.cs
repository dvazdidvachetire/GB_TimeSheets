using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Invoice
    {
        public int NumberInvoice { get; set; }
        public SortedDictionary<int, Contract> Contracts { get; set; }
        public decimal Total { get; set; }
    }
}
