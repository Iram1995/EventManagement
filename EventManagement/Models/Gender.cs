using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Gender
    {
        [Key]
        public int genderId { get; set; }
        public string gender { get; set; }
        public ICollection<User> users { get; set; }
    }
}