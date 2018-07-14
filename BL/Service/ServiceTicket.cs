﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        IUnitOfWork Database { get; set; }
        private IMapper mapper;
        private AirportContext context;

        public ServiceTicket(IUnitOfWork uow, IMapper mapper, AirportContext context)
        {
            Database = uow;
            this.mapper = mapper;
            this.context = context;

        }


        public IEnumerable<TicketDTO> GetTickets()
        {
            var tickets = Database.Set<Ticket>().Get();
            var flights = Database.Set<Flight>().Get();

            var res = tickets
                .Join(flights,
                    t => t.FlightForeignKey,
                    f => f.Id,
                    (t, f) => new Ticket() { Id = t.Id, Flight = f, Price = t.Price }).ToList();
            return mapper.Map<IEnumerable<TicketDTO>>(res);
        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException($"There is no ticket with id {id}", "");

            var ticket = Database.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            var res = new Ticket { Id = ticket.Id, Flight = ticket.Flight, Price = ticket.Price };

            return mapper.Map<TicketDTO>(res);
        }

        public void PostTicket(int flightId, decimal price)
        {

            context.Tickets.Add(new Ticket(){
                Price = price,
                FlightForeignKey = flightId
            });
            context.SaveChanges();

        }

        public void PutTicket(int id, int flightId, decimal price)
        {
            context.Tickets.Update(new Ticket()
                {
                    Id = id,
                    Price = price,
                    FlightForeignKey = flightId
                }
            );
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

        //    return ticket.Flight;
        //}


    }
}
