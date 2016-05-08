using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ServerAPI.Message
{
    public class Message : IHttpActionResult
    {
        private string message = "";

        private HttpStatusCode code = HttpStatusCode.BadRequest;

        public Message(string message)
        {
            this.message = message; 
        }

        public Message(string message, HttpStatusCode code)
        {
            this.code = code;
            this.message = message; 
        }

        public Message(HttpStatusCode code)
        {
            this.code = code; 
        }

        public Message(ModelStateDictionary model)
        {
            this.message = model.ToString(); 
        }

        public Message(ModelStateDictionary model, HttpStatusCode code)
        {
            this.message = model.ToString();

            this.code = code; 
        }

        public Message()
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