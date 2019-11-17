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
    public class EventController : Controller
    {
        DataModel dbcontext = new DataModel();
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            var services = dbcontext.services.ToList();
            var servicescheckBoxListItems = new List<CheckBoxListItem>();
            /*  foreach (var item in services)
              {
                  servicescheckBoxListItems.Add(new CheckBoxListItem()
                  {
                      ID = item.serviceId,
                      Display = item.service,
                      IsChecked = false,
                      price = item.cost//On the add view, no genres are selected by default
                  });
              }*/
            CreateEventViewModel viewModel = new CreateEventViewModel();
            // viewModel.Services = servicescheckBoxListItems;
            viewModel.service = new List<Services>();
            return View(viewModel);
        }
        public double getServiceValue(int serviceId)
        {
            var price = 0.0;
            try
            {
                price = dbcontext.services.Where(m => m.serviceId == serviceId).SingleOrDefault().cost;
            }
            catch (Exception ex)
            {

            }
            return price;
        }
        [HttpPost]
        public string CreateNewEvent(CreateEventViewModel viewModel)
        {
            try
            {
                var selectedAttractions = viewModel.Services.Where(x => x.IsChecked).ToList();
                Event events = new Event();
                events.refNo = viewModel.refNo;
                events.cnic = viewModel.cnic;
                events.EventDate = viewModel.EventDate;

                events.createdDate = DateTime.UtcNow;
                events.modifiedDate = DateTime.UtcNow;
                events.modifiedBy = 1;
                events.createdBy = 1;
                //events.ServiceEvents = viewModel.Services;
                events.cellNo = viewModel.cellNo;
                events.MS = viewModel.MS;
                events.totalAmount = viewModel.totalAmount;
                events.grandTotal = viewModel.grandTotal;
                events.noOfPeople = viewModel.noOfPeople;
                events.notes = viewModel.notes;
                events.perHead = viewModel.perHead;
                events.Received = viewModel.Received;
                events.advance = viewModel.advance;
                events.balance = viewModel.balance;
                events.isActive = true;
                dbcontext.events.Add(events);
                dbcontext.SaveChanges();
                var eventId = dbcontext.events.OrderByDescending(m => m.eventId).FirstOrDefault().eventId;
                return eventId.ToString();
            }
            catch (Exception ex)
            {
                return (0).ToString();
            }


        }
        [HttpPost]
        public string AddServicestoEvents(List<Service> services, int? eventId)
        {
            var response = "";
            try
            {
                if (services != null)
                {
                    foreach (var item in services)
                    {
                        var service = new Services();
                        service.cost = Convert.ToInt32(item.price);
                        service.service = item.name;
                        service.event_Id = eventId;
                        service.isActive = true;
                        dbcontext.services.Add(service);
                    }
                    dbcontext.SaveChanges();
                }
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Failure";
            }
            return response;
        }
        public ActionResult GetEvents()
        {
            return View();
        }
        public ActionResult GetEventDetail(int id)
        {
            Event viewModel=dbcontext.events.Where(m => m.eventId == id).FirstOrDefault();
            return View(viewModel);
        }
        public ActionResult DeleteEvent(int id)
        {
            Event viewModel = dbcontext.events.Where(m => m.eventId == id).SingleOrDefault();
            try
            {
                viewModel.isActive = false;
                dbcontext.Entry(viewModel).State = EntityState.Modified;
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("GetEvents");
        }
        public ActionResult EditEvent(int id)
        {
            CreateEventViewModel viewModel = new CreateEventViewModel();
            Event events = dbcontext.events.Where(m => m.eventId == id).SingleOrDefault();
            try
            {

                viewModel.EventDate = events.EventDate;

                viewModel.advance = events.advance;
                viewModel.balance = events.balance;
                viewModel.cellNo = events.cellNo;
                viewModel.cnic = events.cnic;
                viewModel.grandTotal = events.grandTotal;
                viewModel.MS = events.MS;
                viewModel.noOfPeople = events.noOfPeople;
                viewModel.notes = events.notes;
                viewModel.perHead = events.perHead;
                viewModel.Received = events.Received;
                viewModel.refNo = events.refNo;
                viewModel.totalAmount = events.totalAmount;
                viewModel.eventId = events.eventId;
                var services = dbcontext.services.ToList();
                viewModel.service = dbcontext.services.Where(m => m.event_Id == events.eventId).ToList();
                /* var servicescheckBoxListItems = new List<CheckBoxListItem>();
                 foreach (var item in services)
                 {
                     servicescheckBoxListItems.Add(new CheckBoxListItem()
                     {
                         ID = item.serviceId,
                         Display = item.service,
                         IsChecked = false,
                         price = item.cost//On the add view, no genres are selected by default
                     });
                 }

                 viewModel.Services = servicescheckBoxListItems;*/


            }
            catch (Exception ex)
            {

            }
            return View(viewModel);
        }

    
        public string SaveEditEvent(CreateEventViewModel events)
        {

            Event viewModel = dbcontext.events.Where(m => m.eventId == events.eventId).FirstOrDefault();
            try
            {
                viewModel.EventDate = events.EventDate;
                viewModel.advance = events.advance;
                viewModel.balance = events.balance;
                viewModel.cellNo = events.cellNo;
                viewModel.cnic = events.cnic;
                viewModel.grandTotal = events.grandTotal;
                viewModel.MS = events.MS;
                viewModel.noOfPeople = events.noOfPeople;
                viewModel.notes = events.notes;
                viewModel.perHead = events.perHead;
                viewModel.Received = events.Received;
                viewModel.refNo = events.refNo;
                viewModel.totalAmount = events.totalAmount;
                viewModel.balance = events.balance;
                viewModel.isActive = true;
                dbcontext.Entry(viewModel).State = EntityState.Modified;
                dbcontext.SaveChanges();

                return events.eventId.ToString();

            }
            catch (Exception ex)
            {
                return (0).ToString();
            }


        }
        [HttpPost]
        public ActionResult EditServicestoEvents(List<Service> services, int? eventId)
        {
            var response = "";
            var dbservice = dbcontext.services.Where(m => m.event_Id == eventId).ToList();
            var removedService = dbservice.Where(m => !services.Any(c => c.Id == m.serviceId));

           foreach (var item in removedService)
            {
                var service = dbcontext.services.Where(m => m.serviceId == item.serviceId); 
                dbcontext.services.Remove(item);
                dbcontext.SaveChanges();
            }
            dbservice = dbcontext.services.Where(m => m.event_Id == eventId).ToList();
            var viewModel = services.Where(m => m.Id == null).ToList();
            try
            {
                foreach (var item in viewModel)
                {
                    var service = new Services();
                    service.cost = Convert.ToInt32(item.price);
                    service.service = item.name;
                    service.event_Id = eventId;
                    service.isActive = true;
                    dbcontext.services.Add(service);
                }
                dbcontext.SaveChanges();
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Failure";
            }
            return RedirectToAction("GetEvents");
        }

        public string SaveEditService(Services viewModel)
        {
            var response = "";
            var service = dbcontext.services.Where(m => m.serviceId == viewModel.serviceId).FirstOrDefault();
            try
            { 
               
                service.service = viewModel.service;
                service.cost = viewModel.cost;
                dbcontext.Entry(service).State = EntityState.Modified;
                dbcontext.SaveChanges();
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Failure";
            }
            return service.service+"="+service.cost;
        }
        public ActionResult EditService(int Id)
        {
           
            try
            {
                var service = dbcontext.services.Where(m => m.serviceId == Id).FirstOrDefault();
                return View(service);

            }
            catch (Exception ex)
            {
                return RedirectToAction("GetEvents");
            }
           
        }
    }
    
    public class Service {
        public int? Id { get; set; }
        public string price { get; set; }
        public string name { get; set; }

    }
}