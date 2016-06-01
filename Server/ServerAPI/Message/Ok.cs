using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ServerAPI.Message
{
    public class Ok : IHttpActionResult
    {
        private readonly string message = "";

        private HttpStatusCode code = HttpStatusCode.OK;

        public Ok(string message)
        {
            this.message = message; 
        }

        public Ok()
        {

        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent(message)
            };

            return Task.FromResult(response); 
        }
    }
}