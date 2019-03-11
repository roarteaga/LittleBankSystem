using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuthenticationService.Models
{
    [Table("CLIENT")]
    public class Client
    {
        [Key]
        public int CL_ID { get; set; }
        public string CL_NAME { get; set; }
        public string CL_PASSWORD { get; set; }
        public DateTime CL_CREATION_DATE { get; set; }
    }
}