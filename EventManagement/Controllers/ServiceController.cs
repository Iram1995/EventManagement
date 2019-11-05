using EventManagement.Models;
using EventManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    [Authorize]
  
    public class ServiceController : Controller
    {
        DataModel dbcontext = new DataModel();
        // GET: Service
        public ActionResult Index()
        {
            var viewModel = dbcontext.services.AsEnumerable();
            return View(viewModel);
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(ServiceViewModel viewModel)
        {
            try
            {
                Services service = new Services();
                service.cost = viewModel.cost;
                service.service = viewModel.service;
                dbcontext.services.Add(service);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            Services viewModel = dbcontext.services.Find(id);
            return View(viewModel);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(Services viewModel)
        {
            try
            {
                var service = dbcontext.services.Find(viewModel.serviceId);
                service.cost = viewModel.cost;
                service.service = viewModel.service;
                dbcontext.Entry(service).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            Services service = dbcontext.services.Find(id);
            return View(service);
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(Services viewModel)
        {
            try
            {
                var service = dbcontext.services.Find(viewModel.serviceId);
                dbcontext.services.Remove(service);
                dbcontext.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
