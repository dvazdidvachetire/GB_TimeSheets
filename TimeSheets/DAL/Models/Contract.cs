using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Contract
    {
        public int NumberContract { get; set; }
        public int IdEmployee { get; set; }
        public int IdClient { get; set; }
        public decimal Price { get; set; }
        public string TypeJob { get; set; }
        public int QuantityJob { get; set; }
    }
}
