using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public int Pilot { get; set; }
        [NotMapped]
        public IEnumerable<int> FlightAttendance { get; set; }
    }
}
