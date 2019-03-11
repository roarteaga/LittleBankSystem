using AuthenticationService.Models;
using ClientServices.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ClientServices.Controllers
{
    [Authorize]
    [RoutePrefix("client")]
    public class ClientController:ApiController
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(ClientController));
        [HttpPost]
        [Route("GetClients")]
        public IHttpActionResult GetClients()
        {
            ModelClient model = new ModelClient();
            List<ClientFAccount> clients = new List<ClientFAccount>();
            try
            {
                clients=model.ClientFirstAccount.ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return Ok(clients);
        }
        [HttpPost]
        [Route("GetClient")]
        public IHttpActionResult GetClient(Client client)
        {
            ModelClient model = new ModelClient();
            Client clientRes = new Client();
            try
            {
                clientRes = model.Client.Where(x => x.CL_NAME.Equals(client.CL_NAME)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return Ok(clientRes);
        }

        [HttpPost]
        [Route("CreateClient")]
        public IHttpActionResult CreateClient(Client client)
        {
            ModelClient model = new ModelClient();
            try
            {
                model.Client.Add(client);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return Ok(client);
        }
        [HttpPost]
        [Route("CreateAccount")]
        public IHttpActionResult CreateAccount(Operation operation)
        {
            ModelClient model = new ModelClient();
            Account account = new Account();
            try
            {
                account.AC_CL_ID = operation.CL_ID;
                account.AC_BALANCE = operation.value;
                account.AC_ACT_ID = 1;
                account.AC_CREATION_DATE = DateTime.Now;
                model.Accounts.Add(account);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return Ok(operation);
        }
    }
}