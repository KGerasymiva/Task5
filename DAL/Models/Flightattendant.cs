using System;

namespace DAL.Models
{
    public class Flightattendant : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        public int CrewForeignKey { get; set; }
        public Crew Crew { get; set; }
    }
}
