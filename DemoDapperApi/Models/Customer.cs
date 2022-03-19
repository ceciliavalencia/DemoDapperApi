using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CityId { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? NextCallDate { get; set; }
        public DateTime TsInserted { get; set; }
    }
}
