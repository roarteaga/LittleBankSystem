using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AuthenticationService.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            ModelManagement model= new ModelManagement();

            bool isCredentialValid = (model.Client.Where(x => x.CL_NAME.Equals(login.Username) && x.CL_PASSWORD.Equals(login.Password)).Count() != 0) ? true : false;
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}