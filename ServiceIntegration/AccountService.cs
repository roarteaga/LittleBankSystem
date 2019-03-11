using AuthenticationService.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesObjects;

namespace ServiceIntegration
{
    public class AccountService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(AccountService));
        static string BaseurlGetBalance = ConfigurationManager.AppSettings["AccountGetBalanceServiceRoute"];
        public async Task<Decimal> GetBalance(string token, Client client)
        {
            List<JsonHeaders> parametros = new List<JsonHeaders>();
            parametros.Add(new JsonHeaders("Authorization", token));
            JsonAdapters.JsonAdapters jadapters = new JsonAdapters.JsonAdapters();
            string response = await jadapters.GetJson(parametros, BaseurlGetBalance, client, BaseurlGetBalance, HttpMethod.POST);
            Decimal retObj = Convert.ToDecimal(response);
            return retObj;
        }
    }
}
