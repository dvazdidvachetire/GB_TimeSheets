using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSheets.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
