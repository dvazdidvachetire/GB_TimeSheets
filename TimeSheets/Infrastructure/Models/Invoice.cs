using System;

namespace TimeSheets.Infrastructure.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
