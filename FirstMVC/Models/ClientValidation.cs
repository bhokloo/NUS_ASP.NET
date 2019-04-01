using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Models
{
    public class ClientValidation
    {
        [System.Web.Mvc.Remote("validationOfOneFiled", "Student", HttpMethod ="POST", ErrorMessage ="Username can't contain digit")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Username cannot contain regular expressions")]
        [Required(ErrorMessage = "require username")]
        public string username { get; set; }


        [StringLength(10, MinimumLength = 5, ErrorMessage = "password should contain > 5 and <= 10 characters")]
        [Required(ErrorMessage = "password req")]
        public string password {get; set;}

        [Required(ErrorMessage = "Comfirm password is required")]
        [System.Web.Mvc.Compare("password")]
        public string confirm_password {get; set;}

       
        public string gender { get; set; }

        public Boolean accept { get; set; }

        public string countries { get; set; }

        
    }
}