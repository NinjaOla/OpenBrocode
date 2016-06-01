using Microsoft.AspNet.Identity;
using ServerAPI.App_Start;
using ServerAPI.Message;
using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServerAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class ApiAccountController : Controller
    {
        private AuthRepository _repo = null;


        public ApiAccountController()
        {
            _repo = new AuthRepository();
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<System.Web.Http.IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            System.Web.Http.IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return new Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private System.Web.Http.IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return new BadRequest();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return new BadRequest();
                }

                return new BadRequest(ModelState);
            }

            return null;
        }
    }
}