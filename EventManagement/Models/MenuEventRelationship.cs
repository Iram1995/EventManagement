using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class MenuEventRelationship
    {
        [Key]
        public int id{ get; set; }
        public bool isActive { get; set; }
        [ForeignKey("menu")]
        public int menuId { get; set; }
        public virtual Menu menu { get; set; }
        [ForeignKey("events")]
        public int eventId { get; set; }
        public virtual Event events { get; set; }
    }
}