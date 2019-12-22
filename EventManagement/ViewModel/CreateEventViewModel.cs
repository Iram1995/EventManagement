using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.ViewModel
{
    public class CreateEventViewModel
    {
        
        public int[] serviceID { get; set; }
     
        public int eventId { get; set; }
        [Required]
        public string refNo { get; set; }
        [Required]
        public string cnic { get; set; }
        [Required]
        public string cellNo { get; set; }
        [Required]
        public string MS { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public DateTime EventDateTime { get; set; }
        [Required]
        public string notes { get; set; }
        [Required]
        public int noOfPeople { get; set; }
        [Required]
        public double perHead { get; set; }
        [Required]
        public double totalAmount { get; set; }
        [Required]
        public double? grandTotal { get; set; }
        [Required]
        public double? Tax { get; set; }
        [Required]
        public double advance { get; set; }
        [Required]
        public double Received { get; set; }
        [Required]
        public double balance { get; set; }
        public string eventDate { get; set; }
        [Required]
        public DateTime EventTime { get; set; }
        public List<Services> service { get; set; }
        public List<Menu> menusList { get; set; }
        public List<CheckBoxListItem> menus { get; set; }
        public string file { get; set; }
        public string eventType {get;set;}
        public CreateEventViewModel()
        {
            menus = new List<CheckBoxListItem>();
        }
    }
}