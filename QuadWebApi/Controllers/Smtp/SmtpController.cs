using QuadWebApi.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QuadWebApi.Controllers.Smtp
{
    [RoutePrefix("api/smtp")]
    public class SmtpController : ApiController
    {
        private ISmtp isMe;
        public SmtpController(ISmtp me)
        {
            this.isMe = me;

        }

        [Route("smtpTest/{id}")]
        [HttpGet]
        public string test(string id)
        {
            return this.isMe.Test() + id;
        }
    }
}