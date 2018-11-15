using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapiforprac.Models;

namespace webapiforprac.Controllers
{

    [RoutePrefix("api")]
    public class DetailController : ApiController
    {
        private TestMVCEntities db = new TestMVCEntities();
        [Route("continents")]
        [HttpPost]
        public List<tblContinent> ShowContinent()
        {
            return new BusinessLogic().ShowContinent();
        }

        [Route("countries")]
        [HttpPost]
        public List<tblCountry> ShowCountry([FromBody]ForContinent forContinent)
        {
            return new BusinessLogic().ShowCountry(forContinent);
        }

        [Route("cities")]
        [HttpPost]
        public List<tblCity> ShowCity([FromBody]ForCountry forCountry)
        {
            return new BusinessLogic().ShowCity(forCountry);
        }

        [Route("details")]
        [HttpPost]
        public int Detail([FromBody]SaveDetailModels model)
        {
            return new BusinessLogic().Detail(model);
        }


        [Route("updatedetail")]
        [HttpPost]
        public int UpdateDetail([FromBody]SaveDetailModels model)
        {
            return new BusinessLogic().UpdateDetail(model);
        }


        [Route("deletedetail")]
        [HttpPost]
        public int DeleteDetail([FromBody]SaveDetailModels model)
        {
            return new BusinessLogic().DeleteDetail(model);
        }


        [Route("showgrid")]
        [HttpPost]
        public List<GridModels> ShowAllDetails()
        {
            return new BusinessLogic().ShowAllDetails();
        }
    }
}
