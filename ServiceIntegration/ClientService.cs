using AuthenticationService.Models;
using ClientServices.Models;
using JsonAdapters;
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
    public class ClientService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(ClientService));
        static string BaseurlGetClients = ConfigurationManager.AppSettings["ClientServiceGetClientsRoute"];
        static string BaseurlGetClient = ConfigurationManager.AppSettings["ClientServiceGetClientRoute"];
        static string BaseurlCreateClient = ConfigurationManager.AppSettings["ClientServiceCreateClientsRoute"];
        static string BaseurlCreateAccount = ConfigurationManager.AppSettings["ClientServiceCreateAccountRoute"];

        public async Task<Client> GetClient(string token,Client client)
        {
            List<JsonHeaders> parametros = new List<JsonHeaders>();
            parametros.Add(new JsonHeaders("Authorization", token));
            JsonAdapters.JsonAdapters jadapters = new JsonAdapters.JsonAdapters();
            string response = await jadapters.GetJson(parametros, BaseurlGetClient, client, BaseurlGetClient, HttpMethod.POST);
            Client retObj = JsonConvert.DeserializeObject<Client>(response);
            return retObj;
        }

        public async Task<List<ClientFAccount>> GetClients(string token)
        {
            List<JsonHeaders> parametros = new List<JsonHeaders>();
            parametros.Add(new JsonHeaders("Authorization", token));
            JsonAdapters.JsonAdapters jadapters = new JsonAdapters.JsonAdapters();
            string response = await jadapters.GetJson(parametros, BaseurlGetClients, null, BaseurlGetClients, HttpMethod.POST);
            List<ClientFAccount> retObj = JsonConvert.DeserializeObject<List<ClientFAccount>>(response);
            return retObj;
        }
        public async Task<Client> CreateClient(Client client,string token)
        {
            List<JsonHeaders> parametros = new List<JsonHeaders>();
            parametros.Add(new JsonHeaders("Authorization", token));
            JsonAdapters.JsonAdapters jadapters = new JsonAdapters.JsonAdapters();
            string response = await jadapters.GetJson(parametros, BaseurlCreateClient, client, BaseurlCreateClient, HttpMethod.POST);
            Client retObj = JsonConvert.DeserializeObject<Client>(response);
            return retObj;
        }
        public async Task<Operation> CreateAccount(Operation operation, string token)
        {
            List<JsonHeaders> parametros = new List<JsonHeaders>();
            parametros.Add(new JsonHeaders("Authorization", token));
            JsonAdapters.JsonAdapters jadapters = new JsonAdapters.JsonAdapters();
            string response = await jadapters.GetJson(parametros, BaseurlCreateAccount, operation, BaseurlCreateAccount, HttpMethod.POST);
            Operation retObj = JsonConvert.DeserializeObject<Operation>(response);
            return retObj;
        }
    }
}
