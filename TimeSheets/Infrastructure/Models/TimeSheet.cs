using System;

namespace TimeSheets.Infrastructure.Models
{
    public class TimeSheet
    {
        public int EmployeeId { get; set; }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
    }
}
