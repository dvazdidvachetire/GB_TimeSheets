using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using Task = TimeSheets.DAL.Models.Job;

namespace TimeSheets.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; }
        public IReadOnlyList<JobCustomerDto> Jobs { get; set; }
        public decimal TotalSum { get; set; }
    }
}
