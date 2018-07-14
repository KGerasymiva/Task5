using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public int FlightId { get; set; }
        public string DepartingTime { get; set; }
        public int Crew { get; set; }
        public int Plane { get; set; }
    }
}
