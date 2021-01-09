using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportedMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "אימייל חובה")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "אימייל שהוזן לא חוקי")]
        [EmailAddress]
        [Display(Name = "אימייל")]
        public string Email { set; get; }
        [Required]
        [StringLength(18, ErrorMessage = "ה{0} חייבת להיות באורך של לפחות {2} תווים", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { set; get; }
    }
}