using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Menu
    {
        public int menuId { get; set; }
        public string menu { get; set; }
        public ICollection<MenuEventRelationship> MenuEventRelationship { get; set; }
    }
}