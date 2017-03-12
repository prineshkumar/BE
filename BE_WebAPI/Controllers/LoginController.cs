using BE.Data;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BE_WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetUser([FromBody]Credentials _credentials)
        {
            User _user = null;
            using (UserOperations _userOperation = new UserOperations())
            {
                _user = _userOperation.GetUserDetails(userName: _credentials.UserName
                    , password: _credentials.Password);
                if (_user == null)
                    return NotFound();
                else
                    return Ok(_user);
            }
        }

        [HttpOptions]
        public void Options()
        {

        }
    }
}
