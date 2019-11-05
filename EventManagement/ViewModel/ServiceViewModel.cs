using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.ViewModel
{
    public class ServiceViewModel
    {
        [Key]
        public int serviceId { get; set; }
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "Please Enter Service Name")]
        public string service { get; set; }

        [Required(ErrorMessage = "Please Enter price of service")]
        [Display(Name = "Cost")]
        public double cost { get; set; }
    }
}