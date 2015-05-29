using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuadWebApi.Infrastructure.Interfaces
{
    public class TestI : ISmtp
    {
        public string Test()
        {
            return "test1";
        }
    }
}