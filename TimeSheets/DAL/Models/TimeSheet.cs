using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Models
{
    public class TimeSheet
    {
        [JsonIgnore] public int Id { get; set; }
        [JsonIgnore] public Job Job { get; set; }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
    }
}
