using SlackTeam.LIB.Model;
using SlackTeam.LIB.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SlackTeam.WEB.Controllers
{
    public class ApiUserController : ApiController
    {
        UserProvider _provider = new UserProvider();
        
        [HttpGet]
        public Dictionary<Object, Object> GetAllUser()
        {
            Dictionary<Object, Object> output = new Dictionary<object, object>();
            output.Add("success", true);
            output.Add("content", _provider.GetallUser());
            return output;
        }
    }
}
