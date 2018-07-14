using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public string Number { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DeparturingTime { get; set; }
        public string ArrivingTime { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
