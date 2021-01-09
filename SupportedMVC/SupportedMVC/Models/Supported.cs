using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace SupportedMVC.Models
{
    public class Supported
    {
        [Display(Name = "נא הכנס מידע אישי")]
        [Required(ErrorMessage = "שדה חובה!")]
        public string AssistenceMessage { get; set; }


    }
}