using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace DAL
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options)
            : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flightattendant> Flightattendants { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }


        

    }


}
