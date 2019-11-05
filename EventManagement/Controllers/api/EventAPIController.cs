using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.Controllers.api
{
    public class EventAPIController : ApiController
    {
        DataModel dbcontext = new DataModel();
        // GET: Event
        // GET: api/EventAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EventAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EventAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EventAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EventAPI/5
        public void Delete(int id)
        {
        }
      
        public IHttpActionResult GetUsers() {
            var response = dbcontext.events.Select(n => new {
                n.advance,
                n.balance,
                n.cellNo,
                n.cnic,
                n.createdDate,
                n.EventDate,
                
                n.grandTotal,
                n.MS,
                n.noOfPeople,
                n.notes,
                n.Received,
                n.refNo,
                n.totalAmount,
                n.perHead,
                n.eventId
            });
            return Ok(response);
        }
    }
}
