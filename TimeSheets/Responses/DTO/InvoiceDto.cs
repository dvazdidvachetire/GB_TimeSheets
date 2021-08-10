using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.Responses.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int NumberInvoice { get; set; }
        public ContractDto Contracts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
