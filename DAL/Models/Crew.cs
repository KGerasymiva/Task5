﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Models
{
    public class Crew : Entity
    {
        public int Pilot { get; set; }
        public List<Flightattendant> FlightAttendantsList { get; set; }
    }
}
