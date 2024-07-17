using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace APICarRental.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}