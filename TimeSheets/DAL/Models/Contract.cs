using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int NumberContract { get; set; }
    }
}
