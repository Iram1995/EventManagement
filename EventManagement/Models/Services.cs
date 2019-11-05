using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Services
    {
        [Key]
        public int serviceId { get; set; }
        public string service { get; set; }
        public double cost { get; set; }
        public bool isActive{get;set;}
        [ForeignKey("Event")]
        public int? event_Id { get; set; }
        public Event Event{ get;set; }
        
    }
}