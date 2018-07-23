using System.Collections.Generic;
using BL.Service;
using DAL.UnitOfWork;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //   [Route("api/PlaneType")]
    public class PlaneTypeController : Controller
    {
        private IService<PlaneTypeDTO> service;

        public PlaneTypeController(IService<PlaneTypeDTO> service)
        {
            this.service = service;
        }

        // GET: api/PlaneTypeDTO
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        // GET: api/PlaneTypeDTO/5
        [HttpGet("{id}")]
        //public PlaneTypeDTO Get(int id)
        //{
        //    //try
        //    //{
        //    //    var planeType = service.Get(id);
        //    //    return Ok();
        //    //}
        //    //catch (ValidationException e)
        //    //{
        //    //    return BadRequest(new { Exception = e.Message });
        //    //}
        //    //return service.Get(id);
        //}

        // POST: api/PlaneTypeDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlaneTypeDTO/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
