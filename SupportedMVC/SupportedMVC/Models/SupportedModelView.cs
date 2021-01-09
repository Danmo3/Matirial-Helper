using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportedMVC.Models
{
    public class SupportedModelView
    {
        
        public Supported supported{get;set;}
        public User user { get; set; }

    }
}