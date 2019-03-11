using AuthenticationService.Models;
using ClientServices.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ClientServices.Controllers
{
    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(AccountController));

        [HttpPost]
        [Route("GetBalance")]
        public IHttpActionResult GetBalance(Client cliente)
        {
            ModelClient model = new ModelClient();
            OperationLog operation = new OperationLog();
            Decimal valorCuenta = 0;
            try
            {
                Account account = model.Accounts.Where(x => x.AC_CL_ID == cliente.CL_ID).FirstOrDefault();
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_BALANCE_GET_OK"];
                operation.OP_AC_ID = account.AC_ID;
                operation.OP_CL_ID = cliente.CL_ID;
                model.Operations.Add(operation);
                model.SaveChanges();
                valorCuenta = account.AC_BALANCE;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return Ok(valorCuenta);
        }
        [HttpPost]
        [Route("withdraw")]
        public IHttpActionResult Withdraw(Operation op)
        {
            ModelClient model = new ModelClient();
            OperationLog operation = new OperationLog();
            Client client = model.Client.Where(x => x.CL_ID == op.CL_ID).FirstOrDefault();
            Account account = model.Accounts.Where(x => x.AC_CL_ID == client.CL_ID).FirstOrDefault();
            try
            {
                account.AC_BALANCE = account.AC_BALANCE - op.value;
                model.Entry(account).State = System.Data.Entity.EntityState.Modified;
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_WITHDRAW_OK"];
                operation.OP_AC_ID = account.AC_ID;
                operation.OP_CL_ID = client.CL_ID;
                model.Operations.Add(operation);
                model.SaveChanges();
            }catch(Exception exp)
            {
                log.Error(exp.Message);
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_ERROR"];
                operation.OP_AC_ID = account.AC_ID;
                operation.OP_CL_ID = client.CL_ID;
            }
            return Ok(operation);
        }
        [HttpPost]
        [Route("consignment")]
        public IHttpActionResult Consignment(Operation op)
        {
            ModelClient model = new ModelClient();
            Client client = model.Client.Where(x => x.CL_ID == op.CL_ID).FirstOrDefault();
            OperationLog operation = new OperationLog();
            Account account = model.Accounts.Where(x => x.AC_CL_ID == client.CL_ID).FirstOrDefault();
            try
            {
                account.AC_BALANCE = account.AC_BALANCE + op.value;
                model.Entry(account).State = System.Data.Entity.EntityState.Modified;
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_CONSIGNMENT_OK"];
                operation.OP_AC_ID = account.AC_ID;
                operation.OP_CL_ID = client.CL_ID;
                model.Operations.Add(operation);
                model.SaveChanges();
            }catch(Exception ex)
            {
                log.Error(ex.Message);
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_ERROR"];
                operation.OP_AC_ID = account.AC_ID;
                operation.OP_CL_ID = client.CL_ID;
                model.Operations.Add(operation);
                model.SaveChanges();
            }
            return Ok(operation);
        }
        [HttpPost]
        [Route("transfer")]
        public IHttpActionResult Transfer(Transfer transfer)
        {
            Client clientFrom = new Client();
            Client clientTo = new Client();
            Decimal value = 0;
            ModelClient model = new ModelClient();
            clientFrom = model.Client.Where(x => x.CL_ID == transfer.CL_ID_FROM).FirstOrDefault();
            clientTo = model.Client.Where(x => x.CL_ID == transfer.CL_ID_TO).FirstOrDefault();
            value = transfer.value;
            OperationLog operation = new OperationLog();
            Account account1 = model.Accounts.Where(x => x.AC_CL_ID == clientFrom.CL_ID).FirstOrDefault();
            Account account2 = model.Accounts.Where(x => x.AC_CL_ID == clientTo.CL_ID).FirstOrDefault();
            string error = "";
            try
            {
                Operation op = new Operation();
                op.CL_ID = clientFrom.CL_ID;
                op.value = value;
                Operation op2 = new Operation();
                op2.CL_ID = clientTo.CL_ID;
                op2.value = value;
                Withdraw(op);
                Consignment(op2);
                    
                operation.OP_AC_ID = account1.AC_ID;
                operation.OP_CL_ID = account1.AC_CL_ID;
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_TRANSFER_OK"];
                model.Operations.Add(operation);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                operation.OP_DESCRIPTION = ConfigurationManager.AppSettings["MSG_ERROR"];
                operation.OP_AC_ID = account1.AC_ID;
                operation.OP_CL_ID = clientFrom.CL_ID;
                model.Operations.Add(operation);
                model.SaveChanges();
            }
            return Ok(operation);
        }
    }
}