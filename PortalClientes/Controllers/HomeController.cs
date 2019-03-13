using AuthenticationService.Models;
using ClientServices.Models;
using ServiceIntegration;
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
            List<OperationLog> operationLogs = new List<OperationLog>();
            if (Session["token"] != null)
            {
                try
                {
                    Client client = new Client();
                    client.CL_NAME = Session["username"].ToString();
                    client.CL_ID = Convert.ToInt32(Session["clientId"]);
                    ServiceIntegration.AccountService accountService = new ServiceIntegration.AccountService();
                    Decimal balanceCuenta=await accountService.GetBalance(Session["token"].ToString(), client);
                    ClientService clientService = new ServiceIntegration.ClientService();
                    operationLogs = await clientService.GetOperationLog(client, Session["token"].ToString());
                    ViewData["balance"] = balanceCuenta.ToString();
                }
                catch
                {

                }
                return View(operationLogs);
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
        public async Task<ActionResult> _Consignacion1([Bind(Include = "value")]Operation operacion)
        {
            ClientService service = new ClientService();
            operacion.CL_ID = Convert.ToInt32(Session["clientId"]);   
            OperationLog clienteNew = await service.Consignacion(operacion, Session["token"].ToString());
            ViewData["mensajeOk"] = "Consignacion realizada.";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult _Consignacion()
        {
            try
            {
                if (Session["token"] != null)
                {
                    return PartialView("_Consignacion");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception exp)
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public async Task<ActionResult> _Retiro1([Bind(Include = "value")]Operation operacion)
        {
            ClientService service = new ClientService();
            operacion.CL_ID = Convert.ToInt32(Session["clientId"]);

            OperationLog clienteNew = await service.Retiro(operacion, Session["token"].ToString());
            ViewData["mensajeOk"] = "Retiro realizado.";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult _Retiro()
        {
            try
            {
                if (Session["token"] != null)
                {
                    return PartialView("_Retiro");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception exp)
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public async Task<ActionResult> _Transferencia1([Bind(Include = "CL_ID_TO,value")]Transfer operacion)
        {
            ClientService service = new ClientService();
            operacion.CL_ID_FROM = Convert.ToInt32(Session["clientId"]);
            OperationLog clienteNew = await service.Transferencia(operacion, Session["token"].ToString());
            ViewData["mensajeOk"] = "Retiro realizado.";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult _Transferencia()
        {
            try
            {
                if (Session["token"] != null)
                {
                    return PartialView("_Transferencia");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception exp)
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}