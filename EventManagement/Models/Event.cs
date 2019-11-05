using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Event
    {
        [Key]
        public int eventId { get; set; }
        public int refNo { get; set; }
        public int cnic { get; set; }
        public int cellNo { get; set; }
        public string  MS { get; set; }
        public DateTime createdDate { get; set; }
        [ForeignKey("creator")]
        public int createdBy { get; set; }
        public virtual User creator { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public DateTime EventDate { get; set; }
        
        public string notes { get; set; }
        public int noOfPeople { get; set; }
        public double perHead { get; set; }
        public double totalAmount { get; set; }
        public double? grandTotal { get; set; }
        public double advance { get; set; }
        public double Received { get; set; }
        public double balance { get; set; }
        public ICollection<Services> Services{ get; set; }
    }
}