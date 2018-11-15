using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapiforprac.Models
{
    public class GridModels
    {
        public int? sId { get; set; }
        public int? Id { get; set; }
        public string name { get; set; }
        public string continentName { get; set; }
        public int? cntId { get; set; }
        public string countryName { get; set; }
        public int? cutId { get; set; }
        public string cityName { get; set; }
        public int? ctyId { get; set; }
        public bool? rememberMe { get; set; }
    }
}