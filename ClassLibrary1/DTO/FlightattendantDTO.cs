using System;

namespace DTO
{
    public class FlightattendantDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }  
    }
}
