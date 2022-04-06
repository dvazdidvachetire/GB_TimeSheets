using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class InvoiceTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int InvoiceId { get; set; }
    }
}
