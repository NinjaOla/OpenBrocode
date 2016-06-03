using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Server.Routes
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            return Json(new 
            {
                message = "Ok Computer", 
                client = caller.FindFirst("client_id").Value
            }); 
        }
    }
}