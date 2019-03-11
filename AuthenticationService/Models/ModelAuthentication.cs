using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models
{
    public class ModelManagement:DbContext
    {
        public ModelManagement() : base("name=LBSEntities") { }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<OperationLog> Operations { get; set; }

    }
}