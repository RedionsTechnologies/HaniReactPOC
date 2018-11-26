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
        [Route("continents")]
        [HttpPost]
        public IHttpActionResult ShowContinent()
        {
            return Ok(new BusinessLogic().ShowContinent());
        }

        [Route("countries")]
        [HttpPost]
        public IHttpActionResult ShowCountry([FromBody]ForContinent forContinent)
        {
            return Ok(new BusinessLogic().ShowCountry(forContinent));
        }

        [Route("cities")]
        [HttpPost]
        public IHttpActionResult ShowCity([FromBody]ForCountry forCountry)
        {
            return Ok(new BusinessLogic().ShowCity(forCountry));
        }

        [Route("details")]
        [HttpPost]
        public IHttpActionResult Detail([FromBody]SaveDetailModels model)
        {
            return Ok(new BusinessLogic().Detail(model));
        }


        [Route("updatedetail")]
        [HttpPost]
        public IHttpActionResult UpdateDetail([FromBody]SaveDetailModels model)
        {
            return Ok(new BusinessLogic().UpdateDetail(model));
        }


        [Route("deletedetail")]
        [HttpPost]
        public IHttpActionResult DeleteDetail([FromBody]SaveDetailModels model)
        {
            return Ok(new BusinessLogic().DeleteDetail(model));
        }


        [Route("showgrid")]
        [HttpPost]
        public IHttpActionResult ShowAllDetails()
        {
            return Ok(new BusinessLogic().ShowAllDetails());
        }
    }
}
