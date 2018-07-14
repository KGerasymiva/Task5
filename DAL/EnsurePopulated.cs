using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            AirportContext context = ServiceProviderServiceExtensions.GetRequiredService<AirportContext>(app.ApplicationServices);

            context.Database.EnsureDeleted();
            if (!context.Database.EnsureCreated()) return;

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(
                    new Ticket()
                    {
                        Price = 100M,
                        FlightForeignKey = 1,
                    },
                    new Ticket()
                    {
                        //Id = 2,
                        Price = 200M,
                        FlightForeignKey = 2,
                    },
                new Ticket()
                {
                    //Id = 3,
                    Price = 300M,
                    FlightForeignKey = 3,
                }
                );
            }

            if (!context.PlaneTypes.Any())
            {
                context.PlaneTypes.AddRange(
                    new PlaneType()
                    {
                        //Id = 1,
                        Model = "AN",
                        Seats = 100,
                    },
                    new PlaneType()
                    {
                        //Id = 2,
                        Model = "AN",
                        Seats = 200,
                    },
                    new PlaneType()
                    {
                        //Id = 3,
                        Model = "AN",
                        Seats = 300,
                    }
                );
            }

            if (!context.Planes.Any())
            {
                context.Planes.AddRange(
                    new Plane()
                    {
                        //Id = 1,
                        Name = "Plane1",
                        Type = 1,
                        TimeUsed = "100000"
                    },
                    new Plane()
                    {
                        //Id = 2,
                        Name = "Plane2",
                        Type = 2,
                        TimeUsed = "20000"
                    },
                    new Plane()
                    {
                        //Id = 3,
                        Name = "Plane3",
                        Type = 3,
                        TimeUsed = "30000"
                    }
                );

            }

            if (!context.Pilots.Any())
            {
                context.Pilots.AddRange(
                    new Pilot()
                    {
                        //Id = 1,
                        Name = "John",
                        Surname = "Smith",
                        BirthDay = "1982/05/23",
                        Experience = 20000,
                    },
                    new Pilot()
                    {
                        //Id = 2,
                        Name = "Scott",
                        Surname = "Jonson",
                        BirthDay = "1992/12/03",
                        Experience = 500,
                    },
                    new Pilot()
                    {
                        //Id = 3,
                        Name = "Pall",
                        Surname = "Green",
                        BirthDay = "1989/07/13",
                        Experience = 7000,
                    }
                );
            }

            if (!context.Flightattendants.Any())
            {
                //context.Flightattendants.AddRange(
                //    new Flightattendant()
                //    {
                //        //Id = 1,
                //        Name = "Mary",
                //        Surname = "Smith",
                //        BirthDay = "1999/05/21",
                //    },
                //    new Flightattendant()
                //    {
                //        //Id = 2,
                //        Name = "Jane",
                //        Surname = "Jonson",
                //        BirthDay = "1998/15/03",
                //    },
                //    new Flightattendant()
                //    {
                //        //Id = 3,
                //        Name = "Liza",
                //        Surname = "Green",
                //        BirthDay = "1999/08/01",

                //    }
                //);


            }

            if (!context.Flights.Any())
            {
                context.Flights.AddRange(
                    new Flight()
                    {
                        //Id = 1,
                        Number = "QW5432",
                        Departure = "Kyiv",
                        Destination = "Lviv",
                        DeparturingTime = "2018-12-14 10:13:20",
                        ArrivingTime = "2018-12-14 10:43:20",
                        Tickets = new List<Ticket>(),
                    },
                    new Flight()
                    {
                        //Id = 3,
                        Number = "PY9875",
                        Departure = "Kyiv",
                        Destination = "Barcelona",
                        DeparturingTime = "2018-12-15 15:13:20",
                        ArrivingTime = "2018-12-15 17:43:20",
                        Tickets = new List<Ticket>(),

                    },
                    new Flight()
                    {
                        //Id = 3,
                        Number = "KJ457",
                        Departure = "Kyiv",
                        Destination = "Vien",
                        DeparturingTime = "2018-10-15 15:13:20",
                        ArrivingTime = "2018-10-15 17:43:20",
                        Tickets = new List<Ticket>(),

                    }
                );


            }
            context.SaveChanges();
        }
    }
}

