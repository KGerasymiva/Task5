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
    public class ServiceController<T> : Controller where T : IEntityDTO
    {
        private IService<T> service;

        public ServiceController(IService<T> service)
        {
            this.service = service;
        }

        // GET: api/Ticket
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(service.Get());
        }

        // GET: api/TicketDTO/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = service.Get(id);
                return Ok(item);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

        }


        // POST: api/Ticket
        [HttpPost]
        public IActionResult Post([FromBody] T item)
        {
            item.Id = 0;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                service.Post(item);
                return Ok(item);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] T item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            item.Id = id;
            try
            {
                service.Put(item);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(new { Exception = e.Message });
            }

        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Exception = e.Message });
            }

        }


    }
}
