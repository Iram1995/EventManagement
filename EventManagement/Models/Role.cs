using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Role
    {
        [Key]
        public int roleId{get;set;}
        public string role { get; set; }
        public ICollection<User> users { get; set; }
    }
}