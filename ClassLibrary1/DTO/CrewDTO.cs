using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public int Pilot { get; set; }
        [NotMapped] 
        public IEnumerable<int> FlightAttendance { get; set; }
    }
}

