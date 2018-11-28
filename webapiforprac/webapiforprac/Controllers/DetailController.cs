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
        private BusinessLogic _businessLogic = new BusinessLogic();
        [Route("continents")]
        [HttpPost]
        public IHttpActionResult ShowContinentGetAll()
        {
            return Ok(_businessLogic.ShowContinentGetAll());
        }

        [Route("countries")]
        [HttpPost]
        public IHttpActionResult ShowCountryByContinentId([FromBody]ContinentModelForId forContinent)
        {
            return Ok(_businessLogic.ShowCountryByContinentId(forContinent));
        }

        [Route("cities")]
        [HttpPost]
        public IHttpActionResult ShowCityByCountryId([FromBody]ForCountry forCountry)
        {
            return Ok(_businessLogic.ShowCityByCountryId(forCountry));
        }

        [Route("details")]
        [HttpPost]
        public IHttpActionResult AddDetail([FromBody]SaveDetailModels model)
        {
            return Ok(_businessLogic.AddDetail(model));
        }


        [Route("updatedetail")]
        [HttpPost]
        public IHttpActionResult UpdateDetail([FromBody]SaveDetailModels model)
        {
            return Ok(_businessLogic.UpdateDetail(model));
        }


        [Route("deletedetail")]
        [HttpPost]
        public IHttpActionResult DeleteDetail([FromBody]SaveDetailModels model)
        {
            return Ok(_businessLogic.DeleteDetail(model));
        }


        [Route("showgrid")]
        [HttpPost]
        public IHttpActionResult ShowAllDetails()
        {
            return Ok(_businessLogic.ShowAllDetails());
        }
    }
}
