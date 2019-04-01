using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Models
{
    public class ServerValidation
    {
        public string username { get; set; }
        public string password {get; set;}
        public string confirm_password {get; set;}
        public string gender { get; set; }
        public Boolean accept { get; set; }
        public string countries { get; set; }



    }
}