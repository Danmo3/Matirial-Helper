using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportedMVC.Models
{
    public class User
    {
        [Key]        [Required(ErrorMessage = "ת.ז. חובה")]        [Display(Name = "ת.ז")]        [RegularExpression("([0-9]{9})", ErrorMessage = "הכנס ת.ז. תקף")]        public string strTZ { get; set; }        [Required(ErrorMessage = "שם פרטי חובה")]        [Display(Name = "שם פרטי")]        public string strFirstName { get; set; }        [Required(ErrorMessage = "שם משפחה חובה")]        [Display(Name = "שם משפחה")]        public string strLastName { get; set; }        [Required(ErrorMessage = "שם עיר חובה")]        [Display(Name = "עיר")]        public string strCity { get; set; }        [Required(ErrorMessage = "שם כתובת חובה")]        [Display(Name = "כתובת")]        public string strAddress { get; set; }        [Required(ErrorMessage = "מס' פלא' חובה")]        [Display(Name = "מס' נייד ליצירת קשר")]        [DataType(DataType.PhoneNumber)]        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "מס' פלא' לא תקין")]
        public string strPhone { get; set; }
        [Required(ErrorMessage = "אימייל חובה")]        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "אימייל שהוזן לא חוקי")]        [Display(Name = "אימייל")]

        public string strEmail { get; set; }        [Required]        [StringLength(18, ErrorMessage = "ה{0} חייבת להיות באורך של לפחות {2} תווים", MinimumLength = 6)]        [DataType(DataType.Password)]        [Display(Name = "סיסמא")]        public string Password { set; get; }        public System.DateTime DateRegistration { get; set; }
        [Required(ErrorMessage = "גיל חובה")]        [Display(Name = "גיל")]        [Range(18, 100, ErrorMessage = "הגיל שהוזן לא חוקי")]        public int Age { get; set; }


    }
}