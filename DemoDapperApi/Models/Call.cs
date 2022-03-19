using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class Call
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CallOutcomeId { get; set; }
    }
}
