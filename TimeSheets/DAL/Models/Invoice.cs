using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Invoice
    {
        public decimal Price { get; set; }
        public List<Contract> Contracts { get; set; }
        public int Number { get; set; }
    }
}
