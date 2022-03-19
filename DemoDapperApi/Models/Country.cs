using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryNameEng { get; set; }
        public string CountryCode { get; set; }
    }
}
