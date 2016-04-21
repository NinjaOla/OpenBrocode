using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Server.Routes; 

namespace Server.Routes
{
    [RoutePrefix("test")]
    class TestController : ApiController
    {

        [Route("Atest")]
        public IHttpActionResult getJson()
        {
            var caller = User as ClaimsPrincipal; 


            return Json(new
            {
                message = "Ok computer",
                client = caller.FindFirst("client_id").Value
            });
        }

        /*
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            return Json(new 
            {
                messsage = "Ok computer",
                client = caller.FindFirst("client_id").Value
            });
        }*/
    }
}
