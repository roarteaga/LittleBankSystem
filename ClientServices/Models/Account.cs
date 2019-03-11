using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    [Table("ACCOUNT")]
    public class Account
    {
        [Key]
        public int AC_ID { get; set; }
        public int AC_CL_ID { get; set; }
        public Decimal AC_BALANCE { get; set; }
        public int AC_ACT_ID { get; set; }
        public DateTime AC_CREATION_DATE { get; set; }
    }
}