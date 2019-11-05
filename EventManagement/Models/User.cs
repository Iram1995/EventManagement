using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        [EmailAddress]

        public string email { get; set; }
        [ForeignKey("role")]
        public int roleId{ get; set; }
        public virtual Role role { get; set; }
        [ForeignKey("gender")]
        public int genderId { get; set; }
        public virtual Gender gender { get; set; }
        public ICollection<Event> events { get; set; }
    }
}