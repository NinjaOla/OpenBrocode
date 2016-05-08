using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ServerAPI.Message
{
    public class ErrorMessage : Message
    {
        public ErrorMessage(string message) : base(message)
        {

        }

        public ErrorMessage(string message, HttpStatusCode code) : base(message, code)
        {

        }

        public ErrorMessage(HttpStatusCode code) : base(code)
        {

        }

        public ErrorMessage() : base()
        {

        }
    }
}