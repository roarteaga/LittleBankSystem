using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models
{
    [Table("OPERATION_LOG")]
    public class OperationLog
    {
        [Key]
        public int OP_ID { get; set; }
        public String OP_DESCRIPTION { get; set; }
        public int OP_CL_ID { get; set; }
        public int OP_AC_ID { get; set; }
        public DateTime OP_DATE { get; set; }
    }
}