using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement.ViewModel
{
    public class UserViewModel
    {
            [Key]
            public int userId { get; set; }

            [Display(Name = "First Name")]
            [Required(ErrorMessage = "First Name is required")]
            public string firstName { get; set; }

            [Display(Name = "Last Name")]
            public string lastName { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = " Please Enter Password")]
            [StringLength(255,ErrorMessage = "Minimum length is 5", MinimumLength = 5)]

            [DataType(DataType.Password)]
            public string password { get; set; }

            [Display(Name = "Confirm Password")]
            [Required(ErrorMessage = " Please Enter Password")]
            [StringLength(255,ErrorMessage ="Minimum length is 5", MinimumLength = 5)]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string Confirmpassword { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "Please Enter Email")]
            [EmailAddress]
            public string Email { get; set; }
            public string gender { get; set; }
            

        }
    }