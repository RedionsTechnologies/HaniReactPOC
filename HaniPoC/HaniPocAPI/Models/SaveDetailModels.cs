using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaniPocAPI.Models
{
    public class SaveDetailModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ContinentId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public bool? Remember { get; set; }
    }
}