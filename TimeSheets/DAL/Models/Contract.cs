using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class Contract
    {
        [JsonIgnore] public int Id { get; set; }
        public int CustomerIdC { get; set; }
        [JsonIgnore] public Customer Customer { get; set; }
        [JsonIgnore] public int JobIdC { get; set; }
        public int NumberContract { get; set; }
        [JsonIgnore] public IList<Job> Jobs { get; set; }
        [JsonIgnore] public int IsDelete { get; set; }
    }
}
