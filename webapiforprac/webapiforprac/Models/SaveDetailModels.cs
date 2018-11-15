using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapiforprac.Models
{
    public class SaveDetailModels
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? continentId { get; set; }
        public int? countryId { get; set; }
        public int? cityId { get; set; }
        public bool? remember { get; set; }
    }
}