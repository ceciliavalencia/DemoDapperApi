using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int? CountryId { get; set; }
    }
}
