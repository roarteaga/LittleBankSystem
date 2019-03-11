using AuthenticationService.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ServiceIntegration
{
    public class AuthenticationService
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationService));
        static string Baseurl = ConfigurationManager.AppSettings["AuthenticationServiceRoute"];

        public async Task<String> authentication(string username, string password)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { },
                DateParseHandling = DateParseHandling.None
            };
            String token = "";
            using (var client = new HttpClient())
            {
                try
                {
                    LoginRequest login = new LoginRequest();
                    login.Username = username;
                    login.Password = password;
                    string jsonString = new JavaScriptSerializer().Serialize(login);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = await client.PostAsync(ConfigurationManager.AppSettings["AuthenticationServiceRoute"], content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var response = Res.Content.ReadAsStringAsync().Result;
                        token = response.Replace("\"", "");
                    }
                }
                catch (Exception exp)
                {
                    log.Error("AuthenticationService", exp);
                }
            }
            return token;

        }
    }
}
