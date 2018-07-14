using System;

namespace DAL.Models
{
    public class Departure : Entity
    {
        public string FlightNumber { get; set; }
        public string RealDepartingTime { get; set; }
        public int Crue { get; set; }
        public int Plane { get; set; }
    }
}
