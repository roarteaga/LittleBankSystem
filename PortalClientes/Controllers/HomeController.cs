using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PortalClientes.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Session["token"] != null)
            {
                try
                {
                    Client client = new Client();
                    client.CL_NAME = Session["username"].ToString();
                    client.CL_ID = Convert.ToInt32(Session["clientId"]);
                    ServiceIntegration.AccountService accountService = new ServiceIntegration.AccountService();
                    Decimal balanceCuenta=await accountService.GetBalance(Session["token"].ToString(), client);
                    ViewData["balance"] = balanceCuenta.ToString();
                }
                catch
                {

                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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