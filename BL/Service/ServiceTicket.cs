using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using BL.Infrastructure;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Service
{
    public class ServiceTicket : IServiceTicket
    {

        private IUnitOfWork UOW { get; set; }
        private IMapper mapper;

        public ServiceTicket(IUnitOfWork uow, IMapper mapper)
        {
            UOW = uow;
            this.mapper = mapper;
        }

        private IEnumerable<Ticket> GetTicketsFromDS()
        {
            return UOW.Set<Ticket>().Get();
        }

        private IEnumerable<Flight> GetFlightsFromDS()
        {
            return UOW.Set<Flight>().Get();
        }

        public IEnumerable<TicketDTO> GetTickets()
        {
            var tickets = GetTicketsFromDS();
            var flights = GetFlightsFromDS();
            var res = Tickets(tickets, flights);

            return mapper.Map<IEnumerable<TicketDTO>>(res);
        }

        internal List<Ticket> Tickets(IEnumerable<Ticket> tickets, IEnumerable<Flight> flights)
        {
            var res = tickets
                .Join(flights,
                    t => t.FlightForeignKey,
                    f => f.Id,
                    (t, f) => new Ticket() { Id = t.Id, Flight = f, Price = t.Price }).ToList();
            return res;
        }

        private IMapper PostPutMapper(TicketDTO ticketDto)
        {
            var flight = GetFlightsFromDS().FirstOrDefault(f => f.Number == ticketDto.FlightNumber);

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDTO, Ticket>().ForMember(opt => opt.Flight, opt => opt.MapFrom(c => flight))
                    .ForMember(opt => opt.FlightForeignKey, opt => opt.MapFrom(c => flight.Id));
                
            })
                .CreateMapper();

            return mapper;
        }

        public TicketDTO GetTicket(int id)
        {
            if (id == 0)
                throw new ValidationException($"Incorrect id value", "");

            if (GetTicketsFromDS().FirstOrDefault(t => t.Id == id) == null)
                throw new ValidationException($"There is no ticket with Id = {id}", "");

            var ticket = GetTicketsFromDS().FirstOrDefault(x => x.Id == id);

            ticket.Flight = GetFlightsFromDS().FirstOrDefault(f => f.Id == ticket.FlightForeignKey);

            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            return mapper.Map<TicketDTO>(ticket);
        }

        public void PostTicket(TicketDTO ticketDto)
        {
            if (ticketDto.FlightNumber == null && ticketDto.Price==0)
                throw new ValidationException("Incorrect input data", "");
            if (GetFlightsFromDS().FirstOrDefault(f => f.Number == ticketDto.FlightNumber) == null)
                throw new ValidationException($"There is no such FlightNumber={ticketDto.FlightNumber}", "");

            var ticket = PostPutMapper(ticketDto).Map<Ticket>(ticketDto);

            UOW.Set<Ticket>().Create(ticket);
            UOW.SaveChages();
        }

        public void PutTicket(TicketDTO ticketDto)
        {
            if (ticketDto == null)
                throw new ValidationException("Incorrect input data", "");
            if (GetTicketsFromDS().FirstOrDefault(t => t.Id == ticketDto.Id) == null)
                throw new ValidationException($"There is no ticket with Id = {ticketDto.Id}", "");
            if (GetFlightsFromDS().FirstOrDefault(f => f.Number == ticketDto.FlightNumber) == null)
                throw new ValidationException($"There is no such FlightNumber={ticketDto.FlightNumber}", "");
            var ticket = PostPutMapper(ticketDto).Map<Ticket>(ticketDto);

            UOW.Set<Ticket>().Update(ticket);
            UOW.SaveChages();
        }

        public void DeleteTicket(int id)
        {
            UOW.Set<Ticket>().Delete(id);
            UOW.SaveChages();
        }


        //public decimal GetPrice(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket", "");

        //    var ticket = UOW.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.Price;
        //}

        //public string GetFlightNumber(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket with id {id}", "");

        //    var ticket = UOW.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.Flight;
        //}


    }
}
