using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class Transfer
    {
        public int CL_ID_FROM { get; set; }
        public int CL_ID_TO { get; set; }
        public Decimal value { get; set; }
    }
}