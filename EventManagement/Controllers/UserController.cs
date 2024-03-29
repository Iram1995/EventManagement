﻿using EventManagement.Models;
using EventManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
   
    public class UserController : Controller
    {
        DataModel dbcontext = new DataModel();
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize]
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult GetUsers()
        {
            var users = dbcontext.users.AsEnumerable();
            return View(users);
        }
      
        public ActionResult CreateUser()
        {
            UserViewModel viewModel = new UserViewModel();
         
            return View(viewModel);
        }
       
        [HttpPost]
        public ActionResult CreateUser(UserViewModel viewModel)
        {
            try
            {
                User user = new User();
                user.firstName = viewModel.firstName;
                user.lastName = viewModel.lastName;
               // user.genderId = viewModel.GenderId;
               // user.roleId = viewModel.RoleId;
                             
                user.email = viewModel.Email;
                user.password = viewModel.password;
               //   user.roleId = viewModel.RoleId;
               // user.genderId = viewModel.GenderId;
                dbcontext.users.Add(user);
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("GetUsers");
        }
    }
}