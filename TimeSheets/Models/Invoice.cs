using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
