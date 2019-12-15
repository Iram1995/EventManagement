using EventManagement.Models;
using EventManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;

namespace EventManagement.Controllers
{
   
    public class AccountController : Controller
    {
        DataModel dbcontext = new DataModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Signin(User viewModel)
        {
            try
            {
                if (dbcontext.users.Where(m => m.email == viewModel.email && m.password == viewModel.password).Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.firstName+viewModel.lastName,false);
                    return RedirectToAction("GetUsers","User");
                }
                else
                {
                    ModelState.AddModelError("","Invalid username and password");
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            var genders = new List<SelectListItem>
            {
                new SelectListItem{ Text="Male", Value = "Male" },
                new SelectListItem{ Text="Female", Value = "Female" },
                new SelectListItem{ Text="Other", Value = "Other" },
            };
            ViewBag.genders = genders;
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserViewModel viewModel)
        {
            try
            {
                User user = new User();
                user.firstName = viewModel.firstName;
                user.lastName = viewModel.lastName;
                user.email = viewModel.Email;
                user.password = viewModel.password;
                user.gender = viewModel.gender;
                dbcontext.users.Add(user);
                dbcontext.SaveChanges();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Register");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }


    }
}