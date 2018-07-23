using System;
using System.Collections.Generic;
using System.Text;
using BL;
using DTO;

namespace BL.Service
{
    public interface IServiceTicket
    {
        TicketDTO GetTicket(int id);
        IEnumerable<TicketDTO> GetTickets();

        void PostTicket(TicketDTO ticketDto);
        void DeleteTicket(int id);
        void PutTicket(TicketDTO ticketDto);
        
        
        //decimal GetPrice(int? id);
        //string GetFlightNumber(int? id);

    }
}
