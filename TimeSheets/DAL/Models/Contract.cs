using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Contract
    {
        public int Number { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Client> Clients { get; set; }
    }
}
