using System.Collections.Generic;
using BL;
using BL.Service;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
   public class TicketController : Controller
    {
        private IServiceTicket _serviceTicket;

        public TicketController(IServiceTicket serviceTicket)
        {
            this._serviceTicket = serviceTicket;
        }

        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<TicketDTO> Get()
        {
            
            return _serviceTicket.GetTickets();
        }

        // GET: api/TicketDTO/5
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return _serviceTicket.GetTicket(id) ;
        }


        // POST: api/TicketDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
            //TODO
        }

        // PUT: api/TicketDTO/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            //TODO
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO
        }
    }
}
