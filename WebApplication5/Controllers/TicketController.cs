using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Service;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : ServiceController<TicketDTO>
    {
        public TicketController(IService<TicketDTO> service) : base(service)
        {
        }
    }
}