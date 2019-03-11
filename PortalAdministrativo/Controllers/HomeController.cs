using AuthenticationService.Models;
using ClientServices.Models;
using ServiceIntegration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PortalAdministrativo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ClientService service = new ClientService();
            ServiceIntegration.AuthenticationService authentication = new ServiceIntegration.AuthenticationService();

            string token=await authentication.authentication(ConfigurationManager.AppSettings["AdminUser"].ToString(), ConfigurationManager.AppSettings["AdminPassword"].ToString());
            Session["token"] = token;
            List<ClientFAccount> clients=await service.GetClients(token);
            return View(clients);
        }
        public ActionResult _CreateClient()
        {
            return View();
        }
        public async Task<ActionResult> _CreateCliente([Bind(Include = "CL_NAME,CL_PASSWORD,AC_BALANCE")]ClientFAccount cfa)
        {
            ClientService service = new ClientService();
            Client cliente = new Client();
            cliente.CL_CREATION_DATE = DateTime.Now;
            cliente.CL_NAME = cfa.CL_NAME;
            cliente.CL_PASSWORD = cfa.CL_PASSWORD;
            cliente.CL_CREATION_DATE = DateTime.Now;
            Client clienteNew=await service.CreateClient(cliente, Session["token"].ToString());
            Operation op = new Operation();
            op.CL_ID = clienteNew.CL_ID;
            op.value = cfa.AC_BALANCE;
            await service.CreateAccount(op, Session["token"].ToString());
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}