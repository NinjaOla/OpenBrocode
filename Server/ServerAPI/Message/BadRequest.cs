using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc; 


namespace ServerAPI.Message
{
    public class BadRequest : Message 
    {
        public BadRequest(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }

        public BadRequest() : base()
        {

        }

        public BadRequest(ModelStateDictionary model) : base(model, HttpStatusCode.BadRequest)
        {

        }
        
    }
}