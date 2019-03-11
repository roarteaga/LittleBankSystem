using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AuthenticationService.Controllers
{
    [Authorize]
    [RoutePrefix("OperationLog")]
    public class OperationsLogController : ApiController
    {
        [HttpPost]
        [Route("GetOperationLog")]
        public IHttpActionResult GetOperationLog(Client cliente)
        {
            ModelManagement model = new ModelManagement();
            return Ok(model.Operations.Where(x => x.OP_CL_ID == cliente.CL_ID).ToList());
        }

    }
}