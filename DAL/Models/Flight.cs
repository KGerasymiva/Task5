using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Models
{
    public class Flight : Entity
    {
        public string Number { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DeparturingTime { get; set; }
        public string ArrivingTime { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
