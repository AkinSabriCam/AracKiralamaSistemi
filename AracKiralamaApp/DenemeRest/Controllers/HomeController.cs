using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayerLogic.BLLs;
namespace DenemeRest.Controllers
{
    public class HomeController : ApiController
    {
        BusinessLayerLogic.BLLs.SirketBLL sirketBusiness = new SirketBLL();
        [HttpGet]
        public IHttpActionResult Get()
        { 
            return Ok(sirketBusiness.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(sirketBusiness.GetById(id));
        }

    }
}
