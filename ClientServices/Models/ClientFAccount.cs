using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    [Table("vwCLIENT_FIRST_ACCOUNT")]
    public class ClientFAccount
    {
        [Key]
        public int CL_ID { get; set; }
        public String CL_NAME { get; set; }
        public String CL_PASSWORD { get; set; }
        public DateTime CL_CREATION_DATE { get; set; }
        public int AC_ACT_ID { get; set; }
        public Decimal AC_BALANCE { get; set; }
    }
}