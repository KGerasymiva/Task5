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

            context.Database.EnsureCreated();

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(
                    new Ticket()
                    {
                        Id = 1,
                        Price = 1M,
                        FlightNumber = "",
                    },
                    new Ticket()
                    {
                        Id = 2,
                        Price = 1M,
                        FlightNumber = "",
                    }
                );
                context.SaveChanges();
            }

            if (!context.PlaneTypes.Any())
            {
                context.PlaneTypes.AddRange(
                    new PlaneType()
                    {
                        Id = 1,
                        Model = "AN",
                        Seats = 100,
                    },
                    new PlaneType()
                    {
                        Id = 2,
                        Model = "AN",
                        Seats = 200,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

