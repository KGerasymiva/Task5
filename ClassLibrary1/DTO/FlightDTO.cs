using System;
using System.Collections.Generic;

namespace DTO
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DeparturingTime { get; set; }
        public string ArrivingTime { get; set; }
        public IEnumerable<TicketDTO> Tickets { get; set; }
    }
}
