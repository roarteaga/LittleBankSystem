using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ModelClient : DbContext
    {
        public ModelClient() : base("name=LBSEntities")
        {

        }
        public virtual DbSet<ClientFAccount> ClientFirstAccount { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<OperationLog> Operations { get; set; }

    }
}