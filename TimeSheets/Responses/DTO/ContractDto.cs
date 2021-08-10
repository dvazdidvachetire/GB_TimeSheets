using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.Responses.DTO
{
    public class ContractDto
    {
        public int NumberContract { get; set; }
        public Client Client { get; set; }
        public string TypeJob { get; set; }
        public int QuantityJob { get; set; }
        public decimal Price { get; set; }
        public SortedDictionary<int, Employee> Employees { get; set; }
    }
}
