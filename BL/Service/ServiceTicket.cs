using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Infrastructure;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;

namespace BL.Service
{
    public class ServiceTicket : IServiceTicket
    {

        IUnitOfWork Database { get; set; }

        public ServiceTicket(IUnitOfWork uow)
        {
            Database = uow;
        }


        public IEnumerable<TicketDTO> GetTickets()
        {
            // автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(Database.Set<Ticket>().Get());

        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException($"There is no ticket with id {id}", "");

            var ticket = Database.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            return new TicketDTO { Id = ticket.Id, FlightNumber = ticket.FlightNumber, Price = ticket.Price };
        }

        //public decimal GetPrice(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket", "");

        //    var ticket = Database.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.Price;
        //}

        //public string GetFlightNumber(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket with id {id}", "");

        //    var ticket = Database.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.FlightNumber;
        //}


    }
}
