using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPMNC.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Hãy nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hãy nhập password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}