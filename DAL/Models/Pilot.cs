using System;

namespace DAL.Models
{
    public class Pilot : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }
        public string Experience { get; set; }
    }
}
