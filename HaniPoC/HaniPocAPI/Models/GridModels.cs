using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaniPocAPI.Models
{
    public class GridModels
    {
        public int? SnoId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ContinentName { get; set; }
        public int? ContinentId { get; set; }
        public string CountryName { get; set; }
        public int? CountryId { get; set; }
        public string CityName { get; set; }
        public int? CityId { get; set; }
        public bool? RememberMe { get; set; }
    }
}