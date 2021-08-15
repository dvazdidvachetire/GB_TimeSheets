using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
