using System;
using System.Collections.Generic;
using BL;
using BL.Service;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BL.Infrastructure;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private IService<TicketDTO> _serviceTicket;

        public TicketController(IService<TicketDTO> serviceTicket)
        {
            this._serviceTicket = serviceTicket;
        }

        // GET: api/Ticket
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_serviceTicket.Get());
        }

        // GET: api/TicketDTO/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = _serviceTicket.Get(id);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            
        }


        // POST: api/Ticket
        [HttpPost]
        public IActionResult Post([FromBody] TicketDTO ticket)
        {
            ticket.Id = 0;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _serviceTicket.Post(ticket);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new {Exception = e.Message});
            }
           
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketDTO ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ticketDto.Id = id;
            try
            {
                _serviceTicket.Put(ticketDto);
                return Ok(ticketDto);
            }
            catch (Exception e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceTicket.Delete(id);
        }

        private class Ticket
        {
            public int FlightId { get; set; }
            public decimal Price { get; set; }
        }
    }
}
